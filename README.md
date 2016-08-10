# Magpie-API

Magpie is a basic web content to model binder. Model binding properties are defined as attributes and binded using css selectors. 

Sample model implementation
```csharp

        [CollectionBinding(Selector = ".list-items li")] // meaning that there might be more than one item is present.
        public class DetailModel
        {
            [AttributeBinding(Selector = "span.product-name", AttributeName = "product-name")] // binds from a html attribute named product-name.
            public string Name { get; set; }

            [InnerTextBinding(Selector = "span.product-price")] // binds from the inner text.
            public string Price { get; set; }
        }
```

Usage of crawler
```csharp
        var crawler = new Crawler(); // initialise the crawler instance
        var parseResponse = await crawler.Crawl<DetailModel>("http://localhost:9090/test.html"); // start binding from the html page to the DetailModel
        var parseCollection = await crawler.CrawlCollection<DetailModel>("http://localhost:9090/test.html"); // binds into a collection of the model.
```

# Next Steps

Project is now idle and meant to be added to nuget but unfortunately I don't have much time. But anyone who has time, please send your pull requests!