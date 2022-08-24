using MediatR;
using Microsoft.AspNetCore.Http;

namespace BackEnd.Core.Services.File.Commands.CreateFile
{
    public class CreateFileCommand : IRequest<string>
    {
        public CreateFileCommand(IFormFile formFile)
        {
            FormFile = formFile;
        }

        public IFormFile FormFile { get; }
    }
}
