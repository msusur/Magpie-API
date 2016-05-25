using Magpie.Library.Parser;
using Xunit;

namespace Magpie.Library.Tests
{
    public class HtmlParserTests
    {
        // ReSharper disable once ClassNeverInstantiated.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public class ToMapModel
        {

        }

        [Fact]
        public void T()
        {
            string html = "";
            HtmlParser parser = new HtmlParser(html);
            var parseResponse = parser.ParseModel<ToMapModel>();
        }
    }
}