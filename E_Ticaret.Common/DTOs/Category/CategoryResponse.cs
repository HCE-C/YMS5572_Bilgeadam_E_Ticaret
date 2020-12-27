using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Model;

namespace E_Ticaret.Common.DTOs.Category
{
    public class CategoryResponse : BaseDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public string DistributorCode { get; set; }
        public decimal Percent { get; set; }
        public string ImageFilename { get; set; }
        public string Distributor { get; set; }
        public int DisplayShowcaseContent { get; set; }
        public string ShowcaseContent { get; set; }
        public ShowcaseContentDisplayType ShowcaseContentDisplayType { get; set; }
        public HasChildren HasChildren { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string PageTitle { get; set; }

        public int? ParentId { get; set; }
        public CategoryResponse Parent { get; set; }
        public string Attachment { get; set; }
    }
}
