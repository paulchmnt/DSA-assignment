using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_01
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomDataList assignment = new CustomDataList(); // Create an instance of CustomDataList

            Console.WriteLine("Hi and welcome to the program of this assignement!");
            int choice; int index; // Creating these variables here to not create new ones at each loop

            while (true)
            {
                choice = -1; index = -1; // Give them "false" values in case of incorrect choice to not execute the previous choice

                // Display menu
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine("Menu:\n\t" +
                    "1. Populate the list with sample data (5 students are added)\n\t" +
                    "2. Add an element to the list\n\t" +
                    "3. Get an element and its information by its index\n\t" +
                    "4. Remove an element with its index\n\t" +
                    "5. Remove the first element in the list\n\t" +
                    "6. Remove the last element in the list\n\t" +
                    "7. Display all elements in the list\n\t" +
                    "8. Exit the program\n" +
                    "---------------------------------------");

                string choiceString = Console.ReadLine();
                // Check if the user made a correct choice 
                if (int.TryParse(choiceString, out int result) && int.Parse(choiceString) > 0 && int.Parse(choiceString) < 9)
                    choice = result;
                else
                    Console.WriteLine("This is not a correct choice, please enter 1, 2, 3, 4, 5, 6, 7 or 8.");

                // Different cases
                switch (choice)
                {
                    case 1: // Populate the list with sample data
                        assignment.PopulateWithSampleData();
                        Console.ReadKey();
                        break;

                    case 2: // Add an element to the list
                        Student studentToAdd = CreateStudent();
                        assignment.Add(studentToAdd);
                        Console.ReadKey();
                        break;

                    case 3: // Get an element and its information with its index
                        if (assignment.List.Count > 0) // Check if the list is not empty
                        {
                            while (true)
                            {
                                Console.WriteLine($"Please enter an index of the list (0 to {assignment.List.Count - 1})");
                                string indexString = Console.ReadLine();
                                // Check if the index is in the list
                                if (int.TryParse(indexString, out result) && int.Parse(indexString) >= 0 && int.Parse(indexString) < assignment.List.Count)
                                {
                                    index = result;
                                    break;
                                }
                                else // Display an appropriate message if the index isn't in the list
                                    Console.WriteLine($"This is not a correct choice, please enter a number between 0 and {assignment.List.Count - 1}");
                            }
                            // Now we can select the student by its index
                            Student studentToGet = assignment.GetElement(index);
                            // And display the student's information
                            Console.WriteLine(studentToGet.ToString());
                            Console.ReadKey();
                        }
                        else // If list is empty, display an appropriate message
                            Console.WriteLine("The list is empty, you cannot get an element from it!");
                        break;

                    case 4: // Remove an element from the list by its index
                        if (assignment.List.Count > 0) // Check if the list is not empty
                        {
                            while (true)
                            {
                                Console.WriteLine($"Please enter an index of the list (0 to {assignment.List.Count - 1})");
                                string indexString = Console.ReadLine();
                                // Check if the index is in the list
                                if (int.TryParse(indexString, out result) && int.Parse(indexString) >= 0 && int.Parse(indexString) < assignment.List.Count)
                                {
                                    index = result;
                                    break;
                                }
                                else // Display an appropriate message if the index isn't in the list
                                    Console.WriteLine($"This is not a correct choice, please enter a number between 0 and {assignment.List.Count - 1}");
                            }
                            // Now we can remove the student from the list
                            assignment.RemoveByIndex(index);
                            Console.ReadKey();
                        }
                        else // If list is empty, display an appropriate message
                            Console.WriteLine("The list is empty, you cannot remove an element from it!");
                        break;

                    case 5: // Remove the first element in the list
                        assignment.RemoveFirst();
                        Console.ReadKey();
                        break;

                    case 6: // Remove the last element in the list
                        assignment.RemoveLast();
                        Console.ReadKey();
                        break;
                    case 7: // Display all element in the list and its information 
                        assignment.DisplayList();
                        Console.ReadKey();
                        break;
                    case 8: // Exit the program
                        goto breakOut; // Goes outside the big while loop
                }
            }
        breakOut:;
            Console.ReadKey();
        }


        /// <summary>
        /// Create a new instance of class Student by asking all the required fields to the user
        /// </summary>
        /// <returns>student</returns>
        static Student CreateStudent()
        {
            Student student;
        breakOutStud: // Going back to this line if one of the student's information has not a correct format/value.

            // Required fields to create a student //
            // First name
            Console.WriteLine("Please enter the student's first name:");
            string firstName = Console.ReadLine();

            // Last name
            Console.WriteLine("Please enter the student's last name:");
            string lastName = Console.ReadLine();

            // Student number
            Console.WriteLine("Please enter the student number:");
            string studentNumber = Console.ReadLine();

            // Average score
            float averageScore;
            while (true)
            {
                Console.WriteLine("Please enter the student's average score (%):");
                string scoreString = Console.ReadLine();
                if (float.TryParse(scoreString, out float result))
                {
                    averageScore = result;
                    break;
                }
                else
                    Console.WriteLine("Error! This is not a float number. Please try again.");
            }

            // Every mandatory fields is filled, we can try to create an instance of Student
            try
            {
                student = new Student(firstName, lastName, studentNumber, averageScore);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // In case of problem diplay the error message
                goto breakOutStud; // And go back to the beginning of this method
            }

            // Now we can return the student
            return student;
        }
    }
}
