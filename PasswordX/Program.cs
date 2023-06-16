using System;

namespace PasswordX
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose a one of the two options below:");
                Console.WriteLine("1. Generate a password");
                Console.WriteLine("2. Check a password");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    GeneratePassword();
                }
            }


        }

        public static void GeneratePassword()
        {
            //Asks user to input length of password they want to generate
            Console.WriteLine("Enter the length of the password you want to generate:");
            int length = Convert.ToInt32(Console.ReadLine());
            
            //Creates a string of characters to choose from
            string strings = "abcdefghijklmnopqrstuvwxyz" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "1234567890" + "!@#$%^&*()";
            //Creates a random object
            Random random = new Random();
            //Creates an array to store the password
            char[] password = new char[length];
            //Creates a for loop to generate the password
            for (int i = 0; i < length; i++)
            {
                password[i] = strings[random.Next(strings.Length)];
            }
            //Displays the password by printing the array
            Console.WriteLine("Your password is:");
            Console.WriteLine(password);
            Console.ReadKey();
        }
        
        
        public static void CheckPassword()
        {
            Console.WriteLine("Enter the password you want to check:");
            string password = Console.ReadLine();
            
            
            
            Console.ReadKey();
        }
    }

   
}