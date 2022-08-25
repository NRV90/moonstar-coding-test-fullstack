using MediatR;
using Microsoft.AspNetCore.Http;

namespace BackEnd.Core.Services.File.Commands.UpdateFile
{
    public class UpdateFileCommand : IRequest<string>
    {
        public UpdateFileCommand(IFormFile formFile, string currentPath)
        {
            FormFile = formFile;
            CurrentPath = currentPath;
        }

        public IFormFile FormFile { get; }
        public string CurrentPath { get; }
    }
}
