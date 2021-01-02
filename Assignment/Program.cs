using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
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
                Console.WriteLine("\n----------------------------------------------------------------------------------");
                Console.WriteLine("Menu:\n\t" +
                    "1. Populate the list with sample data (6 students are added)\n\t" +
                    "2. Add an element to the list\n\t" +
                    "3. Get an element and its information by its index\n\t" +
                    "4. Remove an element with its index\n\t" +
                    "5. Remove the first element in the list\n\t" +
                    "6. Remove the last element in the list\n\t" +
                    "7. Display all elements in the list\n\t" +
                    "8. Sort all elements in the list by the field and the direction you choose\n\t" +
                    "9. Get the element with the best score and display its information\n\t" +
                    "10. Get the element with the lowest score and display its information\n\t" +
                    "11. Exit the program\n" +
                    "----------------------------------------------------------------------------------");

                string choiceString = Console.ReadLine();
                // Check if the user made a correct choice 
                if (int.TryParse(choiceString, out int result) && int.Parse(choiceString) > 0 && int.Parse(choiceString) < 12)
                    choice = result;
                else
                    Console.WriteLine("This is not a correct choice, please enter 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 or 11.");

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
                        }
                        else // If list is empty, display an appropriate message
                            Console.WriteLine("The list is empty, please fill it to execute this function.");
                        Console.ReadKey();
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
                        }
                        else // If list is empty, display an appropriate message
                            Console.WriteLine("The list is empty, please fill it to execute this function.");
                        Console.ReadKey();
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


                    case 8: // Sort the list by field and direction chosen by the user
                        if (assignment.List.Count > 0)
                        {
                            int sortField = -1; int sortDirection = -1; // Create variables needed and give them "fake" values

                            // Choice of sortField
                            while (true)
                            {
                                // Ask the user the sort field
                                Console.WriteLine($"Please choose the sort field:\n\t" +
                                    $"1. Firstname\n\t" +
                                    $"2. Lastname\n\t" +
                                    $"3. Student number\n\t" +
                                    $"4. Average score\n\t");
                                string sortFieldString = Console.ReadLine();
                                // Check if the choice is correct
                                if (int.TryParse(sortFieldString, out result) && int.Parse(sortFieldString) > 0 && int.Parse(sortFieldString) < 5)
                                {
                                    sortField = result; // Affect the correct result into sortField
                                    break; // And break the loop
                                }
                                else // Display an appropriate message if choice not correct
                                    Console.WriteLine("This is not a correct choice, please enter a number between 1 and 4.");
                            }

                            // Choice of sortDirection
                            while (true)
                            {
                                // Ask the user the sort direction
                                Console.WriteLine($"Please choose the sort direction:\n\t" +
                                    $"1. Ascending\n\t" +
                                    $"2. Descending\n\t");
                                string sortDirectionString = Console.ReadLine();
                                // Check if the choice is correct
                                if (int.TryParse(sortDirectionString, out result) && int.Parse(sortDirectionString) > 0 && int.Parse(sortDirectionString) < 3)
                                {
                                    sortDirection = result; // Affect the correct result into sortDirection
                                    break; // And break the loop
                                }
                                else // Display an appropriate message if choice not correct
                                    Console.WriteLine("This is not a correct choice, please enter 1 or 2.");
                            }

                            // Now that the user chose the sort field and direction, we can sort the list according to his choices
                            assignment.Sort(sortDirection, sortField);

                            // Finally, we ask the user if he wants to display the sorted list
                            Console.WriteLine("Do you want to display the sorted list (tap 'yes' if you want to)");
                            choiceString = Console.ReadLine();
                            if (choiceString == "yes")
                                assignment.DisplayList();
                        }
                        else
                            Console.WriteLine("The list is empty, please fill it to execute this function.");
                        Console.ReadKey();
                        break;


                    case 9: // Get the student with the best score and display his/her information
                        if (assignment.List.Count > 0) // Check if the list is not empty
                        {
                            Student bestStud = assignment.GetMaxElement(); // Get the best student
                            Console.WriteLine($"Student {bestStud.FullName} has the highest score of all students in the list.");
                            Console.WriteLine(bestStud.ToString()); // Display his/her information
                        }
                        else // If list is empty, display an appropriate message
                            Console.WriteLine("The list is empty, please fill it to execute this function.");
                        Console.ReadKey();
                        break;


                    case 10: // Get the student with the lowest score and display his/her information
                        if (assignment.List.Count > 0) // Check if the list is not empty
                        {
                            Student worstStud = assignment.GetMinElement(); // Get the worst student
                            Console.WriteLine($"Student {worstStud.FullName} has the lowest score of all students in the list.");
                            Console.WriteLine(worstStud.ToString()); // Display his/her information
                        }
                        else // If list is empty, display an appropriate message
                            Console.WriteLine("The list is empty, please fill it to execute this function.");
                        Console.ReadKey();
                        break;


                    case 11: // Exit the program
                        goto breakOut; // Goes outside the big while loop
                }
            }
        breakOut:;
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
