using System;
using Volo.Abp.Application.Dtos;

namespace ApiTesting.Treatments.Dto
{
    public class TreatmentDto:EntityDto<Guid>
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string FileName { get; set; }
        public string TherapistId { get; set; }
        public string PatientId { get; set; }

    }
}
