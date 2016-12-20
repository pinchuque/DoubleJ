using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Web.Extensions
{
    public static class EnumAttributeExtension
    {
        public static string GetEnumDescription(this TrackAnimal trackAnimal)
        {
            var type = typeof (TrackAnimal);
            var memInfo = type.GetMember(trackAnimal.ToString());
            var attribute = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
                false).FirstOrDefault();

            return (attribute == null)? Enum.GetName(typeof(TrackAnimal),trackAnimal): (attribute as DescriptionAttribute).Description;
        }

        public static List<TrackAnimal> GetAllEnumValues()
        {
            return Enum.GetValues(typeof(TrackAnimal)).Cast<TrackAnimal>().ToList();
        }
    }
}