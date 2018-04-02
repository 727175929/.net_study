using System;
using System.Xml;
using System.IO;
using System.Windows.Forms;


namespace Xml
{
    public class SaveXmlFile
    {
        string _xmlFilePath = null;
        SafeXmlDocument _xmlDoc = null;
        public string XmlFilePath
        {
            get
            {
                return _xmlFilePath;
            }
            set
            {
                _xmlFilePath = value;
                Reload();
            }
        }
        public SaveXmlFile()
        {
        }
        public SaveXmlFile(string xmlFilePath)
        {
            XmlFilePath = xmlFilePath;
        }

        protected virtual void Reload()
        {
            _xmlDoc = new SafeXmlDocument();
            _xmlDoc.Load(XmlFilePath);
        }
        public virtual void SaveChanges()
        {
            _xmlDoc.Save(XmlFilePath);
        }
        public void SaveXmlNode(string baseNodeName, string nodeName, string nodeValue, string attributeName, string attributeValue)
        {
            var nodeList = _xmlDoc.SelectSingleNode("AppInfo").ChildNodes;
            var isInsertBaseNode = true;
            var isInsertNode = true;
            foreach (XmlNode xn in nodeList)
            {
                if (xn.Name == baseNodeName)
                {
                    foreach (XmlNode xm in xn.ChildNodes)
                    {
                        if (xm.Name == nodeName)
                        {
                            xm.InnerText = nodeValue;
                            isInsertNode = false;
                            break;
                        }
                    }

                    isInsertBaseNode = false;
                    break;
                }
            }
            if (isInsertBaseNode == true)
            {
                var root = _xmlDoc.SelectSingleNode("AppInfo");
                var xe1 = _xmlDoc.CreateElement(baseNodeName);
                var xe2 = _xmlDoc.CreateElement(nodeName);
                xe2.InnerText = nodeValue;
                xe1.AppendChild(xe2);
                if (attributeName.Trim() != "")
                {
                    System.Xml.XmlAttribute axe = _xmlDoc.CreateAttribute(attributeName);
                    axe.InnerText = attributeValue;
                    xe1.Attributes.Append(axe);
                }
                root.AppendChild(xe1);
            }
            else if (isInsertNode == true)
            {
                foreach (XmlNode xn in nodeList)
                {
                    if (xn.Name == baseNodeName)
                    {
                        XmlElement xe2 = _xmlDoc.CreateElement(nodeName);
                        xe2.InnerText = nodeValue;
                        xn.AppendChild(xe2);
                    }
                }
            }
        }

        public void SaveXmlNode(string baseNodeName, string nodeName, string nodeValue)
        {
            try
            {
                var nodeList = _xmlDoc.SelectSingleNode("AppInfo").ChildNodes;
                var isInsertBaseNode = true;
                var isInsertNode = true;
                foreach (XmlNode xn in nodeList)
                {
                    if (xn.Name == baseNodeName)
                    {
                        foreach (XmlNode xm in xn.ChildNodes)
                        {
                            if (xm.Name == nodeName)
                            {
                                xm.InnerText = nodeValue;
                                isInsertNode = false;
                                break;
                            }
                        }
                        isInsertBaseNode = false;
                        break;
                    }
                }
                if (isInsertBaseNode == true)
                {
                    var root = _xmlDoc.SelectSingleNode("AppInfo");
                    var xe1 = _xmlDoc.CreateElement(baseNodeName);
                    var xe2 = _xmlDoc.CreateElement(nodeName);
                    xe2.InnerText = nodeValue;
                    xe1.AppendChild(xe2);
                    root.AppendChild(xe1);
                }
                else if (isInsertNode == true)
                {
                    foreach (XmlNode xn in nodeList)
                    {
                        if (xn.Name == baseNodeName)
                        {
                            XmlElement xe2 = _xmlDoc.CreateElement(nodeName);
                            xe2.InnerText = nodeValue;
                            xn.AppendChild(xe2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InsertErrLog(baseNodeName, nodeName, ex.ToString());
            }
        }

        public bool IsExistsXmlNode(string nodeName)
        {
            var nodeList = _xmlDoc.SelectSingleNode("AppInfo").ChildNodes;
            foreach (XmlNode xn in nodeList)
            {
                if (xn.Name == nodeName)
                {
                    return true;
                }
                foreach (XmlNode xm in xn.ChildNodes)
                {
                    if (xm.Name == nodeName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string ReadXmlNodeValue(string baseNodeName, string nodeName)
        {
            try
            {
                var nodeList = _xmlDoc.SelectSingleNode("AppInfo").ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    if (xn.Name == baseNodeName)
                    {
                        foreach (XmlNode xm in xn.ChildNodes)
                        {
                            if (xm.Name == nodeName)
                            {
                                return (xm.InnerText.ToString());

                            }
                        }
                        break;
                    }
                }
                return ("");
            }
            catch (Exception ex)
            {
                InsertErrLog(baseNodeName, nodeName, ex.ToString());
                return ("");
            }
        }

        public string ReadXmlNodeValue(string baseNodeName)
        {
            try
            {
                var nodeList = _xmlDoc.SelectSingleNode("AppInfo").ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    if (xn.Name == baseNodeName)
                    {
                        return (xn.InnerText.ToString());
                    }
                }
                return ("");
            }
            catch (Exception ex)
            {
                InsertErrLog(baseNodeName, "", ex.ToString());
                return ("");
            }
        }

        private void InsertErrLog(string baseNodeName, string nodeName, string strErrDescrib)
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
            string strNow = DateTime.Now.ToString();
            string strBuffer = strNow + "\t 父节点" + baseNodeName + "\t 节点" + nodeName + "\t" + strErrDescrib;
            StreamWriter sw;

            strPath = strPath + "\\Err.log";

            if (File.Exists(strPath) == false)
            {
                sw = File.CreateText(strPath);
            }
            else
            {
                FileInfo f = new FileInfo(strPath);
                if (f.Length > 524288)
                {
                    f.Delete();
                    sw = File.CreateText(strPath);
                }
                else
                {
                    sw = File.AppendText(strPath);
                }

                sw.WriteLine(strBuffer);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
