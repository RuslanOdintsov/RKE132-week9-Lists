﻿string folderPath = @"C:\data";
string fileName = "shoppingList.txt";
string filePath = Path.Combine(folderPath, fileName);
List<string> shoppingList = new List<string>();

if (File.Exists(filePath))
{
    shoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, shoppingList);
}
else
{
    File.Create(filePath).Close();
    Console.WriteLine($"File {fileName} has been created.");
    shoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, shoppingList);
}


static List<string> GetItemsFromUser()
{
    List<string> userList = new List<string>(); 

    while (true)
    {
        Console.WriteLine("Add an item (add)/ or exit (exit)");
        string userChoice = Console.ReadLine();
        if (userChoice == "add")
        {
            Console.WriteLine("Enter an item:");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
        }
        else if (userChoice == "exit")
        {
            Console.WriteLine("Bye!");
            break; 
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }
    }
    return userList;
}

static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();

    int listLength = someList.Count;
    Console.WriteLine($"You have added {listLength} items to your shopping list");

    int i = 1;
    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
}
