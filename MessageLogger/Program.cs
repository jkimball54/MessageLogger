using MessageLogger;


Console.WriteLine("Welcome to Message Logger!");



var messageManager = new MessageManager();
var userInput = "";
Console.WriteLine("Let's create a user profile for you.");
User currentUser = CreateUserFromInput();
var loggedIn = true;
messageManager.Users.Add(currentUser);

while(userInput != "quit")
{

    if (loggedIn)
    {
        Console.WriteLine("To log out of your user profile, enter 'log out'. To quit the application, enter 'quit'");
        while (userInput != "quit" && userInput != "log out")
        {
            Console.WriteLine("Add a message: ");
            userInput = Console.ReadLine();
            if (userInput != "quit" && userInput != "log out")
            {
                currentUser.UserMessages.Add(new Message(userInput));
            }
            foreach (var message in currentUser.UserMessages)
            {
                Console.WriteLine($"{currentUser.Name} {message.CreatedAt.ToShortTimeString()}: {message.Content}");
            }
            if(userInput == "log out")
            {
                loggedIn = false;
            }
        }

    }
    else if (!loggedIn)
    {
        Console.WriteLine("Would you like to log in to a 'new' or 'existing' user?");
        userInput = Console.ReadLine();

        if (userInput == "new")
        {
            currentUser = CreateUserFromInput();
            messageManager.Users.Add(currentUser);
            loggedIn = true;
        }

        else if (userInput == "existing")
        {

            Console.WriteLine("What is your username?: ");
            userInput = Console.ReadLine();
            foreach(var existingUser in messageManager.Users)
            {

                if (existingUser.UserName == userInput)
                {
                    currentUser = existingUser;
                    loggedIn = true;
                }

            }

        }

    }
}

//Put in MessageManager Class as Method return void
foreach(var existingUser in messageManager.Users)
{
    Console.WriteLine($"{existingUser.Name} wrote {existingUser.UserMessages.Count()} messages.");
}





//Leave here
static User CreateUserFromInput()
{
    Console.WriteLine("What is your name?");
    var name = Console.ReadLine();
    Console.WriteLine("What is your username?(one word no spaces!): ");
    var username = Console.ReadLine();

    return new User(name, username);
}


//- Abstraction TODO -

//Put LoggedIn as a bool property somewhere??

//NOT LOGGED IN
//method for handle new user
//method for handle existing

//LOGGED IN
//method for logged in user to add messages (prompt && do while)