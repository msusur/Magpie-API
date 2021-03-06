﻿using Magpie.Library.Attributes;
using Magpie.Library.Parsers;
using Magpie.Library.Tests.HtmlTestResources;
using Xunit;

namespace Magpie.Library.Tests
{
    public class HtmlParserTests
    {
        [CollectionBinding(Selector = ".list-items li")]
        public class DetailModel
        {
            [AttributeBinding(Selector = "span.product-name", AttributeName = "product-name")]
            public string Name { get; set; }

            [InnerTextBinding(Selector = "span.product-price")]
            public string Price { get; set; }
        }

        [Fact]
        public void ShouldParseSingleModel()
        {
            string html = ResourceHelper.LoadSampleHtml("BasicItem");

            HtmlParserModule parser = new HtmlParserModule(html);
            var parseResponse = parser.ParseModel<DetailModel>();

            Assert.Equal(parseResponse.Name, "item 1");
            Assert.Equal(parseResponse.Price, "12");
        }

        [Fact]
        public void ShouldParseAListOfModel()
        {
            string html = ResourceHelper.LoadSampleHtml("BasicList");
            HtmlParserModule parser = new HtmlParserModule(html);
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