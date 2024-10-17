public static class IEnumerableExtensions
{
    public static List<T> ToPaginatedList<T>(this List<T> source, int pageNumber, int pageSize)
    {
        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than or equal to 1.");
        }

        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than or equal to 1.");
        }

        return source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }
}