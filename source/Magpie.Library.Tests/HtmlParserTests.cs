using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using Magpie.Library.Attributes;
using Magpie.Library.Parsers;
using Xunit;

namespace Magpie.Library.Tests
{
    public class HtmlParserTests
    {
        // ReSharper disable once ClassNeverInstantiated.Global
        // ReSharper disable once MemberCanBePrivate.Global
        [CollectionBinding(Selector = ".list-items")]
        public class DetailModel
        {
            [AttributeBinding(Selector = "div.product-name", AttributeName = "product-name")]
            public string Name { get; set; }

            [InnerTextBinding(Selector = "div.product-price")]
            public string Price { get; set; }
        }

        private string LoadSampleHtml(string fileName)
        {
            fileName = $"Magpie.Library.Tests.HtmlTestResources.{fileName}.html";
            using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName))
            {
                if (resourceStream == null)
                {
                    throw new MissingManifestResourceException($"{fileName} not found.");
                }

                using (StreamReader reader = new StreamReader(resourceStream, Encoding.ASCII))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        [Fact]
        public void ShouldParseSingleModel()
        {
            string html = LoadSampleHtml("BasicItem");

            HtmlParser parser = new HtmlParser(html);
            var parseResponse = parser.ParseModel<DetailModel>();

            Assert.Equal(parseResponse.Name, "OO nice!");
            Assert.Equal(parseResponse.Price, "12");
        }

        [Fact]
        public void ShouldParseAListOfModel()
        {
            string html = LoadSampleHtml("BasicList");
            HtmlParser parser = new HtmlParser(html);
            var parseResponse = parser.ParseModelCollection<DetailModel>();
            Assert.Equal(4, parseResponse.Count);

            Assert.Equal("item 1", parseResponse[0].Name);
            Assert.Equal("12", parseResponse[0].Price);
            Assert.Equal("item 2", parseResponse[1].Name);
            Assert.Equal("32", parseResponse[1].Price);
            Assert.Equal("item 3", parseResponse[2].Name);
            Assert.Equal("44", parseResponse[2].Price);
            Assert.Equal("item 4", parseResponse[3].Name);
            Assert.Equal("55", parseResponse[3].Price);
        }
    }
}