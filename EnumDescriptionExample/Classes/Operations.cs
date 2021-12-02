using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EnumDescriptionExample.Classes
{
    public class Operations
    {
        public static List<ItemContainer> CategoryItems() =>
            Enum.GetValues(typeof(Categories))
                .Cast<Enum>()
                .Select(value => new ItemContainer
                {
                    Description = ((DescriptionAttribute)Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute))).Description,
                    Value = value
                }).ToList();
    }
}