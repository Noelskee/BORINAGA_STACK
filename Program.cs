using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BORINAGA_STACK
{
    internal class Program
    {
        static readonly HashSet<string> AsianCountries = new HashSet<string>
        {
            "Afghanistan", "Armenia", "Azerbaijan", "Bahrain", "Bangladesh",
            "Bhutan", "Brunei", "Cambodia", "China", "Cyprus", "Georgia",
            "India", "Indonesia", "Iran", "Iraq", "Israel", "Japan",
            "Jordan", "Kazakhstan", "Kuwait", "Kyrgyzstan", "Laos",
            "Lebanon", "Malaysia", "Maldives", "Mongolia", "Myanmar",
            "Nepal", "North Korea", "Oman", "Pakistan", "Palestine",
            "Philippines", "Qatar", "Saudi Arabia", "Singapore", "South Korea",
            "Sri Lanka", "Syria", "Tajikistan", "Thailand", "Timor-Leste",
            "Turkmenistan", "United Arab Emirates", "Uzbekistan", "Vietnam", "Yemen","Russia","India", 
        };
        static void Main(string[] args)
        {
                // Noel Earl G. Borinaga
                // IT 404A
                // Maam Farah Diva Alvarado
                // Activity 7 Using Stack Method

                Queue<string> countries = new Queue<string>();
                string input;
                int count = 0;
            Console.Write("Loading");
            ShowLoadingAnimation();

            Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter Asian Countries (type 'P' to Stop): ");

            int index = 1;
                // Input loop for up to 10 countries
                while (count < 10)
                {
                    Console.Write($"Enter your {index} country: ");
               
                input = Console.ReadLine();

                    if (input.ToLower() == "p")
                    {
                        break;
                    }

                    // Check if the input is empty
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error! Input cannot be empty. Please try again!");
                        continue; // Skip the rest of the loop
                    }

                    // Check if the country is valid
                    if (AsianCountries.Contains(input))
                    {
                        countries.Enqueue(input);
                        count++;
                        index++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error: '{input}' is not an Asian country.");
                    
                    }

                }
            

                // Main menu for stack functionality
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. Add another country");
                    Console.WriteLine("2. Remove a country");
                    Console.WriteLine("3. Peek at the top country");
                    Console.WriteLine("4. Check if stack is empty");
                    Console.WriteLine("5. Get the size of the stack");
                    Console.WriteLine("6. Display the recent contents of the stack");
                    Console.WriteLine("7. View the Front");
                    Console.WriteLine("8. View the Rear");
                    Console.WriteLine("9. Exit");
                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter the country to add: ");
                            input = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(input))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error! Input cannot be empty. Please try again!");
                            continue;
                            }
                            else if (AsianCountries.Contains(input))
                            {
                                countries.Enqueue(input);
                                Console.WriteLine($"Country '{input}' added.");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Error: '{input}' is not an Asian country.");
                            continue;
                            }
                            break;
                        case "2":
                            if (countries.Count > 0)
                            {
                                input = countries.Dequeue(); // Remove the top country from the stack
                                Console.WriteLine($"Country '{input}' removed.");
                            }
                            else
                            {
                                Console.WriteLine("No countries to remove.");
                            }
                            break;
                        case "3":
                        
                            if (countries.Count > 0)
                            {
                                input = countries.Peek(); // Get the top country without removing it
                                Console.WriteLine($"Top country in the stack: '{input}'");
                            }
                            else
                            {
                                Console.WriteLine("The stack is empty.");
                            }
                            break;
                        case "4":
                            Console.WriteLine(countries.Count == 0 ? "The stack is True." : "The stack is False.");
                            break;
                        case "5":
                            Console.WriteLine($"Size of the stack: {countries.Count}");
                            break;
                        case "6":
                            Console.WriteLine("Current list of countries (top to bottom):");
                            DisplayStack(countries);
                            break;
                        case "7":
                            if(countries.Count > 0)
                        {
                            string front = countries.First();
                            Console.WriteLine("Our Front is " + front);
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty");
                        }
                        break;

                    case "8":
                        if(countries.Count > 0)
                        {
                            string rear = countries.Last();
                            Console.WriteLine("Our Rear is " + rear);
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty");
                        }
                        break;

                        case "9":
                                return; // Exit the program
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid option. Please try again.");
                                break;

                            }
                
                }
                

            

           
        }
        static void DisplayStack(Queue<string> stack)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (stack.Count == 0)
            {
                Console.WriteLine("The stack is empty.");
                return;
            }

            // Display elements in the stack (top to bottom)
            foreach (string country in stack)
            {
                Console.WriteLine(" " + country);
            }
            Console.WriteLine();
        }
        static void ShowLoadingAnimation()
        {
            string[] animationChars = { "|", "/", "-", "\\" };
            for (int i = 0; i < 100; i++) // Adjust the loop count for longer or shorter loading time
            {
                Console.Write(animationChars[i % animationChars.Length]);
                Thread.Sleep(100); // Adjust the sleep time for faster or slower animation
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
            Console.Clear();
            Console.WriteLine("Loading Complete");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
