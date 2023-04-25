using MessageLogger;


Console.WriteLine("Welcome to Message Logger!");
var messageManager = new MessageManager();
var userInput = "";
Console.WriteLine("Let's create a user profile for you.");
User currentUser = CreateUserFromInput();
messageManager.Users.Add(currentUser);

while(userInput != "quit")
{
    //Continously Adds Messages for Logged In User
    if (currentUser != null)
    {
        Console.WriteLine("To log out of your user profile, enter 'log out'. To quit the application, enter 'quit'");
        MessageAdder(userInput, currentUser);
        currentUser = null;
    }

    //If no one is logged in
    else if (currentUser == null)
    {

        Console.WriteLine("Would you like to log in to a 'new' or 'existing' user?");
        userInput = Console.ReadLine();
        
        //create and log in new user
        if (userInput == "new")
        {
            currentUser = NewUser(currentUser, messageManager);
        }
        //log in existing user
        else if (userInput == "existing")
        {
            currentUser = ExistingUser(userInput, messageManager, currentUser);
        }
    }
}
messageManager.PrintTotalMessages();


static User CreateUserFromInput()
{
    //Creates a User object from console input
    Console.WriteLine("What is your name?");
    var name = Console.ReadLine();
    Console.WriteLine("What is your username?(one word no spaces!): ");
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
    Console.WriteLine("What is your username?: ");
    userInput = Console.ReadLine();
    foreach (var existingUser in messageManager.Users)
    {
        if (existingUser.UserName == userInput)
        {
            return existingUser;
        }
    }
    return currentUser = null;
}
static void MessageAdder(string userInput, User currentUser)
{
    //Continously add messages until user decides to log out or quit
    while (userInput != "quit" && userInput != "log out")
    {
        Console.Write("Add a message: ");
        userInput = Console.ReadLine();
        if (userInput != "quit" && userInput != "log out")
        {
            currentUser.UserMessages.Add(new Message(userInput));
        }
        foreach (var message in currentUser.UserMessages)
        {
            Console.WriteLine($"{currentUser.Name} {message.CreatedAt.ToShortTimeString()}: {message.Content}");
        }
        if (userInput == "log out")
        {
            return;
        }
    }
}

