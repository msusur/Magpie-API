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
        public class DetailModel
        {
            [AttributeBinding(Selector = "div.product-name", AttributeName = "class")]
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
            string html = LoadSampleHtml("SampleItemHtml");

            HtmlParser parser = new HtmlParser(html);
            var parseResponse = parser.ParseModel<DetailModel>();
        }

        [Fact]
        public void ShouldParseAListOfModel()
        {
            string html = LoadSampleHtml("SampleListHtml");
            HtmlParser parser = new HtmlParser(html);
            var parseResponse = parser.ParseModelCollection<DetailModel>();
        }
    }
}