using FrameWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FrameWork.WeChat
{
    /// <summary>
    /// XML扩展
    /// </summary>
    public class XmlEX
    {
        public static XMLModel ResolveXML(XDocument xmldoc)
        {

            XMLModel model = new XMLModel();
            XElement xmlele = xmldoc.Root;
            var ps = typeof(XMLModel).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            for (var i = 0; i < ps.Length; i++)
            {
                var a = xmlele.Element(ps[i].Name);
                try
                {
                    if (a != null)
                    {
                        ps[i].SetValue(model, Convert.ChangeType(a.Value, ps[i].PropertyType));
                    }
                }
                catch (Exception ex)
                {
                    var aa = a;
                    string msg = ex.Message + "！！具体:" + ex.InnerException;
                }
            }
            return model;

        }
    }
}
