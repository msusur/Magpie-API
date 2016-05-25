using Xunit;

namespace Magpie.Library.Tests
{
    public class HtmlParserTests
    {
        [Fact]
        public void T()
        {
            HtmlParser parser = new HtmlParser();
            var command = ParseCommand.Create();
            parser.ParseModel(command);
        }
    }

    public class HtmlParser
    {
        public void ParseModel(ParseCommand parseCommand)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ParseCommand
    {
        ParseCommand()
        {
            
        }

        public static ParseCommand Create()
        {
            return new ParseCommand();    
        }
    }
}