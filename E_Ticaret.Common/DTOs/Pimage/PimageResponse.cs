using E_Ticaret.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.Pimage
{
    public class PimageResponse : BaseDto
    {
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string DirectoryName { get; set; }
        public string Revision { get; set; }
        public int SortOrder { get; set; }
        public int ProductId { get; set; }
        public string Attachment { get; set; }
    }
}
