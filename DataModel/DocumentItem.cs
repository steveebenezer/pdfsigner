using System;

namespace PdfSigner.DataModel
{
    public class DocumentItem
    {
        public string Filename { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public bool IsSigned { get; set; }
    }
}