﻿using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace ApiTesting.Models
{
    public class Treatment : Entity<Guid>
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string FileName { get; set; }
        public string TherapistId { get; set; }
        public string PatientId { get; set; }
        [NotMapped]
        public FormFile File { get; set; }
    }
}
