[![Build Status](https://travis-ci.org/msusur/Magpie-API.svg?branch=master)](https://travis-ci.org/msusur/Magpie-API)

# Magpie-API

Magpie is a basic web content to model binder. Model binding properties are defined as attributes and binded using css selectors. 

Building the source
========

Project uses Grunt to build the application therefore you may need to install node and npm to your environment. Then simply call the following commands to build the code.

```sh
 npm install
```

```sh
 grunt
```

If you want to build the application using dotnet you need to,
- Restore and build the library first
```sh
dotnet restore source/Magpie.Library && dotnet build source/Magpie.Library
```

- Restore and build the tests
```sh
dotnet restore tests/Magpie.Library.Tests && dotnet build tests/Magpie.Library.Tests/
```

- Run the tests
```sh
dotnet test tests/Magpie.Library.Tests/
```


Sample model implementation
==========================
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

# Further Notes

Project now migrated to .Net Core, if you want to checkout the .Net 4.5.2 version checkout to [dotnet452 branch](https://github.com/msusur/Magpie-API/tree/Dotnet452).
