using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ApiTesting.Treatments.Dto
{
    public class S3ObjectResponse:EntityDto<int>
    {
        public string Name { get; set; }
        public string PreSignedURL { get; set; }
        public DateTime Date { get; set; }
        public string Key { get; set; }
    }
}
