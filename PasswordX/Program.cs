using System;
using System.Linq;

namespace PasswordX {
    internal class Program {
        public static void Main(string[] args) {
            while (true) {
                Console.WriteLine("Welcome to PasswordX!");
                Console.WriteLine("Choose a one of the two options below:");
                Console.WriteLine("1. Generate a password");
                Console.WriteLine("2. Check a password");
                Console.WriteLine("3. Quit");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1) {
                    GeneratePassword();
                } else if (choice == 2) {
                    Console.WriteLine("Enter the password you want to check:");
                    string password = Console.ReadLine();
                    int score = CheckPassword(password);
                    if (score != -999) {
                        Console.WriteLine("Your password score is: " + score);
                    }
                    Console.ReadKey();
                } else if (choice == 3) {
                    System.Environment.Exit(1);
                }
            }
        }

        public static void GeneratePassword() {
            
            //Creates a string of characters to choose from
            string strings = "abcdefghijklmnopqrstuvwxyz" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "1234567890" + "!$%^&*()-_=+";
            //Creates a random object
            Random random = new Random();
            
            int length = random.Next(4) + 8;
            char[] password = new char[length];
            int score = 0;
            
            while (score <= 20) {
                for (int i = 0; i < length; i++) {
                    password[i] = strings[random.Next(strings.Length)];
                }
                string pass = new string(password);
                score = CheckPassword(pass);
            }
            //Displays the password by printing the array
            Console.WriteLine("Your password is:");
            Console.WriteLine(password);
            Console.ReadKey();
        }
        
        
        public static int CheckPassword(string password) {
            
            int score = password.Length;
            
            if (score < 8 || score > 24) {
                Console.WriteLine("Your password is an incorrect length!");
                return -999;
            }
            
            //Variables to check if password has uppercase, lowercase, number, and special character
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lower = "abcdefghijklmnopqrstuvwxyz";
            string num = "1234567890";
            string special = "!$%^&*()-_=+";
            string strings = upper + lower + num + special;
            
            //Variables to check if password has a substring of 3 characters in a row
            string line1 = "qwertyuiop";
            string line2 = "asdfghjkl";
            string line3 = "zxcvbnm";
            
            //Variables to check if password has Upper/Lower/Number/Special characters
            bool hasUpper = false;
            bool hasLower = false;
            bool hasNum = false;
            bool hasSpecial = false;
            
            //Checks if password has an incorrect character
            //Checks if password has an uppercase, lowercase, number, and special character
            for(int i = 0; i < password.Length; i++) {
                if (!strings.Contains(password[i])) {
                    Console.WriteLine("Your password has an incorrect character!");
                    return -999;
                } else if (upper.Contains(password[i])) {
                    hasUpper = true;
                } else if (lower.Contains(password[i])) {
                    hasLower = true;
                } else if (num.Contains(password[i])) {
                    hasNum = true;
                } else if (special.Contains(password[i])) {
                    hasSpecial = true;
                }
                
                //stop checking when at the end of password
                if (i < password.Length - 3) {
                    //check if line1/2/3 on keyboard contains the current substring from password (making sure it is lowercase)
                    if (line1.Contains(password.Substring(i,3).ToLower()) || line2.Contains(password.Substring(i,3).ToLower()) || line3.Contains(password.Substring(i,3).ToLower())) {
                        score -= 5;
                    }
                }
            }
            //Gives score if password has uppercase, lowercase, number, and special character
            if (hasUpper) {
                score += 5;
            }
            
            if (hasLower) {
                score += 5;
            }
            
            if (hasNum) {
                score += 5;
            }
            
            if (hasSpecial) {
                score += 5;
            }
            
            //If password has all 4 types of characters, give extra points
            if (hasUpper && hasLower && hasNum && hasSpecial) {
                score += 10;
            }
            
            //If password has only 2 types of character, take away points
            if (hasUpper && hasLower && !hasNum && !hasSpecial) {
                score -= 5;
            }
            
            if (hasNum && !(hasLower || hasUpper || hasSpecial)) {
                score -= 5;
            }
            
            if (hasSpecial && !(hasLower || hasUpper || hasNum)) {
                score -= 5;
            }
            
            return score;
        }
    }
}