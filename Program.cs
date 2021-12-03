using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Homework_2
{
    class Program
    {
        public static IList<Person> people = new List<Person>();

        static void Main(string[] args)
        {
            string path = @"..\..\..\index.html";
            people.Add(new Person("  X Æ A-12  ", "IsThereLifeOnMars@protonmail.com"));
            people.Add(new Person("Maxim<script>alert('Name!')</script>", "Scripter1337@yahoo.com"));
            people.Add(new Person("AlexanDRIA          \nTEnWhiteSpaces tripLeName   ", "validmail@gmail.com"));
            people.Add(new Person("WHOOPSCAPSLOCK", "validmail@gmail.com"));
            people.Add(new Person("Doge" + "\u003C" + "script" + "\u003E" + "alert('BONK!')" + "\u003C" + "/script" + "\u003E", "Doge@gmail.com"));
            people.Add(new Person("null", "okNull@gmail.com"));
            people.Add(new Person("кириллица", "cyrillic@mail.ru"));
            people.Add(new Person("シャーマンキング", "シャーマンキング@gmail.com"));

            string htmlString = BuildHtmlString(people);

            try
            {
                File.WriteAllText(path, htmlString);
            }
            catch (IOException e)
            {
                Console.WriteLine("I/O error");
                throw e;
            }
            catch (Exception e) 
            {
                Console.WriteLine("*Bonk*");
                throw e; 
            }
        }

        public static string BuildHtmlString(IList<Person> list)
        {
            StringBuilder htmlBuilder = new StringBuilder("<!DOCTYPE html>\n" + "<html>\n" + "<body>");
            foreach (Person person in people)
            {
                htmlBuilder.Append($"\n<a href=\"mailto: {person.Email}\">{person.Name}</a> |");
            }
            htmlBuilder.Remove(htmlBuilder.Length - 1, 1);
            htmlBuilder.Append("\n</body>" + "\n</html>");
            return htmlBuilder.ToString();
        }
    }
}
