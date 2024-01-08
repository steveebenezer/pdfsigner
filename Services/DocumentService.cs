using System.Collections.Generic;
using PdfSigner.DataModel;

namespace PdfSigner.Services
{
    public class DocumentService
    {
        public IEnumerable<DocumentItem> GetItems() => new[]
        {
            new DocumentItem { Filename="file 1", Address = "./1" },
            new DocumentItem { Filename="file 2", Address = "./2" },
            new DocumentItem { Filename="file 3", Address = "./3" },
        };
    }
}