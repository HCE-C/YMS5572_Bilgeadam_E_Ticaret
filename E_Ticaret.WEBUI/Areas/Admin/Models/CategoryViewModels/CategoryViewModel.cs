using E_Ticaret.Common.Client.Enums;
using E_Ticaret.Model;
using System.ComponentModel;

namespace E_Ticaret.WEBUI.Areas.Admin.Models.CategoryViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }
        public Status Status { get; set; }
        public string ImageFilename { get; set; }
        public int? ParentId { get; set; }
    }
}
