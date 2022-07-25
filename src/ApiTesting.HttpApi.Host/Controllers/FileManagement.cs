using Amazon.S3;
using Amazon.S3.Model;
using ApiTesting.Treatments.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace ApiTesting.Controllers
{
    [ApiController]
    [Route("api/")]
    public class FileManagement : AbpController
    {
        private readonly IAmazonS3 _amazonS3;

        public FileManagement(IAmazonS3 amazonS3)
        {
            _amazonS3 = amazonS3;
        }
        //[HttpGet("downloadfile")]
        //public async Task<ActionResult<byte[]>> DownloadFileAsync(string key)
        //{
        //    var bucketName = "theraparea";
        //    var bucketExist = await _amazonS3.DoesS3BucketExistAsync(bucketName);
        //    if (!bucketExist)
        //    {
        //        return BadRequest($"{bucketExist} not exist");
        //    }
        //    var request = new GetObjectRequest
        //    {
        //        BucketName = bucketName,
        //        Key = key
        //    };
        //    var file = await _amazonS3.GetObjectAsync(request);
        //     return File(file.ResponseStream, file.Headers.ContentType);

        //}
        //[HttpPost("upload")]
        //public async Task<IActionResult> UploadTreatmentNoteAsync(IFormFile file)
        //{

        //    if (file.Length < 2048000)
        //    {
        //        var supportedType = new[] { "pdf", "doc", "png", "jpeg" };
        //        var fileExt = Path.GetExtension(file.FileName).Substring(1);
        //        if (supportedType.Contains(fileExt))
        //        {
        //            var request = new PutObjectRequest
        //            {
        //                BucketName = "theraparea",
        //                Key = file.FileName,
        //                InputStream = file.OpenReadStream()
        //            };
        //            request.Metadata.Add("Content-type", file.ContentType);
        //            await _amazonS3.PutObjectAsync(request);
        //            return Ok($"File {file.FileName} uploaded successfully!");
        //        }
        //        return BadRequest("File not supported");
        //    }
        //    return BadRequest("Something went wrong");
        //}
        //[HttpDelete("deletefile")]
        //public async Task<IActionResult> DeleteFile(string key)
        //{
        //    var request = new DeleteObjectRequest
        //    {
        //        BucketName = "theraparea",
        //        Key = key
        //    };
        //    await _amazonS3.DeleteObjectAsync(request);
        //    return Ok();
        //}
        //[HttpGet("Get-All")]
        //public async Task<IActionResult> GetAllFilesAsync()
        //{
        //    var bucketname = "theraparea";
        //    var bucketExist = await _amazonS3.DoesS3BucketExistAsync(bucketname);
        //    if (!bucketExist)
        //    {
        //        return NotFound($"bucket {bucketname} does not exist...");
        //    }
        //    var request = new ListObjectsV2Request()
        //    {
        //        BucketName = bucketname,
        //        Prefix = ""
        //    };
        //    var result = await _amazonS3.ListObjectsV2Async(request);


        //    // select and display the path and the link to display the content stored 
        //    var s3Objects = result.S3Objects.Select(async s =>
        //    {
        //        var urlRequest = new GetPreSignedUrlRequest()
        //        {
        //            BucketName = bucketname,
        //            Key = s.Key,
        //            Expires = DateTime.UtcNow.AddSeconds(30), // link will work till 30 secs
        //        };
        //        return new S3ObjectResponse()
        //        {
        //            Name = s.Key,
        //            PreSignedURL = _amazonS3.GetPreSignedURL(urlRequest),
        //            Date = s.LastModified,
        //            Key = s.Key
        //        };
        //    });
        //    return Ok(s3Objects);
        //}
    }
}
