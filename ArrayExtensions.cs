namespace Common 
{
    public static class ArrayExtensions
    {
        public static T[] Add<T>(this T[] array, T item)
        {
            if (array == null)
                return new T[] { item };

            return array.Concat(new T[] { item }).ToArray();
        }
    }
}
