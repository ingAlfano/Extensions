using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class LinqExtensions
    {
        public static T[] CleanArray<T>(this T[] array) => array.Where(e => e != null).ToArray();

        public static IEnumerable<T> SortBy<T, K>(this IEnumerable<T> collection, params Func<T, K>[] statements)
        {
            statements = statements.CleanArray();

            if (!statements.Any())
                return collection;

            var result = collection.OrderBy(statements?.FirstOrDefault());

            statements = statements.ToList().Skip(1).ToArray();

            foreach (var statement in statements)
            {
                result = result.ThenBy(statement);
            }

            return result;
        }

        public static IEnumerable<T> SortByAlternative<T, K>(this IEnumerable<T> collection, Func<T, K> firstStatement, params Func<T, K>[] statements)
        {
            statements = statements.CleanArray();

            if (!statements.Any())
                return collection;

            var result = collection.OrderBy(firstStatement);

            statements = statements.ToList().Skip(1).ToArray();

            foreach (var statement in statements)
            {
                result = result.ThenBy(statement);
            }

            return result;
        }
    }
}
