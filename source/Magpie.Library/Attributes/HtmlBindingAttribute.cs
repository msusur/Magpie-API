using System;

namespace Magpie.Library.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class HtmlBindingAttribute : Attribute
    {
        public string Selector { get; set; }
    }
}