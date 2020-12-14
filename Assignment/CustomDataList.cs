using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assignment_01
{
    class CustomDataList // Name of the data structure
    {
        // FIELD
        private LinkedList<Student> list; // I chose to use LinkedList because I never used them before

        // CONSTRUCTOR
        public CustomDataList()
        {
            // Just initialize the list in the constructor (empty when created)
            List = new LinkedList<Student>();
        }

        // PROPERTIES
        public LinkedList<Student> List
        {
            get { return list; } // Need a "get" because we call the list in the class Program
            set { list = value; } // I put a "set" for the constructor but not really essential
        }

        // Don't need to add the other properties from the instructions (Length, First and Last)
        // because a LinkedList already owns them (Count, First and Last)

        // METHODS
        public void PopulateWithSampleData()
        {
            // Creating an instance of StreamReader to read from file
            StreamReader reader = new StreamReader(@"C:\Users\paulc\Documents\VUM\Data Structures & Algorithms\Assignment\SampleData.txt");

            // Reading first line
            string line = reader.ReadLine();

            while (line != null)
            {
                // Separating the different informations/variables
                var data = line.Split("|");

                string firstName = data[0].Trim();
                string lastName = data[1].Trim();
                string studentNumber = data[2].Trim();
                float averageScore = float.Parse(data[3].Trim());

                // Creating a new instance of class Student and then adding it to the list
                Student student = new Student(firstName, lastName, studentNumber, averageScore);
                list.AddLast(student);
                Console.WriteLine($"Student {student.FullName} has been added to the list.");

                // Passing to next line
                line = reader.ReadLine();
            }
            // Closing the StreamReader instance
            reader.Close();
        }

        public void Add(Student element)
        {
            list.AddLast(element); // The element is added at the end of the list
            Console.WriteLine($"Student {element.FullName} has been added to the list.");
        }

        public Student GetElement(int index)
        {
            // Impossible to get an element from the linked list with an integer index, need to use another option

            Student[] array = new Student[list.Count]; // Create an array with the same size of the list
            // So we have to copy the list into the array
            list.CopyTo(array, 0);
            // And then we can access the element with the index in the array (and return it)
            return array[index];
        }

        public void RemoveByIndex(int index)
        {
            // Impossible to remove an element from the linked list with an integer index, need to use another option

            Student[] array = new Student[list.Count]; // Create an array with the same size of the list
            // So we have to copy the list into the array
            list.CopyTo(array, 0);
            // Then we can access the element with the index in the array
            Student toRemove = array[index];
            // And we can finally remove it
            list.Remove(toRemove);
            Console.WriteLine($"Student {toRemove.FullName} has been removed from the list.");
        }

        public void RemoveFirst()
        {
            if (list.Count > 0) // Check if there is at least one element in the list
            {
                Student toRemove = list.First.Value; // Select student to remove (here it's first of the list)
                list.RemoveFirst(); // Then remove it from the list
                Console.WriteLine($"Student {toRemove.FullName} has been removed from the list.");
            }
            else // If list is empty, display an appropriate message
                Console.WriteLine("The list is empty, you cannot remove an element!");
        }

        public void RemoveLast()
        {
            if (list.Count > 0) // Check if there is at least one element in the list
            {
                Student toRemove = list.Last.Value; // Select student to remove (here it's last of the list)
                list.RemoveLast(); // Then remove it from the list
                Console.WriteLine($"Student {toRemove.FullName} has been removed from the list.");
            }
            else // If list is empty, display an appropriate message
                Console.WriteLine("The list is empty, you cannot remove an element!");
        }

        public void DisplayList()
        {
            if (list.Count > 0) // Check if there is at least one element in the list
            {
                foreach (Student student in list)
                    Console.WriteLine(student.ToString() + "\n"); // Display each element and its information
            }
            else // If list is empty, display an appropriate message
                Console.WriteLine("The list is empty.");
        }
    }
}
