using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
namespace System.Web.Mvc.Html //<– Note this namespace!
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString SVG(this HtmlHelper htmlHelper, string path, object htmlAttributes = null)
        {
            Dictionary<String, Object> attributes = new Dictionary<String, Object>();
            var fullPath = HttpContext.Current.Server.MapPath(path);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fullPath);
            string xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XmlSchema schema = new XmlSchema();
            schema.Namespaces.Add("xsi", xsi);
            if (htmlAttributes != null)
            {

                PropertyInfo[] properties = htmlAttributes.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in properties)
                {
                    if (xmlDoc.DocumentElement.Attributes[propertyInfo.Name] != null)
                    {
                        xmlDoc.DocumentElement.Attributes[propertyInfo.Name].Value =
                            (string)propertyInfo.GetValue(htmlAttributes, null);
                    }
                    else
                    {
                        XmlAttribute xsiNil = xmlDoc.CreateAttribute(propertyInfo.Name, xsi);
                        xsiNil.Value = (string)propertyInfo.GetValue(htmlAttributes, null);
                        xmlDoc.DocumentElement.Attributes.Append(xsiNil);
                    }
                }
            }
            return new MvcHtmlString(xmlDoc.OuterXml);
        }
    }
}