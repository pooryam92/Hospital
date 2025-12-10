namespace Hospital.Application.Abstractions;

public interface IFileHandler
{
    Task<Stream> GetFileAsync(string fileName);
}