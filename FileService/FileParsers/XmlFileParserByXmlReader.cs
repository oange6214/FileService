using System.Xml;

namespace FileService.FileParsers
{
    public class XmlFileParserByXmlReader : IFileParser
    {
        public void Parse(string filePath)
        {
            using XmlReader reader = XmlReader.Create(filePath);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        HandleElement(reader);
                        break;

                    case XmlNodeType.Text:
                        HandleText(reader);
                        break;

                    case XmlNodeType.Comment:
                        HandleComment(reader);
                        break;

                    // 其他節點類型的處理...

                    default:
                        break;
                }
            }
        }

        private void HandleElement(XmlReader reader)
        {
            Console.WriteLine("Element: " + reader.Name);

            if (reader.HasAttributes)
            {
                while (reader.MoveToNextAttribute())
                {
                    Console.WriteLine("Attribute: " + reader.Name + " = " + reader.Value);
                }

                // Move the reader back to the element node.
                reader.MoveToElement();
            }
        }

        private void HandleText(XmlReader reader)
        {
            Console.WriteLine("Text: " + reader.Value);
        }

        private void HandleComment(XmlReader reader)
        {
            Console.WriteLine("Comment: " + reader.Value);
        }
    }
}
