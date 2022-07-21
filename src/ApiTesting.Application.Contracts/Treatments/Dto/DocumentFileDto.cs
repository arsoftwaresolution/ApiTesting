using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ApiTesting.Treatments.Dto
{
    public class DocumentFileDto:EntityDto<Guid>
    {
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
