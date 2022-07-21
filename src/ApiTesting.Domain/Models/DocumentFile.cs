using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ApiTesting.Models
{
    public class DocumentFile:Entity<Guid>
    {
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
