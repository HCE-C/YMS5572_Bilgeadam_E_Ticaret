using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Core.Map
{
    public interface IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder);
    }
}
