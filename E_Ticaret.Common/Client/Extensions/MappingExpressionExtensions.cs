using AutoMapper;
using System.Reflection;

namespace E_Ticaret.Common.Client.Extensions
{
    public static class MappingExpressionExtensions
    {
        public static IMappingExpression<TSource,TDestination> IgnoreAllNonExisting<TSource,TDestination>(this IMappingExpression<TSource, TDestination> exp)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceType = typeof(TSource);
            var destinationProperties = typeof(TDestination).GetProperties(flags);
            foreach (var property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name,flags) == null)
                {
                    exp.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return exp;
        }
    }
}
