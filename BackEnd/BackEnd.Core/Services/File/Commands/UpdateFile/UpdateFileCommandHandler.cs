using MediatR;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Core.Services.File.Commands.UpdateFile
{
    public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand, string>
    {
        public async Task<string> Handle(UpdateFileCommand request, CancellationToken cancellationToken)
        {
            var file = request.FormFile;
            var filePath = request.CurrentPath;

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
                    var fileName = !string.IsNullOrEmpty(request.CurrentPath) && request.CurrentPath.Contains("/") ? request.CurrentPath.Split('/').LastOrDefault() : Guid.NewGuid().ToString();

                    using var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);

                    await file.CopyToAsync(fileStream, cancellationToken);

                    filePath = assestsPath + fileName;
                }
            }

            return filePath;
        }
    }
}
