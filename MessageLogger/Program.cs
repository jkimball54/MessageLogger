using MessageLogger;


Console.WriteLine("Welcome to Message Logger!");

var usrInput = "";
var messageList = new List<string>();
while (usrInput != "quit")
{
    
    Console.Write("Add a message (or 'quit' to exit): ");
    usrInput = Console.ReadLine();

    Message usrMessage = new Message(usrInput);
    
    messageList.Add($"{usrMessage.formattedTime}: {usrMessage.Content}");
    messageList.ForEach(Console.WriteLine);
}