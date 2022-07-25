using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace ApiTesting.Models
{
    public class TreatmentNote : Entity<Guid>
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string FileName { get; set; }
        public string Key { get; set; }
        public string TherapistId { get; set; }
        public string PatientId { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
