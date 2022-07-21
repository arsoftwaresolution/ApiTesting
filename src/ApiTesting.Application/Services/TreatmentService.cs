using Amazon.S3;
using Amazon.S3.Model;
using ApiTesting.Controllers;
using ApiTesting.Models;
using ApiTesting.Treatments.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace ApiTesting.Services
{
    public class TreatmentService : ApplicationService
    {
        private readonly IAmazonS3 _amazonS3;
        private readonly IRepository<Treatment> _treatmentRepository;

        public TreatmentService(
            IAmazonS3 amazonS3,
            IRepository<Treatment> treatmentRepository)
        {
            _amazonS3 = amazonS3;
            _treatmentRepository = treatmentRepository;
        }
        public async Task<Treatment> CreateTreatmentNoteAsync(Treatment treatment)
        {
            var getTreatment = await _treatmentRepository.FirstOrDefaultAsync(x => x.Title == treatment.Title);
            if (getTreatment == null)
            {
                var map = ObjectMapper.Map<Treatment, Treatment>(treatment);
                var fileUpload = await UploadTreatmentNoteAsync(treatment.File);
                map.FileName = fileUpload;
                var result = await _treatmentRepository.InsertAsync(map);
                return result;
            }
            throw new UserFriendlyException("Treatment exist already");
        }

        public async Task<string> UploadTreatmentNoteAsync(IFormFile file)
        {
            if (file.Length < 2048000)
            {
                var supportedType = new[] { "pdf", "doc", "png", "jpeg" };
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
                    return request.Key;
                }
                return "File not supported";
            }
            return "Something went wrong";
        }
    }
}
