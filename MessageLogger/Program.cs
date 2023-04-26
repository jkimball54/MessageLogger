using MessageLogger;
using System.Diagnostics;

var messageManager = new MessageManager();
var userInput = "";

Prompt("entry");
User currentUser = CreateUserFromInput();
messageManager.Users.Add(currentUser);

while(userInput != "quit")
{
    //Continously Adds Messages for Logged In User
    if (currentUser != null)
    {
        MessageAdder(userInput, currentUser);
        currentUser = null;
    }

    //If no one is logged in
    else if (currentUser == null)
    {
        Prompt("new-or-existing");
        userInput = Console.ReadLine();
        
        //create and log in new user
        if (userInput == "new")
        {
            currentUser = NewUser(currentUser, messageManager);
        }
        //log in existing user
        else if (userInput == "existing")
        {
            messageManager.ListAllUsers();
            currentUser = ExistingUser(userInput, messageManager, currentUser);
        }
    }
}
messageManager.PrintTotalMessages();


static User CreateUserFromInput()
{
    //Creates a User object from console input
    Prompt("get-name");
    var name = Console.ReadLine();
    Prompt("get-username");
    var username = Console.ReadLine();
    return new User(name, username);
}
static User NewUser(User currentUser, MessageManager messageManager)
{
    //Create new User from console input and add to messageManager
    currentUser = CreateUserFromInput();
    messageManager.Users.Add(currentUser);
    return currentUser;
}
static User ExistingUser(string userInput, MessageManager messageManager, User currentUser)
{
    //Find existing user by username and return it to be the new currentUser, if none return null
    Prompt("get-username");
    userInput = Console.ReadLine();
    foreach (var existingUser in messageManager.Users)
    {
        if (existingUser.UserName == userInput)
        {
            return existingUser;
        }
        else
        {
            Prompt("user-not-found");
        }
    }
    return currentUser = null;
}
static void MessageAdder(string userInput, User currentUser)
{
    //Continously add messages until user decides to log out or quit
    while (userInput != "quit" && userInput != "log out")
    {
        Console.Clear();
        Prompt("user-controls");
        foreach (var message in currentUser.UserMessages)
        {
            Console.WriteLine($"{currentUser.Name} {message.CreatedAt.ToShortTimeString()}: {message.Content}");
        }
        Prompt("add-message");
        userInput = Console.ReadLine();
        if (userInput != "quit" && userInput != "log out")
        {
            currentUser.UserMessages.Add(new Message(userInput));
        }
        if (userInput == "log out")
        {
            return;
        }
    }
}
static void Prompt(string key)
{
    switch (key)
    {
        case "entry":
            promptGray();
            Console.WriteLine("     Welcome to Message Logger!     ");
            Console.WriteLine("Let's create a user profile for you.\n");
            resetColor();
            break;
        case "user-controls":
            promptGray();
            Console.WriteLine("To log out of your user profile, enter 'log out'. To quit the application, enter 'quit'");
            resetColor();
            break;
        case "add-message":
            responseWhite();
            Console.Write("Add a message:");
            resetColor();
            break;
        case "get-name":
            responseWhite();
            Console.Write("What is your name?:");
            resetColor();
            break;
        case "get-username":
            responseWhite();
            Console.Write("What is your username?:");
            resetColor();
            break;
        case "new-or-existing":
            Console.Clear();
            responseWhite();
            Console.WriteLine("Would you like to log in to a 'new' or 'existing' user?");
            resetColor();
            break;
        case "user-not-found":
            Console.Clear();
            alertRed();
            Console.WriteLine("              Username not found!              \a\n");
            promptGray();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            resetColor();
            break;
    }
    
    
    //Color Scheming
    void promptGray()
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;
    }
    void responseWhite()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
    }
    void resetColor()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }
    void alertRed()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
    }
}







//Input Validation
//console.readline() possibly takes numbers as null
// https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-8.0
// https://regexr.com
