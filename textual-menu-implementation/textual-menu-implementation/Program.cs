using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace textual_menu_implementation
{
    class Program
    {
        // optionList instantiated 
        public static List<Option> optionList;
        public static void Main(string[] args)
        {
            // creates the options list that should be setup on the menu
            optionList = new List<Option>
            {
                new Option("Option 01", () => WriteMessage("Option 01 is chosen")),
                new Option("Option 02", () => WriteMessage("Option 02 is chosen")),
                new Option("Option 03", () => WriteMessage("Option 03 is chosen")),
                new Option("Option 04", () => WriteMessage("Option 04 is chosen")),
                new Option("Option 05", () => WriteMessage("Option 05 is chosen")),
            };

            // set the initial index value 
            int index = 0;

            renderMenu(optionList, optionList[index]);
            ConsoleKeyInfo keyinfo;

            do
            {
                keyinfo = Console.ReadKey();
                switch (keyinfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        if(index + 1 < optionList.Count)
                        {
                            index++;
                            renderMenu(optionList, optionList[index]);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if(index - 1 >= 0)
                        {
                            index--;
                            renderMenu(optionList, optionList[index]);
                        }
                        break;
                    case ConsoleKey.Enter:
                        optionList[index].Selected.Invoke();
                        index = 0;
                        break;
                }

            } while (keyinfo.Key != ConsoleKey.X);

            static void WriteMessage(string msg)
            {
                Console.Clear();
                Console.WriteLine(msg);
                Thread.Sleep(3000);
                renderMenu(optionList, optionList.First());
            }

            static void renderMenu(List<Option> optionList, Option selectedOption)
            {
                Console.Clear();
                foreach (Option option in optionList)
                {
                    if (option == selectedOption)
                        Console.Write(">> ");
                    else
                        Console.Write("  ");

                    Console.WriteLine(option.Name);
                }
            }
        }

    }
}
