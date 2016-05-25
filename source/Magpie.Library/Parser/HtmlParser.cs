using System.Collections.Generic;

namespace Magpie.Library.Parser
{
    public class HtmlParser
    {
        private readonly string _inputHtml;

        public HtmlParser(string inputHtml)
        {
            _inputHtml = inputHtml;
        }

        public IList<TModelType> ParseModelCollection<TModelType>()
        {
            ParseCommand.Create().MapTo<TModelType>().ParseAsList();
            throw new System.NotImplementedException();
        }

        public TModelType ParseModel<TModelType>()
        {
            ParseCommand.Create().MapTo<TModelType>().ParseAsSingleObject();
            return default(TModelType);
        }
    }
}