using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Command.Blobs.UploadAvatar
{
    public class UploadAvatarCommandHandler : IRequestHandler<UploadAvatarCommand, string>
    {
        private readonly IClassRepository<Image> _imageRepository;
        private readonly IUserRepository<User> _userRepository;
        public UploadAvatarCommandHandler(IClassRepository<Image> imageRepository, IUserRepository<User> userRepository)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
        }
        public async Task<string> Handle(UploadAvatarCommand command, CancellationToken cancellationToken)
        {
            IConfiguration config;
            var user = _userRepository.GetWithInclude(x => x.Id == command.UserId);
            string finalUrl = "";
            string systemFileName = $"{user.Id}_{user.FirstName}+{user.LastName}" + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd") + DateTime.Now.ToUniversalTime().ToString("THHmmssfff") + "." + command.Files.FileName;
            string blobstorageconnection = "DefaultEndpointsProtocol=https;AccountName=typostorage;AccountKey=adQVgN/sv82jwKngtWcnGsLINxTJ7zt+g2ATE1HCDAMFwb60ektID3A9q14XwobNPc18NbilZZ8i+AStQ5fO+A==;EndpointSuffix=core.windows.net";
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("avatars");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);
            await using (var data = command.Files.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(data);
            }
            finalUrl = $"{container.Uri.AbsoluteUri + "/" + systemFileName}";
            Image img = new()
            {
                UserId = command.UserId,
                ImageTitle = finalUrl
            };
            _imageRepository.Add(img);
            _imageRepository.Save();

            return await Task.FromResult(finalUrl);
        }
    }
}

