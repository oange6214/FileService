using System.Xml;

namespace FileService.FileParsers;

public class XmlFileParserByXmlDocument : IFileParser
{
    public void Parse(string filePath)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);

        Stack<XmlNode> nodes = new Stack<XmlNode>();
        nodes.Push(xmlDoc.DocumentElement);

        while (nodes.Count > 0)
        {
            XmlNode node = nodes.Pop();
            ParseXmlNode(node);

            if (node.HasChildNodes)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    nodes.Push(childNode);
                }
            }
        }
    }

    private void ParseXmlNode(XmlNode xmlNode)
    {
        switch (xmlNode.NodeType)
        {
            case XmlNodeType.Element:
                HandleElement(xmlNode);
                break;

            case XmlNodeType.Text:
                HandleText(xmlNode);
                break;

            case XmlNodeType.Comment:
                HandleComment(xmlNode);
                break;

            // 其他節點類型的處理...

            default:
                break;
        }
    }

    private void HandleElement(XmlNode xmlNode)
    {
        Console.WriteLine("Element: " + xmlNode.Name);

        HandleAttributes(xmlNode);
    }

    private void HandleAttributes(XmlNode xmlNode)
    {
        if (xmlNode.Attributes != null && xmlNode.Attributes.Count > 0)
        {
            foreach (XmlAttribute attribute in xmlNode.Attributes)
            {
                Console.WriteLine("Attribute: " + attribute.Name + " = " + attribute.Value);
            }
        }
    }

    private void HandleText(XmlNode xmlNode)
    {
        Console.WriteLine("Text: " + xmlNode.Value);
    }

    private void HandleComment(XmlNode xmlNode)
    {
        Console.WriteLine("Comment: " + xmlNode.Value);
    }
}
