using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Helpers
{
    public class Mapper
    {
        public static T GetBindedModel<T>(object entity) where T : new()
        {
            var model = new T();

            BindMatches(entity, model);

            return model;
        }

        public static void BindMatches(object source, object destiny, string datetimeFormat = null, string defaultEmpty = null, List<string> skipProperties = null)
        {
            skipProperties = skipProperties ?? new List<string>();
            var destinyPropertiesName = new HashSet<string>(source.GetType().GetProperties().Select(x => x.Name));
            var entityProperties = destiny.GetType().GetProperties();

            var propertyList = entityProperties.Where(p => destinyPropertiesName.Contains(p.Name) && !skipProperties.Contains(p.Name))
                .ToList();

            foreach (var prop in propertyList)
            {
                var sourceProperty = source.GetType().GetProperty(prop.Name);
                var value = sourceProperty.GetValue(source);

                var destinyProperty = destiny.GetType().GetProperty(prop.Name);


                var sourcePropertyTypeCode = sourceProperty.PropertyType.IsGenericType && sourceProperty.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                    ? Type.GetTypeCode(Nullable.GetUnderlyingType(sourceProperty.PropertyType))
                    : Type.GetTypeCode(sourceProperty.PropertyType);

                var destinyPropertyTypeCode = destinyProperty.PropertyType.IsGenericType && destinyProperty.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                   ? Type.GetTypeCode(Nullable.GetUnderlyingType(destinyProperty.PropertyType))
                   : Type.GetTypeCode(destinyProperty.PropertyType);

                if (destinyProperty.PropertyType != sourceProperty.PropertyType)
                {
                    if (sourcePropertyTypeCode == TypeCode.DateTime && destinyPropertyTypeCode == TypeCode.String)
                    {
                        var formattedValue = string.Empty;

                        formattedValue = string.IsNullOrEmpty(datetimeFormat)
                            ? value != null ? ((DateTime)value).ToShortDateString() : string.Empty
                            : ((DateTime)value).ToString(datetimeFormat);

                        prop.SetValue(destiny, formattedValue, null);
                    }
                    else if (destinyProperty.PropertyType.IsGenericType &&
                             destinyProperty.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) && sourcePropertyTypeCode == destinyPropertyTypeCode)
                    {
                        prop.SetValue(destiny, value, null);
                    }
                    else if (destinyProperty.PropertyType.IsGenericType &&
                             sourceProperty.PropertyType.IsGenericType &&
                             sourceProperty.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
                             destinyProperty.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    {
                        prop.SetValue(destiny, value, null);
                    }
                }
                else
                {
                    if (sourcePropertyTypeCode == TypeCode.String && destinyPropertyTypeCode == TypeCode.String && !string.IsNullOrEmpty(defaultEmpty) && string.IsNullOrEmpty(value as string))
                    {
                        value = defaultEmpty;
                    }

                    prop.SetValue(destiny, value, null);
                }
            }
        }
    }
}