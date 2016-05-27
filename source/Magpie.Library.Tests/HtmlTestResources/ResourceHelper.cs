using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;

namespace Magpie.Library.Tests.HtmlTestResources
{
    internal static class ResourceHelper
    {
        public static string LoadSampleHtml(string fileName)
        {
            fileName = $"Magpie.Library.Tests.HtmlTestResources.{fileName}.html";
            using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName))
            {
                if (resourceStream == null)
                {
                    throw new MissingManifestResourceException($"{fileName} not found.");
                }

                using (StreamReader reader = new StreamReader(resourceStream, Encoding.ASCII))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
