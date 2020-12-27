using E_Ticaret.Core.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.Base
{
    public class BaseDto
    {
        public int Id { get; set; }
        public Status Status { get; set; }

        public string Ids { get; set; }
        public string Sort { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
        public int SinceId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartUpdatedAt { get; set; }
        public string EndUpdatedAt { get; set; }
    }
}
