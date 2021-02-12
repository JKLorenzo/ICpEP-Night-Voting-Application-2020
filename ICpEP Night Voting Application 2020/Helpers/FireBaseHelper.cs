using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Database.Streaming;

namespace ICpEP_Night_Voting_Application_2020
{
    public class FireBaseHelper
    {
        FirebaseClient firebaseClient;
        public List<Vote> voted, queueVote;
        BackgroundWorker workerVoteQueuer;

        public FireBaseHelper()
        {
            firebaseClient = new FirebaseClient("https://icpep-night-votingdb.firebaseio.com/", new FirebaseOptions{
                AuthTokenAsyncFactory = () => Task.FromResult("Fl3NjpC7oowMD2YZ8Nor6M3rfBnv0Pbumz7I01wR")
            });

            voted = new List<Vote>();
            queueVote = new List<Vote>();

            workerVoteQueuer = new BackgroundWorker();
            workerVoteQueuer.DoWork += workerVoteQueuer_DoWork;
            workerVoteQueuer.RunWorkerAsync();
        }

        public async Task<bool> isConnected()
        {
            try
            {
                var response = await firebaseClient.Child("connected").OnceSingleAsync<String>();
                return bool.Parse(response);
            }
            catch (Exception e) { return false; }
        }

        public void startVotedListener()
        {
            Console.WriteLine("Voted Listener | Listener started");
            var observable = firebaseClient.Child("Voted").AsObservable<Vote>().Subscribe(d => VotedObserver(d));
        }

        private void VotedObserver(FirebaseEvent<Vote> data)
        {
            if (data.Key != null && !data.Key.Equals(""))
            {
                bool doesExists = false;
                if (voted.Count > 0)
                {
                    foreach (var vote in voted)
                    {
                        if (vote.ID == data.Object.ID)
                        {
                            doesExists = true;
                        }
                    }
                }
                if (doesExists == false)
                {
                    Vote this_vote = new Vote(data.Object.ID, data.Object.VoteMale, data.Object.VoteFemale);
                    Console.WriteLine("Voted Observer | Added to voted: {0}", this_vote.ID);
                    voted.Add(this_vote);
                }
            }
        }

        public bool CommandVote(Vote vote)
        {
            if (voted.Count > 0)
            {
                foreach (Vote this_vote in voted)
                    if (this_vote.ID == vote.ID)
                        return false;
            }
            if (queueVote.Count > 0)
            {
                foreach (Vote this_vote in queueVote)
                    if (this_vote.ID == vote.ID)
                        return false;
            }

            queueVote.Add(vote);
            voted.Add(vote);
            Console.WriteLine("Command Vote | Added to vote queuer: " + vote.ID);
            return true;
        }

        private async void workerVoteQueuer_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (queueVote.Count > 0)
                {
                    if (isConnected().Result == true)
                    {
                        Vote this_vote = queueVote.First();
                        try
                        {
                            await firebaseClient.Child("Voted").PostAsync(this_vote);
                            queueVote.RemoveAt(0);
                            Console.WriteLine("Vote Queuer | Uploaded to voted: " + this_vote.ID);
                        }
                        catch (Exception) 
                        {
                            Console.WriteLine("Vote Queuer | Uploaded to voted failed: " + this_vote.ID);
                            System.Threading.Thread.Sleep(1000); 
                        }
                    }
                    else
                        System.Threading.Thread.Sleep(1000);
                }
                else
                    System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
