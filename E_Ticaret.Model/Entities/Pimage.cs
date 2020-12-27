using E_Ticaret.Core.Entity;

namespace E_Ticaret.Model.Entities
{
    //Ürün Resmi
    public class Pimage : CoreEntity
    {
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string DirectoryName { get; set; }
        public string Revision { get; set; }
        public int SortOrder { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Attachment { get; set; }

        public Member CreatedMemberPimage { get; set; }
        public Member ModifiedMemberPimage { get; set; }
    }
}