using Microsoft.AspNetCore.Http;
using System;
using Volo.Abp.Application.Dtos;

namespace ApiTesting.Treatments.Dto
{
    public class TreatmentDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public DateTime Date;
        public string Message { get; set; }
        public string FileName;
        public string Key;
        public string TherapistId { get; set; }
        public string PatientId { get; set; }
        public IFormFile File { get; set; }

    }
}
