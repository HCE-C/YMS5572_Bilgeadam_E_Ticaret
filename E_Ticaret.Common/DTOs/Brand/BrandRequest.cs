using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Model.Enums.GeneralEnums;

namespace E_Ticaret.Common.DTOs.Brand
{
    public class BrandRequest : BaseDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public string DistibutorCode { get; set; }
        public string Distributor { get; set; }
        public string ImageFilename { get; set; }
        public string ShowcaseContent { get; set; }
        public DisplayShowcaseContent DisplayShowcaseContent { get; set; }
        public string MetaKeyWords { get; set; }
        public string MetaDescription { get; set; }
        public string PageTitle { get; set; }
        public string Attachment { get; set; }
    }
}
