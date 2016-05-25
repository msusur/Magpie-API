using System;

namespace Magpie.Library.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class AttributeBindingAttribute : HtmlBindingAttribute
    {
        public string AttributeName { get; set; }
    }
}