using System;

namespace Lab8
{
    class Program
    {
        //only needs to be 5
        static string[] studentNames = { "Aaron", "Kelly", "Josh", "Seth", "Bailey" };
        static string[] studentHometowns = { "Sterling Heights", "Warren", "Sterling Heights", "Ann Arbor", "Saginaw" };
        static string[] studentFavFoods = { "Cinnamon Rolls", "Apples", "Pizza", "Watermelon", "Ice Cream" };
        static string studentName;
        static int userInput;
        static void Main(string[] args)
        {
            AskForStudent();
        }
        static void AskForStudent() 
        {
             userInput = ParseIntFromString("Welcome to our C# class. Which student would you like to learn more about? (enter anumber 1-5, 0 to exit):");
            if (userInput == 0)
            {
                //exit
            }
            else
            {
                studentName = GetStudentName(userInput);
                string userSelection = GetInput($"Student {userInput} is {studentName}. What would you like to know about {studentName}? (enter “hometown” or“favorite food” or “no”  or “exit”):");

                switch (userSelection)
                {
                    case "hometown":
                        GetHomeTown(userInput);
                        break;
                    case "favorite food":
                        GetFavFood(userInput);
                        break;
                    case "exit":
                        break;
                    case "no":
                        AskForStudent();
                        break;
                    default:
                        break;
                }
            }
        }
        
        static void GetHomeTown(int index) 
        {
            switch (GetInput($"{studentNames[index-1]} is from {studentHometowns[index - 1]}. Would you like to know more? (enter “yes” or “no” or “exit”)"))
            {
                case "yes":
                    GetFavFood(index);
                    break;
                case "no":
                    AskForStudent();
                    break;
                case "exit":
                    break;
                default:
                    AskForStudent();
                    break;
            }
        }
        static void GetFavFood(int index) 
        {
            switch (GetInput($"{studentNames[index - 1]}'s favorite food is {studentFavFoods[index - 1]}. Would you like to know more? (enter “yes” or “no” or “exit”)"))
            {
                case "yes":
                    GetHomeTown(index);
                    break;
                case "no":
                    AskForStudent();
                    break;
                case "exit":
                    break;
                default:
                    AskForStudent();
                    break;
            }
        }
        static string GetStudentName(int index) 
        {
            try
            {
                userInput = index;
                return studentNames[index - 1];
            }
            catch (IndexOutOfRangeException)
            {
                
                return GetStudentName(ParseIntFromString("input was too high of a number, please try again."));
            }

        }
        static string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        static int ParseIntFromString(string message)
        {
            try
            {
                return int.Parse(GetInput(message));
            }
            catch
            {
                Console.WriteLine("Something went wrong, please try again: ");
                return ParseIntFromString(message);
            }
        }
    }
}
