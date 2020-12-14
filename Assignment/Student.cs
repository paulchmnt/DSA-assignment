using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_01
{
    class Student
    {
        // FIELDS
        private string firstName;
        private string lastName;
        private string studentNumber;
        private float averageScore;

        // CONSTRUCTORS
        public Student(string firstName, string lastName, string studentNumber, float averageScore)
        {
            FirstName = firstName;
            LastName = lastName;
            StudentNumber = studentNumber;
            AverageScore = averageScore;
        }

        // PROPERTIES
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("First name cannot be null or empty!");
                else if (value.Length > 100) // No rules about firstName's length, I added this one by myself
                    throw new ArgumentOutOfRangeException("First name cannot be more than 100 characters!");
                else
                    firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Last name cannot be null!");
                else if (value.Length > 100) // No rules about lastName's length, I added this one by myself
                    throw new ArgumentOutOfRangeException("Last name cannot be more than 100 characters!");
                else
                    lastName = value;
            }
        }
        public string StudentNumber
        {
            get { return studentNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Student number cannot be null!");
                else if (value.Length > 15) // No rules about studentNumber's length, I added this one by myself
                    throw new ArgumentOutOfRangeException("Student number cannot be more than 15 characters!");
                else
                    studentNumber = value;
            }
        }
        public float AverageScore
        {
            get { return averageScore; }
            set
            {
                if (value >= 0.00 && value <= 100.00) // Conditions of averageScore value
                    averageScore = value;
                else
                    throw new ArgumentOutOfRangeException("Average score must be between 0.00 & 100.00.");
            }
        }
        // Dynamic property
        public string FullName
        {
            get { return firstName + " " + lastName; }
        }

        // METHODS
        public override string ToString()
        {
            string info = $"Student {FullName} informations:\n" +
                $"First name: {FirstName}\n" +
                $"Last name: {LastName}\n" +
                $"Student number: {StudentNumber}\n" +
                $"Average score: {AverageScore}%\n";
            return info;
        }
    }
}
