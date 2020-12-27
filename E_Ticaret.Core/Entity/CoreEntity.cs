using E_Ticaret.Core.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Core.Entity
{
    public class CoreEntity : IEntity<int>
    {
        public int Id { get; set; }
        public Status Status { get; set; }

        public int? CreatedMemberId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedIp { get; set; }
        public string CreatedComputer { get; set; }

        public int? ModifiedMemberId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedIp { get; set; }
        public string ModifiedComputer { get; set; }

    }
}
