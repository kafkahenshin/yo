using System;
using System.Collections.Generic;

namespace Students
{

    class Program
    {
        /// <summary>
        /// This method adds record to the dictionary
        /// and prints about it in console.
        /// </summary>
        public static void AddSubjects(Dictionary<Student, HashSet<string>> dictionary, Student student, string[] subjects)
        {
            dictionary[student] = new HashSet<string>(subjects);
            Console.WriteLine("{0} -> {1}", string.Join(", ", subjects), student.ToString());
        }

        /// <summary>
        /// This method generate new string[] of 3 elements
        /// with distinct values.
        /// </summary>
        public static string[] Generate3Subjects(string[] subjects)
        {
            if (subjects == null)
            {
                throw new System.ArgumentNullException();
            }

            if (subjects.Length == 0)
            {
                throw new System.ArgumentException(message: "Array is empty");
            }

            string[] studentSubjects = new string[3];
            var random = new Random();
            studentSubjects[0] = subjects[random.Next(0, 5)];
            for (var i = 1; studentSubjects[2] == null;)
            {
                var newSubjectIndex = random.Next(0, 5);
                var duplicate = Array.Find(studentSubjects, subject => subject == subjects[newSubjectIndex]);
                studentSubjects[i] = duplicate == null ? subjects[newSubjectIndex] : null;
                if (studentSubjects[i] != null)
                {
                    i++;
                }
            }

            return studentSubjects;
        }


        static void Main(string[] args)
        {
            var student1c1 = new Student("John", "Smith");
            var student2c1 = new Student("River", "Song");
            var student3c1 = new Student("Amy", "Pond");
            var student1c2 = new Student("John", "Smith");
            var student2c2 = new Student("River", "Song");
            var student3c2 = new Student("Amy", "Pond");
            var subjects = new string[] { "math", "computer science", "biology", "history", "physics", "chemistry" };
            var studentSubjectDict = new Dictionary<Student, HashSet<string>>();
            AddSubjects(studentSubjectDict, student1c1, Generate3Subjects(subjects));
            AddSubjects(studentSubjectDict, student2c1, Generate3Subjects(subjects));
            AddSubjects(studentSubjectDict, student3c1, Generate3Subjects(subjects));
            AddSubjects(studentSubjectDict, student1c2, Generate3Subjects(subjects));
            AddSubjects(studentSubjectDict, student2c2, Generate3Subjects(subjects));
            AddSubjects(studentSubjectDict, student3c2, Generate3Subjects(subjects));
            Console.WriteLine("\n\nDictionary now is:\n");
            foreach (var item in studentSubjectDict)
            {
                Console.WriteLine($"{string.Join(",", item.Value)} -- {item.Key.ToString()}");
            }

        }
    }
}
