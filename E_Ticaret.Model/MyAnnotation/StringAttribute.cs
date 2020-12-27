using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_Ticaret.Core.MyAnnotation
{
    public class StringAttribute : ValidationAttribute
    {
        private readonly string[] _myarr;
        public StringAttribute(params string[] myarr)
        {
            _myarr = myarr;
        }
        public override bool IsValid(object value)
        {
            string strVal = value as string;
            foreach (var item in _myarr)
            {
                if (item.ToLower() != strVal.ToLower())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
