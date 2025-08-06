using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();

            while (true)
            {
                ContactBookTag();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("1 @ ADD CONTACT");
                Console.WriteLine("2 @ LIST CONTACTS");
                Console.WriteLine("3 @ SEARCH CONTACT");
                Console.WriteLine("4 @ UPDATE CONTACT");
                Console.WriteLine("5 @ DELETE CONTACT");
                Console.WriteLine("6 @ EXIT\n");
                Console.ResetColor();
                 
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContact(contacts);
                        break;

                    case "2":
                        ListContacts(contacts);
                        break;

                    case "3":
                        SearchContact(contacts);
                        break;

                    case "4":
                        UpdateContact(contacts);
                        break;

                    case "5":
                        DeleteContact(contacts);
                        break;

                    case "6":
                        Console.Write("\nEXITING");
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(400);
                            Console.Write(".");
                        }
                        Console.Write(" GOODBYE!!!");
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nINVALID OPTION.");
                        Console.WriteLine("PLEASE TRY AGAIN.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void AddContact(List<Contact> contacts)
        {
            ContactBookTag();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> ENTER CONTACT NAME: ");
            Console.ResetColor();
            string name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> ENTER CONTACT PHONE: ");
            Console.ResetColor();
            int phone = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> ENTER CONTACT EMAIL: ");
            Console.ResetColor();
            string email = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> ENTER CONTACT ADDRESS: ");
            Console.ResetColor();
            string address = Console.ReadLine();

            if (!contacts.Any(contact => contact.phone == phone))
            {
                contacts.Add(new Contact(name, phone, email, address));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCONTACT ADDED SUCCESSFULLY.");
                Console.ReadLine();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNUMBER ALREADY EXISTS.");
                Console.WriteLine("PLEASE TRY AGAIN.");
                Console.ReadLine();
            }
        }

        static void ListContacts(List<Contact> contacts)
        {
            ContactBookTag();

            if (contacts.Count > 0)
            {
                Console.WriteLine(">>> CONTACT LIST\n");

                foreach (var contact in contacts)
                {
                    Thread.Sleep(200);
                    Console.WriteLine($"NAME: {contact.name} | PHONE: {contact.phone} | EMAIL: {contact.email} | ADDRESS: {contact.address}");
                }
                Console.ReadLine();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNO CONTACTS FOUND.");
                Console.WriteLine("PLEASE ADD SOME CONTACTS FIRST.");
                Console.ReadLine();
            }
        }

        static void SearchContact(List<Contact> contacts)
        {
            ContactBookTag();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> ENTER CONTACT NAME: ");
            Console.ResetColor();
            string name = Console.ReadLine();

            bool found = false;

            foreach (var contact in contacts)
            {
                if (contact.name.Equals(name))
                {
                    Console.WriteLine($"\nNAME: {contact.name} | PHONE: {contact.phone} | EMAIL: {contact.email} | ADDRESS: {contact.address}");
                    Console.ReadLine();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCONTACT NOT FOUND.");
                Console.WriteLine("PLEASE TRY AGAIN.");
                Console.ReadLine();
            }
        }

        static void UpdateContact(List<Contact> contacts)
        {
            ContactBookTag();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> ENTER CONTACT NAME: ");
            Console.ResetColor();
            string name = Console.ReadLine();

            bool found = false;
            foreach (var contact in contacts)
            {
                if (contact.name.Equals(name))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("> ENTER NEW PHONE: ");
                    Console.ResetColor();
                    contact.phone = int.Parse(Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("> ENTER NEW EMAIL: ");
                    Console.ResetColor();
                    contact.email = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("> ENTER NEW ADDRESS: ");
                    Console.ResetColor();
                    contact.address = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCONTACT UPDATED SUCCESSFULLY.");
                    Console.ReadLine();
                    found = true;
                    return;
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCONTACT NOT FOUND.");
                Console.WriteLine("PLEASE TRY AGAIN.");
                Console.ReadLine();
            }
        }
        
        static void DeleteContact(List<Contact> contacts)
        {
            ContactBookTag();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("> ENTER CONTACT NAME: ");
            Console.ResetColor();
            string name = Console.ReadLine();

            bool found = false;
            foreach (var contact in contacts)
            {
                if (contact.name.Equals(name))
                {
                    contacts.Remove(contact);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCONTACT REMOVED SUCCESSFULLY.");
                    Console.ReadLine();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCONTACT NOT FOUND.");
                Console.WriteLine("PLEASE TRY AGAIN.");
                Console.ReadLine();
            }
        }

        static void ContactBookTag()
        {
            string asciiArt = "   ___   ___    __  _____  _      ___  _____     ___    ___  ___      \r\n  / __\\ /___\\/\\ \\ \\/__   \\/_\\    / __\\/__   \\   / __\\  /___\\/___\\/\\ /\\\r\n / /   //  //  \\/ /  / /\\//_\\\\  / /     / /\\/  /__\\// //  ///  // //_/\r\n/ /___/ \\_// /\\  /  / / /  _  \\/ /___  / /    / \\/  \\/ \\_// \\_// __ \\ \r\n\\____/\\___/\\_\\ \\/   \\/  \\_/ \\_/\\____/  \\/     \\_____/\\___/\\___/\\/  \\/ \r\n                                                                      ";

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(asciiArt);
            Console.ResetColor();
        }
    }
}