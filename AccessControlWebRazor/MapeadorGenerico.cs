using System.Reflection;

namespace AccessControlWebRazor
{
    public class MappeadorGenerico
    {
        public static T Map<T>(object f) where T : class, new()
        {
            try
            {
                int TotalNotFoundProperties = 0;
                PropertyInfo[] fromProps = f.GetType().GetProperties();
                PropertyInfo[] toProps = typeof(T).GetProperties();

                var result = new T();
                foreach (var from in fromProps)
                {
                    var to = toProps.FirstOrDefault(x => x.Name == from.Name);
                    if (to == null)
                    {
                        TotalNotFoundProperties++;
                        continue;
                    }
                    var val = from.GetMethod.Invoke(f, null);
                    to.SetMethod.Invoke(result, new[] { val });

                }
                if (TotalNotFoundProperties > (fromProps.Length / 2 + 1))
                {
                    throw new Exception($"TotalNotFoundProperties: {TotalNotFoundProperties} ." +
                        $"Too many properties  set to default value(check the types passing between <T>)");
                }
                return result;
            }
            catch (TargetParameterCountException tparEx)
            {
                throw new Exception($"Error mapping multiple entities from {f.GetType().FullName}" +
                    $" to list {typeof(T).FullName}." +
                    $"The mapping return empty objects", tparEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error mapping from {f.GetType().Name} " +
                    $"to {typeof(T).Name}", ex);
            }

        }
      
        public static T MapEntityWithInnerList<T, U, V>(object f)
            where T : class, new()
            where U : class, new()
            where V : class, new()
        {
            try
            {
                var fromProps = f.GetType().GetProperties();
                var toProps = typeof(T).GetProperties();

                var result = new T();
                foreach (var from in fromProps)
                {
                    var to = toProps.FirstOrDefault(x => x.Name == from.Name);
                    if (to == null)
                    {
                        continue;
                    }
                    if (to.PropertyType.FullName.Contains("System.Collections.Generic.List"))
                    {
                       
                        var plistFrom = fromProps.FirstOrDefault(x => x.Name == from.Name);
                       
                        var innerListValuesFrom = plistFrom.GetValue(f);
                        var innerListValuesTo = MapEntities<V>((IEnumerable<object>)innerListValuesFrom);
                        to.SetMethod.Invoke(result, new[] { innerListValuesTo });
                    }
                    else
                    {

                        var val = from.GetMethod.Invoke(f, null);
                        to.SetMethod.Invoke(result, new[] { val });
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error mapping from the {f.GetType().Name}" +
                    $" to {typeof(T).Name} " +
                    $"and from the inner list of {f.GetType().Name}," +
                    $"{typeof(U).Name} to {typeof(U).Name}", ex);
            }

        }

        public static List<T> MapEntities<T>(IEnumerable<object> f) where T : class, new()
        {
            try
            {
                var toProps = typeof(T).GetProperties();
                List<T> result = new();
                foreach (var item in f)
                {
                    var mappedObj = Map<T>(item);
                    foreach (var prop in toProps)
                    {
                        //Getting the inner list property type of my entity => List<product>
                        var plistFrom = toProps.FirstOrDefault(x => x.Name == prop.Name);
                        //Getting the inner list values of my entity, ex => products
                        //If goes wrong the mapping, here throws TargetParameterCountException
                        var innerListValuesFrom = plistFrom.GetValue(mappedObj);
                    }
                    result.Add(mappedObj);
                }
                return result;
            }
            catch (TargetParameterCountException tparEx)
            {
                throw new Exception($"Error mapping multiple entities from {f.GetType().FullName}" +
                    $" to list {typeof(T).FullName}." +
                    $"The mapping return empty objects", tparEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error mapping multiple entities from {f.GetType().FullName}" +
                    $" to list {typeof(T).FullName}", ex);
            }
        }

    }
}
