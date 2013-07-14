using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnumerationEditing.Models
{
    public static class Extensions
    {
        public static List<SelectListItem> EnumToSelectList(Type enumType)
        {
            return Enum
              .GetValues(enumType)
              .Cast<int>()
              .Select(i => new SelectListItem
              {
                  Value = i.ToString(),
                  Text = Enum.GetName(enumType, i),
              }
              )
              .ToList();
        }
    }
}