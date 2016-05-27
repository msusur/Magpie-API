using System.Collections.Generic;
using System.Threading.Tasks;
using Magpie.Library.Http;
using Magpie.Library.Parsers;

namespace Magpie.Library
{
    public sealed class Crawler
    {
        public async Task<TModel> Crawl<TModel>(string url)
            where TModel : new()
        {
            return await HttpCall.To(url).LoadPage().ContinueWith<TModel>(ContinuationFunction<TModel>);
        }

        public async Task<IList<TModel>> CrawlCollection<TModel>(string url)
            where TModel : new()
        {
            return await HttpCall.To(url).LoadPage().ContinueWith<IList<TModel>>(CollectionContinuationFunction<TModel>);
        }

        private IList<TModel> CollectionContinuationFunction<TModel>(Task<HttpResponse> responseTask)
            where TModel : new()
        {
            var parser = new HtmlParser(responseTask.Result.ResponseString);

            return parser.ParseModelCollection<TModel>();
        }

        private TModel ContinuationFunction<TModel>(Task<HttpResponse> responseTask)
            where TModel : new()
        {
            var parser = new HtmlParser(responseTask.Result.ResponseString);

            return parser.ParseModel<TModel>();
        }


        public async Task<GenericModel> Crawl(string url, ParseModel model)
        {
            return await HttpCall.To(url).LoadPage().ContinueWith<GenericModel>(t => CrawlGenericItem(t, model));
        }

        private GenericModel CrawlGenericItem(Task<HttpResponse> obj, ParseModel model)
        {
            var parser = new HtmlParser(obj.Result.ResponseString);

            return parser.ParseModel<GenericModel>(model);
        }
    }
}