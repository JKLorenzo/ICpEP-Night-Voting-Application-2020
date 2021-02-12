namespace ICpEP_Night_Voting_Application_2020
{
    class Data
    {
        public int ID { get; set; }
        public int Vote { get; set; }

        public Data(int ID, int Vote)
        {
            this.ID = ID;
            this.Vote = Vote;
        }
    }
}