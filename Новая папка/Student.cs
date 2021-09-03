using System;
using System.Globalization;

namespace Students
{
    /// <summary>
    /// This class represents a student.
    /// </summary>
    internal sealed class Student
    {
        /// <summary>
        /// Creates an instance based on name and surname.
        /// </summary>
        public Student(string name, string surname)
        {
            if (name == null || surname == null)
            {
                throw new ArgumentNullException();
            }

            if (name == "" || surname == "")
            {
                throw new ArgumentException("Name or surname is empty.");
            }

            if (!ValidateNameParameter(name) || !ValidateNameParameter(surname))
            {
                throw new ArgumentException("Name or surname consists of invalid characters.");
            }

            FullName = Capitalize(string.Format("{0} {1}", name.ToLower(), surname.ToLower()));
            Email = string.Format("{0}.{1}@epam.com", name, surname).ToLower();
        }

        /// <summary>
        /// Creates an instance based on email.
        /// </summary>
        public Student(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException();
            }

            if (email == "")
            {
                throw new ArgumentException("Email is empty.");
            }

            try
            {
                FullName = GetFullNameFromEmail(email.ToLower());
            }

            catch
            {
                throw;
            }

            Email = email.ToLower();
        }

        /// <summary>
        /// Compares this instance to another object or Student instance.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Student student)
            {
                return student.FullName.Equals(FullName);
            }

            return false;
        }

        /// <summary>
        /// Returns hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            var positions = FullName.Length / 2;
            return FullName.GetHashCode() >> positions
                    ^ Email.GetHashCode() << positions;
        }

        /// <summary>
        /// Returns this instance data in string format.
        /// </summary>
        public override string ToString()
        {
            return $"{FullName} : {Email}";
        }

        /// <summary>
        /// Name and Surname in one string.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; }

        private string Capitalize(string uncapitalized)
        {
            var textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(textInfo.ToLower(uncapitalized));
        }

        private bool ValidateNameParameter(string name)
        {
            var nameArray = name.ToCharArray();
            var length = name.Length;
            for (int i = 0; i < length; i++)
            {
                if (!char.IsLetter(nameArray[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private string GetFullNameFromEmail(string email)
        {
            var fullname = email.Replace("@epam.com", "");
            var splittedFullname = fullname.Split('.');
            if (splittedFullname.Length != 2
                || !ValidateNameParameter(splittedFullname[0])
                || !ValidateNameParameter(splittedFullname[1]))
            {
                throw new ArgumentException("Email is in wrong format");
            }

            return string.Concat(Capitalize(splittedFullname[0]), " ", Capitalize(splittedFullname[1]));
        }
    }
}
