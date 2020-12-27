using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Core.Entity
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
