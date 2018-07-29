using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutoral2Ex1
{
    class Program
    {
        public static List<Table1> table1 = new List<Table1>();

        static void Main(string[] args)
        {
            Program p = new Program();
            CreateTable();
            Console.WriteLine("Searching Studen Application\nPlease choose one of the options\n");
            Console.WriteLine("1)Search by first name");
            Console.WriteLine("2)Search date of birth\n");

            Console.WriteLine("Please enter your option: ");
            p.ChooseOption();
            // use while loops to pass validations and repeat the code if wrong parameters are used
            // Best done by setting everything as default and returning default if arguments are not true

            // Remember to use .FirstOrDefault after LINQ query 
            Console.ReadLine();

        }

        public static void CreateTable()
        {
            table1.Add(new Table1 { ID = 1, FirstName = "Min Chul", LastName = "Shin", DOB = new DateTime(2010, 01, 01), Gender = Gender.Male.ToString() });
            table1.Add(new Table1 { ID = 2, FirstName = "Nicky", LastName = "Lauren", DOB = new DateTime(2009, 01, 01), Gender = Gender.Female.ToString() });
            table1.Add(new Table1 { ID = 3, FirstName = "Amy", LastName = "Park", DOB = new DateTime(2008, 01, 01), Gender = Gender.Female.ToString() });
            table1.Add(new Table1 { ID = 4, FirstName = "Aurelie", LastName = "Adair", DOB = new DateTime(2007, 01, 01), Gender = Gender.Female.ToString() });
        }

        public void ChooseOption()
        {
            try
            {
                var choice = Convert.ToInt32(Console.ReadLine());

                //when user chooses 1
                if (choice == 1)
                {
                    Option1First();
                }

                //when user chooses 2
                else if (choice == 2)
                {
                    Option2();
                }
                else
                {
                    Console.WriteLine("Please enter 1 or 2 only");
                    ChooseOption();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please enter 1 or 2 only");
                ChooseOption();
            }
            ChooseOption();
        }



        public void Option1First()
        {
            Console.WriteLine("You choose: 1");
            Console.WriteLine("Type first name: ");

            var firstName = Console.ReadLine();
            // Input if first names line up

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("Please enter a name");
                Option1First();
            }

            if (table1.Where(x => x.FirstName == firstName).Any())
            {
                Option1Last(firstName);
            }
            else
            {
                Console.WriteLine("\nThat name cannot be found, please re-enter");
                Option1First();
            }
        }

        public void Option1Last(string firstName)
        {
            Console.WriteLine("Please enter last name");

            var lastName = Console.ReadLine();

            if (table1.Where(x => x.LastName == lastName && x.FirstName == firstName).Any())
            {
                var result1 = table1.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();
                Console.WriteLine("Found! Here are the details: \nName: {0} {1} DOB: {2} Gender: {3}", result1.FirstName, result1.LastName, result1.DOB, result1.Gender);
            }

            else
            {
                Console.WriteLine("\nInvalid name, please re enter");
                Option1Last(firstName);
            }
        }

        public void Option2()
        {
            Console.WriteLine("You choose: 2");
            Console.WriteLine("Please enter your date of birth (yyyy-MM-dd)");

            var dateBirth = Console.ReadLine();

            try
            {
                if (table1.Where(x => x.DOB == Convert.ToDateTime(dateBirth)).Any())
                {
                    var result2 = table1.Where(x => x.DOB == Convert.ToDateTime(dateBirth)).FirstOrDefault();
                    Console.WriteLine("Details are {0} - {1} - {2} - {3}", result2.DOB, result2.FirstName, result2.LastName, result2.DOB, result2.Gender);
                }
                else
                {
                    Console.WriteLine("\nThe birthdate you are looking for cannot be found, please try again.");
                    Option2();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please enter in the correct format (yyyy-MM-dd)");
                Option2();
            }
        }

        //Validations
        //If null or empty or whitespace (Tick)
        //Date format is wrong 
        //get the code to keep running  

    }
}

