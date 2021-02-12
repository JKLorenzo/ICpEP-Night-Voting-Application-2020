using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICpEP_Night_Voting_Application_2020
{
    class ClassList
    {
        public List<Student> first_year { get; }
        public List<Student> second_year { get; }
        public List<Student> fifth_year { get; }

        public ClassList()
        {
            first_year = new List<Student>();
            second_year = new List<Student>();
            fifth_year = new List<Student>();

            first_year.Add(new Student(1921061 , "Juliet Beatirce Hinayan"));
            first_year.Add(new Student(1922130 , "Kerguelen Miles Montales"));

            first_year.Add(new Student(1920056 , "Jose Anthony Aguirre"));
            first_year.Add(new Student(1920958 , "Dan Lorenz Altaras"));
            first_year.Add(new Student(1920285 , "Rachel Anne Apellido"));
            first_year.Add(new Student(1920561 , "Alcir Cosas"));
            first_year.Add(new Student(1920103 , "Angelica De La Torre"));
            first_year.Add(new Student(1920514 , "Rosheil Lyla Escobar"));
            first_year.Add(new Student(1920704 , "Gerald Fernandez"));
            first_year.Add(new Student(1921042 , "Godspeed Guinto"));
            first_year.Add(new Student(1920032 , "Patrik Pacey Kusuanco"));
            first_year.Add(new Student(1920907 , "Amiel Kwan"));
            first_year.Add(new Student(1920283 , "Patrick Jones Lim"));
            first_year.Add(new Student(1921771 , "Benjamin Mijares III"));
            first_year.Add(new Student(1920496 , "Brian Parreño"));
            first_year.Add(new Student(1920948 , "Froilyn Poblacion"));
            first_year.Add(new Student(1920987 , "Joaquinn Quilat"));
            first_year.Add(new Student(1920593 , "Christian Salapang"));
            first_year.Add(new Student(1920586 , "Kevin Bryant Salva"));
            first_year.Add(new Student(1921055 , "Nyear Edwin Samson"));
            first_year.Add(new Student(1921393 , "Ayrol Sartaguda"));
            first_year.Add(new Student(1921050 , "J Sylle Loreine Tubola"));
            first_year.Add(new Student(1920991 , "Paolo Louise Tunguia"));
            first_year.Add(new Student(1920869 , "Bea Therese Vargas"));
            first_year.Add(new Student(1921027 , "Jack Watai"));

            first_year.Add(new Student(1920455 , "LLoyd Lester Abastillas"));
            first_year.Add(new Student(1922087 , "John Floyd Alvarez"));
            first_year.Add(new Student(1920968 , "Edron Roden Ardeño"));
            first_year.Add(new Student(1921058 , "Steven Ryan Baesa"));
            first_year.Add(new Student(1920034 , "Durc Ivry Balasa"));
            first_year.Add(new Student(1921555 , "Joshua Adrian Bastillo"));
            first_year.Add(new Student(1921274 , "Colleen Ann Benedicto"));
            first_year.Add(new Student(1921406 , "Benedict-James Beraud-Vargas"));
            first_year.Add(new Student(1921321 , "Brian Bernales"));
            first_year.Add(new Student(1921563 , "Paul John Buenaflor"));
            first_year.Add(new Student(1921546 , "Neil Patrick Buison"));
            first_year.Add(new Student(1921078 , "Daevina Darene Bulabon"));
            first_year.Add(new Student(1920428 , "Serge Angelo De Guzman"));
            first_year.Add(new Student(1920624 , "Miguel Andre De Los Angeles"));
            first_year.Add(new Student(1922145 , "Daniel Denila"));
            first_year.Add(new Student(1922061 , "John Wil Diaros"));
            first_year.Add(new Student(1922247 , "Darlene Joy Dimacutac"));
            first_year.Add(new Student(1920213 , "Miery Angela Fernandez"));
            first_year.Add(new Student(1921688 , "Joanna Juguan"));
            first_year.Add(new Student(1920744 , "Renz Beaver Layco"));
            first_year.Add(new Student(1920176 , "Dennis Maghupoy"));
            first_year.Add(new Student(1921059 , "Diamaludin Mariga Jr."));
            first_year.Add(new Student(1921453 , "Kyben Nabor"));
            first_year.Add(new Student(1921598 , "Daniel Troy Perocho"));
            first_year.Add(new Student(1920559 , "Miguel Paolo Gerard Salarda"));
            first_year.Add(new Student(1921254 , "John Michael Santisteban"));
            first_year.Add(new Student(1921144 , "Jasper Kayl Santos"));
            first_year.Add(new Student(1921125 , "Neil Patrick Sedeño"));

            first_year.Add(new Student(1921939 , "Tracy Ticar"));


            second_year.Add(new Student(1821052 , "Levi Abellar"));
            second_year.Add(new Student(1820741, "John Wilbert Absalon"));
            second_year.Add(new Student(1820473, "Amadeo Cris Alova"));
            second_year.Add(new Student(1820364, "Khycy Janz Alvarez"));
            second_year.Add(new Student(1821113, "Chris Vincent Balinario"));
            second_year.Add(new Student(1820987, "Daniel Peter Cañada"));
            second_year.Add(new Student(1821021, "Kristel Casalda"));
            second_year.Add(new Student(1821116, "Kyle Ohen Cepeda"));
            second_year.Add(new Student(1821820, "John Mar Chang"));
            second_year.Add(new Student(1821786, "John Samuel Chavez"));
            second_year.Add(new Student(1820484, "Raphael Lorenzo D`Souza"));
            second_year.Add(new Student(1822212, "Joey Javier Dasal"));
            second_year.Add(new Student(1820832, "Jann Claude De Jesus"));
            second_year.Add(new Student(1820472, "Ralph Arven Dela Rama"));
            second_year.Add(new Student(1821771, "John Joash Diaz"));
            second_year.Add(new Student(1820421, "Brian Carl Javellana"));
            second_year.Add(new Student(1820523, "Juruel Keanu Lorenzo"));
            second_year.Add(new Student(1820826, "Joshua Uriel Meguiso"));
            second_year.Add(new Student(1821236, "Gerald Vincent Montibon"));
            second_year.Add(new Student(1820302, "Keilah Joie Mulavin"));
            second_year.Add(new Student(1821106, "Jesserie Pinuela"));
            second_year.Add(new Student(1821382, "Robie Ann Piojo"));
            second_year.Add(new Student(1821559, "Shania Louise Quizan"));
            second_year.Add(new Student(1821663, "Raulen Elly Sarona"));
            second_year.Add(new Student(1820342, "John Raphael Serantes"));
            second_year.Add(new Student(1822131, "Dae Hyeon Song"));
            second_year.Add(new Student(1821822, "Cleo Jon Supapo"));
            second_year.Add(new Student(1820969, "Jopet Valencia"));

            second_year.Add(new Student(1821458, "Kaiser Abanto"));
            second_year.Add(new Student(1821552, "Amer Artesano"));
            second_year.Add(new Student(1820941, "John Michael Balceda"));
            second_year.Add(new Student(1822361, "Duke Jerry Bonnie Batayola"));
            second_year.Add(new Student(1820577, "Ruth Micah Berden"));
            second_year.Add(new Student(1822395, "Raymund De La Victoria"));
            second_year.Add(new Student(1821090, "Rojen De Luna"));
            second_year.Add(new Student(1821564, "Maricar Gonzales"));
            second_year.Add(new Student(1821373, "Rica Jane Torres"));
            second_year.Add(new Student(1821915, "Thomas Andrew Zaragoza"));


            fifth_year.Add(new Student(1520047, "Czarina Agles"));
            fifth_year.Add(new Student(1520448, "John Michael Agriam"));
            fifth_year.Add(new Student(1521349, "Lorenz June Alipala"));
            fifth_year.Add(new Student(1520647, "Hermelyn Alvarado"));
            fifth_year.Add(new Student(1520237, "Neil Vincent Alvior"));
            fifth_year.Add(new Student(1220967, "Shairra Mae Batulan"));
            fifth_year.Add(new Student(1422248, "Albert Raymund Benedicto"));
            fifth_year.Add(new Student(1520765, "Darrence Paul Bernadas"));
            fifth_year.Add(new Student(1422216, "Nicole Penny Bernadas"));
            fifth_year.Add(new Student(1420123, "Kim Howard Capanas"));
            fifth_year.Add(new Student(1520470, "Rhea Grace Castañares"));

            fifth_year.Add(new Student(1521418 , "Stemple Casuyon"));
            fifth_year.Add(new Student(1321239 , "Bernardo Cimatu III"));
            fifth_year.Add(new Student(1520397 , "Lowi Dasal"));
            fifth_year.Add(new Student(1420025 , "Danison David"));
            fifth_year.Add(new Student(1521237 , "Kurt Steven De Los Reyes"));
            fifth_year.Add(new Student(1521044 , "Anne Victoria Elano"));
            fifth_year.Add(new Student(1520110 , "Mike Andrey Ferrolino"));
            fifth_year.Add(new Student(1520293 , "Lance Jairue Geronaga"));
            fifth_year.Add(new Student(1120704 , "Jewel Mae Gonzaga"));
            fifth_year.Add(new Student(1520814 , "Filbert Ceasar Gumban"));
            fifth_year.Add(new Student(1520635 , "Samantha Louise Javier"));
            fifth_year.Add(new Student(1321675 , "Francis Peter Juridico"));
            fifth_year.Add(new Student(1520493 , "Jan Michelle Lamboso"));
            fifth_year.Add(new Student(1520045 , "Karla Angela Lilles"));
            fifth_year.Add(new Student(0101366 , "Rene Boy Limson"));
            fifth_year.Add(new Student(1422271 , "Paolo Mansilungan"));
            fifth_year.Add(new Student(1520109 , "Amiel Manzano"));
            fifth_year.Add(new Student(1521167 , "John Wilfred Marañon"));
            fifth_year.Add(new Student(1522050 , "Celine Thel Martem"));
            fifth_year.Add(new Student(1421111 , "Gill Dominic Mendoza"));
            fifth_year.Add(new Student(1620178 , "Mary Sofia Pascual"));
            fifth_year.Add(new Student(1520036 , "Kim Raelle Pavilario"));
            fifth_year.Add(new Student(1520752 , "Ernie John Perez"));
            fifth_year.Add(new Student(1520447 , "Samuel Quezon"));
            fifth_year.Add(new Student(1420742 , "Ana Patricia"));
            fifth_year.Add(new Student(1521598 , "John Urban Trinio"));
            fifth_year.Add(new Student(1420786 , "Matthew Philip Villacarlos"));
            fifth_year.Add(new Student(1520222 , "Jose Miguel Yambot"));
            fifth_year.Add(new Student(1320103 , "Jet Angelo Yusay"));

            fifth_year.Add(new Student(1520880 , "John Rod Aspan"));
            fifth_year.Add(new Student(1522443 , "Christian ALlen Bandiola"));
            fifth_year.Add(new Student(1521234 , "Jhonnalyn Bi-ay"));
            fifth_year.Add(new Student(1520793 , "Jude Timothy Joshua Bomban"));
            fifth_year.Add(new Student(1522447 , "Rona Camarines"));
            fifth_year.Add(new Student(1520132 , "Jarod Kim David"));
            fifth_year.Add(new Student(1520891 , "Enrick Jules Federico"));
            fifth_year.Add(new Student(1520584 , "Shaira Kaye Jagonos"));
            fifth_year.Add(new Student(1520956 , "Mikaela Jarme"));
            fifth_year.Add(new Student(1521397 , "Shieramae Ann"));
            fifth_year.Add(new Student(1422305 , "Mia Jade Montuya"));
            fifth_year.Add(new Student(1521643 , "Mikkael Monzon"));
            fifth_year.Add(new Student(1520882 , "Leonard Riedijk"));
            fifth_year.Add(new Student(1522165 , "Emmar Clemn Rivera"));
            fifth_year.Add(new Student(1520139 , "Ryan Mark Sioson"));
            fifth_year.Add(new Student(1521403 , "Amiel Mathhew Titular"));
        }
    }
}
