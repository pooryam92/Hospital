using System.Text;
using Hospital.Application.Abstractions;

namespace Hospital.Infrastructure.FileHandler;

public class FileHandlerMock : IFileHandler
{
    public Task<Stream> GetFileAsync(string fileName)
    {
        var content = Encoding.UTF8.GetBytes("Hello world!");
        return Task.FromResult<Stream>(new MemoryStream(content, writable: false));
    }
}