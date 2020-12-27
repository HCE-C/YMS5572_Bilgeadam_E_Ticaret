using E_Ticaret.Core.Entity;
using E_Ticaret.Model.Enums.GeneralEnums;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Marka
    public class Brand : CoreEntity
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }
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

        public ICollection<Product> Products { get; set; }

        public Member CreatedMemberBrand{ get; set; }
        public Member ModifiedMemberBrand { get; set; }
    }
}