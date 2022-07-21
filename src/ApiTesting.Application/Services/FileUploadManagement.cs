using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace ApiTesting.Services
{
    public class FileUploadManagement : ApplicationService
    {
        private readonly IAmazonS3 _amazonS3;

        public FileUploadManagement(IAmazonS3 amazonS3)
        {
            _amazonS3 = amazonS3;
        }

        public async Task<string> UploadFile(IFormFile file)
        {

            if (file.Length < 2048000)
            {
                var supportedType = new[] { "pdf", "docx", "png", "jpeg", "jpg" };
                var fileExt = Path.GetExtension(file.FileName).Substring(1);
                if (supportedType.Contains(fileExt))
                {
                    var request = new PutObjectRequest
                    {
                        BucketName = "theraparea",
                        Key = file.FileName,
                        InputStream = file.OpenReadStream()
                    };
                    request.Metadata.Add("Content-type", file.ContentType);
                    await _amazonS3.PutObjectAsync(request);
                    return $"File {file.FileName} uploaded successfully!";
                }
                throw new UserFriendlyException("File not supported");
            }
            throw new UserFriendlyException("Bad Request");
        }
        public async Task<string> DeleteFile(string key)
        {
            var request = new DeleteObjectRequest
            {
                BucketName = "theraparea",
                Key = key
            };
            var response = await _amazonS3.DeleteObjectAsync(request);
            if (response != null)
            {
                return "Deleted";
            }
            return "file not found";
        }
        //public async Task<string> GetFileByKeyAsync(string key)
        //{
        //    var bucketName = "theraparea";
        //    var bucketExist = await _amazonS3.DoesS3BucketExistAsync(bucketName);
        //    if (!bucketExist)
        //    {
        //        return $"{bucketName} Not Exist";
        //    }
        //    var file = await _amazonS3.GetObjectAsync(bucketName, key);
        //    await File(file.ResponseStream, file.Headers.ContentType);
        //}

    }
}
