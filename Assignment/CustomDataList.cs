using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assignment
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
                Console.WriteLine("The list is empty, please fill it to execute this function.");
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
                Console.WriteLine("The list is empty, please fill it to execute this function.");
        }

        public void DisplayList()
        {
            if (list.Count > 0) // Check if there is at least one element in the list
            {
                foreach (Student student in list)
                    Console.WriteLine(student.ToString() + "\n"); // Display each element and its information
            }
            else // If list is empty, display an appropriate message
                Console.WriteLine("The list is empty, please fill it to execute this function.");
        }

        public void Sort(int sortDirection, int sortField)
        {
            switch (sortField)
            {
                case 4: // Average score case

                    float[] arrayFloat = new float[list.Count]; // We create an array of float
                    int i = 0;
                    foreach (Student student in list)
                    {
                        arrayFloat[i] = student.AverageScore; // And fill it by all the student's score in the list
                        i++;
                    }

                    // Start of sorting part (I chose to use selection sort)
                    for (i = 0; i<arrayFloat.Length; i++) // We browse the array
                    {
                        float minVal = arrayFloat[i]; // And affect the value at the index in the minimum value
                        for (int j = i; j<arrayFloat.Length; j++) // Then we browse the array from the starting index
                        {
                            if(arrayFloat[j] < minVal) // And if we find a value less than the minimum one
                            {
                                // We exchange the 2 values
                                float var = minVal;
                                minVal = arrayFloat[j];
                                arrayFloat[j] = var;
                            }
                            // Now that we have the minimum value in the array unsorted, we can affect it to the index i
                            // in the array before to pass to the next starting index where the array is unsorted
                            arrayFloat[i] = minVal; 
                        }
                    }
                    // End of sorting part

                    if (sortDirection == 2) // Case user chose descending direction 
                    {
                        for (i = 0; i < arrayFloat.Length / 2; i++)
                        {
                            // So need to inverse the order of all elements in the array
                            float var = arrayFloat[i];
                            arrayFloat[i] = arrayFloat[arrayFloat.Length - 1 - i];
                            arrayFloat[arrayFloat.Length - 1 - i] = var;
                        }
                    }

                    // Here we create a new LinkedList<Student> that we need to fill with the sorting data
                    LinkedList<Student> sortedList = new LinkedList<Student>();
                    i = 0;
                    while (i < arrayFloat.Length) // We browse all data in the sorted array
                    {
                        foreach (Student student in list) // Need to browse the student list 
                            if (student.AverageScore == arrayFloat[i]) // To collect the good one (same average score)
                                sortedList.AddLast(student); // Then we add the student in the sorted list
                        i++; // And pass to the next value in the sorted array
                    }
                    // Then we replace the old list by the new one sorted
                    list = sortedList;
                    break;

                default:
                    // Because other cases are with string variables, I made this function to create 
                    // and fill an array with the students field chose by the user
                    string[] array = CopyListByField(sortField);

                    // By using the Array.Sort() method, we sort all the array's values in ascending direction 
                    // I used the Array.Sort() because it's an array of string
                    Array.Sort(array);
                    if (sortDirection == 2) // Case user chose descending direction 
                    {
                        for (i = 0; i < array.Length / 2; i++)
                        {
                            // So need to inverse the order of all elements
                            string var = array[i];
                            array[i] = array[array.Length - 1 - i];
                            array[array.Length - 1 - i] = var;
                        }
                    }

                    // And finally we execute this function that will copy the data sorted (array) in the LinkedList
                    // depending of the field chose by the user
                    CopyArraySortedInList(array, sortField);
                    break;
            }
        }

        public string[] CopyListByField(int sortField)
        {
            string[] array = new string[list.Count]; // Create an array with size of the list
            int i = 0;
            switch (sortField)
            {
                case 1: // Firstname case
                    foreach (Student student in list) // We browse the student list
                    {
                        array[i] = student.FirstName; // And add in the array the student field chose by the user (here firstname)
                        i++; // And passing to the next student
                    }
                    return array; // When finished, we return the array

                case 2: // Lastname case
                    foreach (Student student in list)
                    {
                        array[i] = student.LastName;
                        i++;
                    }
                    return array;

                case 3: // Student number case
                    foreach (Student student in list)
                    {
                        array[i] = student.StudentNumber;
                        i++;
                    }
                    return array;

                default: // It cannot happens, I needed to add it to avoid error when executing the program
                    return null;
            }
        }

        public void CopyArraySortedInList(string[] array, int sortField)
        {
            // Here we create a new LinkedList<Student> that we need to fill with the sorting data
            LinkedList<Student> sortedList = new LinkedList<Student>();

            int i = 0;
            while (i < array.Length) // We browse all data in the sorted array
            {
                switch (sortField)
                {
                    case 1: // Firstname case
                        foreach (Student student in list) // Need to browse the student list 
                            if (student.FirstName == array[i]) // To collect the good one (same firstname)
                                sortedList.AddLast(student); // Then we add the student in the sorted list
                        break;
                    case 2: // Lastname case
                        foreach (Student student in list)
                            if (student.LastName == array[i]) // Same lastname is the condition
                                sortedList.AddLast(student);
                        break;
                    case 3: // Student number case
                        foreach (Student student in list)
                            if (student.StudentNumber == array[i]) // Same student number is the condition
                                sortedList.AddLast(student);
                        break;
                }
                i++; // And pass to the next value in the sorted array
            }
            // Then we replace the old list by the new one sorted
            list = sortedList;
        }

        public Student GetMaxElement()
        {
            Student[] array = new Student[list.Count]; // Create an array with the same size of the list
            list.CopyTo(array, 0); // So we have to copy the list into the array

            Student bestStud = array[0]; // We say first student in list is the best 
            if(array.Length > 1) // And if the list has more than 1 element
            {
                for (int i = 1; i<array.Length; i++)
                {
                    if (bestStud.AverageScore < array[i].AverageScore) // We compare all elements to find the best score
                        bestStud = array[i];
                }
            }
            return bestStud; // Then we return the student with the best average score
        }

        public Student GetMinElement()
        {
            Student[] array = new Student[list.Count]; // Create an array with the same size of the list
            list.CopyTo(array, 0); // So we have to copy the list into the array

            Student worstStud = array[0]; // We say first student in list is the worst 
            if (array.Length > 1) // And if the list has more than 1 element
            {
                for (int i = 1; i < array.Length; i++)
                {
                    if (worstStud.AverageScore > array[i].AverageScore) // We compare all elements to find the lowest score
                        worstStud = array[i];
                }
            }
            return worstStud; // Then we return the student with the lowest average score
        }
    }
}
