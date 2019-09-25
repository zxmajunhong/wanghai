using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Web;
using System.IO;
namespace Common
{
    public class Xml
    {
        /// <summary>
        /// 读取XML
        /// </summary>
        /// <param name="XmlPath"></param>
        /// <returns></returns>
        public static DataSet GetXml(string XmlPath)
        {
            DataSet ds = new DataSet();
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("/" + XmlPath));
            StringReader sreader = new StringReader(doc.InnerXml);
            XmlTextReader xtreader = new XmlTextReader(sreader);
            ds.ReadXml(xtreader);
            return ds;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="XmlPath"></param>
        /// <param name="id"></param>
        public static void DeleteXml(string XmlPath,string id)
        {
            //通过ID获取信息
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("/" + XmlPath));
            XmlNode root = doc.SelectSingleNode("root");
            foreach (XmlNode student in root.ChildNodes)
            {
                XmlNode node_id = student.FirstChild;
                if (node_id.InnerText == id)
                {
                    student.ParentNode.RemoveChild(student);
                }
            }
            doc.Save(HttpContext.Current.Server.MapPath("/" + XmlPath));
        }
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="XmlPath"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetModel(string XmlPath, string id)
        {
            string entity = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("/" + XmlPath));
            XmlNode root = doc.SelectSingleNode("root");

            foreach (XmlNode student in root.ChildNodes)
            {
                XmlNode temp_node = student.FirstChild;
                if (temp_node.InnerText == id)
                {
                    foreach (XmlNode item in student.ChildNodes)
                    {
                        entity += item.InnerText + "|";
                    }
                    entity = entity.Substring(0, entity.Length - 1);
                    break;
                }
            }
            return entity;
        }
        public static  void UpdateXml(string XmlPath,string id,string[] ItemName,string[] Values)
        {
            //通过ID获取信息，然后更改信息
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("/" + XmlPath));
            XmlNode root = doc.SelectSingleNode("root");
            foreach (XmlNode student in root.ChildNodes)
            {
                XmlNode temp_node = student.FirstChild;
                if (temp_node.InnerText == id)
                {
                    for (int i = 0; i < ItemName.Length; i++)
                    {
                        student.SelectSingleNode(ItemName[i]).InnerText = Values[i];
                    }
                    doc.Save(HttpContext.Current.Server.MapPath("/" + XmlPath));
                    break;
                }
            }

        }
        public static void AddXml(string XmlPath,string NodeName,string[] ItemName,string[] Values )
        {
         
            //在第一个前面插入一条信息
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("/" + XmlPath));
            XmlNode root = doc.SelectSingleNode("root");
            XmlElement student = doc.CreateElement(NodeName);

            int id = root.ChildNodes.Count + 1;

            student.SetAttribute("ids",id.ToString());

            XmlElement ele_id = doc.CreateElement("id");
            ele_id.InnerText = id.ToString();
            student.AppendChild(ele_id);

            for (int i = 0; i < ItemName.Length; i++)
            {
                XmlElement ele_name = doc.CreateElement(ItemName[i]);
                ele_name.InnerText = Values[i];
                student.AppendChild(ele_name);
            }
            root.InsertBefore(student, root.FirstChild);

            doc.Save(HttpContext.Current.Server.MapPath("/"+XmlPath));

        }
    }
}
