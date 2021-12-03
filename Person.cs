using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Homework_2
{
    public class Person
    {
        private string name;
        private string email;
        private TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        private const int EmailLengthLimit = 254;// According to spec with clarification from IETF RFC Errata in 2010
        private const int NameLengthLimit = 50;

        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null) { throw new ArgumentNullException("Karma police\nArrest this null"); }
                value = value.Trim();
                if (value == "" ) { throw new ArgumentException("Empty name"); }
                if (value.Length > NameLengthLimit) { throw new ArgumentOutOfRangeException(); }
                value = value.ToLower();
                value = textInfo.ToTitleCase(value);
                value = value.Replace("<", "&lt;");
                value = value.Replace(">", "&gt;");
                name = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (value == null) { throw new ArgumentNullException("Karma police\nArrest this null"); } //System.Net.Mail.MailAddress throws same exception
                value = value.Trim();
                if (value == "") { throw new ArgumentException("Empty string for email"); }
                if (value.Length > EmailLengthLimit) { throw new ArgumentOutOfRangeException(); }
                if (IsValidEmail(value)) { email = value; }
                else { throw new ArgumentException("Email is invalid\n" + $"{value}\n"); }
            }
        }

        protected bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
