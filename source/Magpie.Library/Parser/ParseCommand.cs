using System;

namespace Magpie.Library.Parser
{
    public class ParseCommand
    {
        private Type _toModel;
        public ParseCommandTypes CommandType { get; private set; } = ParseCommandTypes.AsSingleObject;

        ParseCommand()
        {

        }

        public static ParseCommand Create()
        {
            return new ParseCommand();
        }


        internal ParseCommand MapTo<TMapModelType>()
        {
            this._toModel = typeof(TMapModelType);
            return this;
        }

        public ParseCommand ParseAsList()
        {
            CommandType = ParseCommandTypes.AsList;
            return this;
        }

        public ParseCommand ParseAsSingleObject()
        {
            CommandType = ParseCommandTypes.AsSingleObject;
            return this;
        }
    }
}