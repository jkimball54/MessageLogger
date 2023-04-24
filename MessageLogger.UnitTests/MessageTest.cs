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
            //Assert
            Assert.Equal("Test!", messageString);
            Assert.IsType<DateTime>(messageDateTime);
        }
    }
}