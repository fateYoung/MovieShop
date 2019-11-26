using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieShop.Utility.Validations
{
    public class MovieShopEmailValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                //call user service method
                //Check if email exists

                //if service returns null
                //means user does not exists ---- return true

                //if service returns user obj
                //it means user does exists ---- return false
                return false;
            }

            return true;
        }
    }
}