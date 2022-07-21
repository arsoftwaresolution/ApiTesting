using ApiTesting.Treatments.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTesting.Treatments
{
    public interface IDocumentFileService
    {
        void Add(DocumentFileDto documentStore);
        List<DocumentFileDto> GetDocumentStoresList();
        void Delete(DocumentFileDto documentStore);
        DocumentFileDto GetDocumentbyDocumentId(int id);
    }
}
