using E_Ticaret.Core.Entity;
using System;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Kategori
    public class Category : CoreEntity
    {
        public Category()
        {
            ProductToCategories = new HashSet<ProductToCategory>();
            CartItems = new HashSet<CartItem>();
            SubCategories = new HashSet<Category>();
        }
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
        public Category Parent { get; set; }
        public ICollection<Category> SubCategories { get; set; }
        public string Attachment { get; set; }
        public ICollection<ProductToCategory> ProductToCategories { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public Member ModifiedMemberCategory { get; set; }
        public Member  CreatedMemberCategory { get; set; }

    }
}
