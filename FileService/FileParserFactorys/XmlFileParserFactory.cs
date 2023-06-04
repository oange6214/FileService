using FileService.FileParsers;

namespace FileService.FileParserFactorys;

internal class XmlFileParserFactory : FileParserFactory
{
    public override IFileParser CreateFileParser()
    {
        return new XmlFileParserBySerialization();
    }
}
