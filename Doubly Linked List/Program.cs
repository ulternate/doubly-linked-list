using System;
using System.Threading;

// Created: Daniel Swain
// Date: 09/09/2016
//
// The program to allow a user to create a Doubly Linked list and perform add, edit, find and delete actions.

namespace Doubly_Linked_List
{
    class Program
    {
        // Class Variables
        static string welcomeMessage = "Welcome to my Doubly Linked List implementation in C#. Please choose the operation you want to complete.\n";
        static string[] options = { "Add a node to the list", "Search for a node (by key) in the list.", "Edit a node in the list", "Remove node from the list", "View the list", "Exit the program"};
        static bool repeat = true;
        static List list = null;

        static void Main(string[] args)
        {
            // Greet the user and display the program options for them until the user specifically chooses to exit the program.
            Console.WriteLine(welcomeMessage);
            // Loop the options forever until the user chooses to exit.
            while (repeat)
            {
                // Print the options for the user.
                printOptions();
                // Get and handle the input from the user.
                getInput();
            }
        }

        // Print the options for the user to pick from.
        static void printOptions()
        {
            int count = 1;
            foreach (string option in options)
            {
                Console.WriteLine("{0}: {1}", count, option);
                count++;
            }
        }

        // Get the user's input choice and handle the input.
        static void getInput()
        {
            // Print out helper text to prompt the user for the input.
            Console.Write("\nChoice: ");
            string inputString = Console.ReadLine();
            // Print out a blank line for formatting.
            Console.WriteLine();

            // Parse the inputString to an int and handle the input.
            switch (inputString)
            {
                case "1":
                    // User wishes to add a node to the list.
                    handleAddingOfNode();
                    break;

                case "2":
                    // User wishes to search for a node in the list.
                    //handleListSearch();
                    break;

                case "3":
                    // User wishes to edit a node in the list.
                    //handleEditingNode();
                    break;

                case "4":
                    // User wishes to remove a node from the list.
                    //handleRemovingNode();
                    break;

                case "5":
                    // User wishes to display the list.
                    printList();
                    break;

                case "6":
                    // User wishes to exit the program, show the choice and then exit the program by setting repeat to false.
                    exitProgram();
                    break;

                default:
                    // Unable to identify the users choice.
                    Console.WriteLine("Please enter a number representing the option you wish to complete.");
                    break;
            }
        }

        // The user wants to add a node to the list, this method handles all the actions and inputs associated with that.
        // No duplicates allowed.
        static void handleAddingOfNode()
        {
            Console.WriteLine("Please enter a number you would like to add to the doubly linked list.");

            // Get the user's desired node data.
            Console.Write("\nNumber to add: ");

            // Parse the user's input into an integer, otherwise return a warning.
            int usersKeyInput = parseUsersInputToInt(Console.ReadLine());
            // Get the user's data for the node as well
            Console.Write("\nData for the node: ");
            string usersNodeData = Console.ReadLine();

            if (usersKeyInput != -1)
            {
                // The input was a valid string integer representation and could be parsed.
                // Initialise our tree if it doesn't exist yet.
                if (list == null)
                {
                    list = new List();
                }
                // Try and add the user's input to the tree as a new node. Will fail if a node with the key already exists.
                Node nodeToBeAdded = new Node(usersKeyInput, usersNodeData);
                if (list.findNode(list, nodeToBeAdded.key) != null)
                {
                    // Node already exists.
                    Console.WriteLine("\nCouldn't add [{0}, \"{1}\"] to the list, as a node with key {0} already exists.\n", usersKeyInput, usersNodeData);
                }
                else
                {
                    list.insertAtEnd(list, nodeToBeAdded);
                    // Successfully added the node to the list.
                    Console.WriteLine("\nSuccessfully added [{0}, \"{1}\"] to the list.\n", usersKeyInput, usersNodeData);
                }
            }
            else
            {
                // Couldn't parse the number into an int.
                Console.WriteLine("\nCouldn't get a valid number from what you entered.\n");
            }
        }

        // The user wasnt to print/visualise the list, this method will visualise the current list for the user.
        static void printList()
        {
            // List doesn't exist
            if ( list == null)
            {
                Console.WriteLine("\nYou haven't initialised a doubly linked tree, please add a number and try and view it again.\n");
                return;
            }

            // List exists, so let's print it either using forward or backwards traversal.
            // Get the user's desired traversal method.
            Console.WriteLine("Please choose the desired list traversal method.");
            Console.WriteLine("1. Forward.");
            Console.WriteLine("2. Backwards.");
            Console.Write("\nMethod: ");
            int choice = -1;
            // Get the input from the user with their traversal choice.
            string traversalChoice = Console.ReadLine();
            // Parse the choice into an int.
            if (Int32.TryParse(traversalChoice, out choice))
            {
                // Use the list traversal method to traverse and print the list.
                list.traverseAndPrintList(list, choice);
                // Print a blank line to the console to properly format the output before asking the user what to do again.
                Console.WriteLine("\n");
            }
            else
            {
                // The input couldn't be parsed into an int from the user's input.
                Console.WriteLine("\nCouldn't get a number from the string ({0}) that you entered.\n", traversalChoice);
            }

        }
        // The user has chosen to exit the program, handle this action in this method.
        static void exitProgram()
        {
            Console.WriteLine("Exiting...");
            // Use a delay to allow the application to notify the user.
            Thread.Sleep(1000);
            // Set the repeat variable to false so the while loop running the program will exit.
            repeat = false;
        }

        // Helper class to parse the user's input and return an int if possible.
        static int parseUsersInputToInt(string inputString)
        {
            int inputNumber = 0;
            if (Int32.TryParse(inputString, out inputNumber))
            {
                // input string could be parsed to a number, return it to the calling method.
                return inputNumber;
            }
            else
            {
                // Input string couldn't be parsed to a number, return -1 to the calling method.
                return -1;
            }
        }
    }
}
