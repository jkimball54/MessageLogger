namespace MessageLogger.UnitTests
{
    public class MessageTest
    {
        [Fact]
        public void Message_Constructor_CreatesMessageObject()
        {
            //Arrange
            Message testMessage = new Message("Test!");
            //Act
            var messageString = testMessage.Content;
            var messageDateTime = testMessage.CreatedAt;
            var nowDateTime = DateTime.Now.ToString("h:mm tt"); ;
            //Assert
            Assert.Equal("Test!", messageString);
            Assert.Equal(nowDateTime, messageDateTime.ToString("h:mm tt"));
            Assert.Equal(nowDateTime, testMessage.formattedTime);

        }
    }
}