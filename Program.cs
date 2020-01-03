using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList entriesList = new ArrayList();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\peter.bozov\Desktop\Docs\Gosho\pesho.txt");
            foreach (string item in lines)
            {
                string[] readContact = item.Split(new char[] { ' ' }, 3, StringSplitOptions.None);
                Contact contact = new Contact();

                contact.contactNumber = readContact[1];
                contact.contactName = readContact[0];
                contact.contactMail = readContact[2];
                entriesList.Add(contact);
            }
            string menuOption = "";
            do
            {
                if (menuOption != "1")
                {
                    Console.Clear();
                }
                Console.WriteLine("1. Contact List");
                Console.WriteLine("2. Add a contact");
                Console.WriteLine("3. Delete a contact");
                Console.WriteLine("4. Edit a contact");
                Console.WriteLine("5. Quit");
                menuOption = Console.ReadLine();
                if (menuOption == "2")
                {
                    createContact(entriesList);
                }
                else if (menuOption == "1")
                {
                    int contactIndex = 0;
                    foreach (var item in entriesList)
                    {
                        contactIndex++;
                        Console.Write("[" + contactIndex + "] - ");
                        Console.WriteLine(item);
                    }
                }
                else if (menuOption == "3")
                {
                    Console.WriteLine("Which contact do you want to DELETE: ");
                    string chosenContact = Console.ReadLine();
                    entriesList.RemoveAt(int.Parse(chosenContact) - 1);
                }
                else if (menuOption == "4")
                {
                    Console.WriteLine("Which contact do you want to EDIT: ");
                    string chosenContact = Console.ReadLine();
                    Contact contactChosen = (Contact) entriesList[int.Parse(chosenContact) - 1];
                    Console.WriteLine("Number: ");
                    contactChosen.contactNumber = Console.ReadLine();
                    Console.WriteLine("Name: ");
                    contactChosen.contactName = Console.ReadLine();
                    Console.WriteLine("Mail: ");
                    contactChosen.contactMail = Console.ReadLine();
                }
            } while (menuOption != "5");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\peter.bozov\Desktop\Docs\Gosho\pesho.txt"))
            {
                foreach (Contact line in entriesList)
                {
                    file.WriteLine(line.ToString());
                }
            }
        }
        public static void createContact(ArrayList entriesList)
        {
            Contact contact = new Contact();
            Console.WriteLine("Number: ");
            contact.contactNumber = Console.ReadLine();
            Console.WriteLine("Name: ");
            contact.contactName = Console.ReadLine();
            Console.WriteLine("Mail: ");
            contact.contactMail = Console.ReadLine();
            entriesList.Add(contact);
        }
    }
}