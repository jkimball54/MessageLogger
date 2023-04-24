using MessageLogger;


Console.WriteLine("Welcome to Message Logger!");


var userList = new List<User>();
var userInput = "";
var loggedIn = true;


Console.WriteLine("Let's create a user profile for you.");
User user = CreateUserFromInput();
userList.Add(user);

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
                user.UserMessages.Add(new Message(userInput));
            }
            foreach (var message in user.UserMessages)
            {
                Console.WriteLine($"{user.Name} {message.CreatedAt.ToShortTimeString()}: {message.Content}");
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
            user = CreateUserFromInput();
            userList.Add(user);
            loggedIn = true;
        }

        else if (userInput == "existing")
        {

            Console.WriteLine("What is your username?: ");
            userInput = Console.ReadLine();
            foreach(var existingUser in userList)
            {

                if (existingUser.UserName == userInput)
                {
                    user = existingUser;
                    loggedIn = true;
                }

            }

        }

    }
}
foreach(var existingUser in userList)
{
    Console.WriteLine($"{existingUser.Name} wrote {existingUser.UserMessages.Count()} messages.");
}






static User CreateUserFromInput()
{
    Console.WriteLine("What is your name?");
    var name = Console.ReadLine();
    Console.WriteLine("What is your username?(one word no spaces!): ");
    var username = Console.ReadLine();

    return new User(name, username);
}