using FileService.FileParsers;

namespace FileService.FileParserFactorys;

internal abstract class FileParserFactory
{
    public abstract IFileParser CreateFileParser();
}