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

        public CrawlerTests()
        {

        }

        [Fact]
        public void ShouldCrawlSingleObject()
        {
            using (var http = new BasicHttpServer("9090", l => ResourceHelper.LoadSampleHtml("BasicItem")))
            {
                var crawler = new Crawler();
                var result = crawler.Crawl<DetailModel>("http://localhost:9090/test.html");
                result.Wait();
                var parseResponse = result.Result;
                Assert.Equal(parseResponse.Name, "item 1");
                Assert.Equal(parseResponse.Price, "12");
            }
        }
    }
}