using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Core.Services.File.Commands.CreateFile
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, string>
    {
        public async Task<string> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var file = request.FormFile;
            var filePath = string.Empty;

            if (file != null && file.Length > 0)
            {
                var assestsPath = @"../assets/img/";

                var uploads = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\FrontEnd\photo-gallery\src\assets\img"));

                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                if (file.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString();

                    using var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);

                    await file.CopyToAsync(fileStream, cancellationToken);

                    filePath = assestsPath + fileName;
                }
            }

            return filePath;
        }
    }
}
