namespace Magpie.Library.Parsers
{
    internal sealed class MultipleParseModel : ParseModel
    {
        public string Selector { get; private set; }

        public MultipleParseModel(string selector)
        {
            Selector = selector;
        }
    }
}