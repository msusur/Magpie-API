using System;
using System.Net;
using Magpie.Library.Attributes;
using Magpie.Library.Tests.HtmlTestResources;
using Magpie.Library.Tests.HttpServerMock;
using Xunit;

namespace Magpie.Library.Tests
{
    public class CrawlerTests
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
        public async void ShouldCrawlSingleObjectFromBasicHtml()
        {
            using (var http = new BasicHttpServer("9090", l => ResourceHelper.LoadSampleHtml("BasicItem")))
            {
                http.Run();
                var crawler = new Crawler();
                var parseResponse = await crawler.Crawl<DetailModel>("http://localhost:9090/test.html");
                Assert.Equal(parseResponse.Name, "item 1");
                Assert.Equal(parseResponse.Price, "12");
            }
        }

        [Fact]
        public async void ShouldCrawlListObjectFromBasicListHtml()
        {
            using (var http = new BasicHttpServer("9090", l => ResourceHelper.LoadSampleHtml("BasicList")))
            {
                http.Run();
                var crawler = new Crawler();
                var parseResponse = await crawler.CrawlCollection<DetailModel>("http://localhost:9090/test.html");
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
}