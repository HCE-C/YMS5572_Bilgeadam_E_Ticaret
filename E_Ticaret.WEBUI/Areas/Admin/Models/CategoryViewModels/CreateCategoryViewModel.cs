
using E_Ticaret.Core.Entity.Enums;
using E_Ticaret.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.WEBUI.Areas.Admin.Models.CategoryViewModels
{
    public class CreateCategoryViewModel
    {
        [Required]
        [MaxLength(255)]
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
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
        public string Attachment { get; set; }
    }
}
