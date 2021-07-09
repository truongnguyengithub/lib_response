namespace OMC.Libs
{
    public class DataPaging
    {
        public static DataPaging<T> Create<T>(T data, long totalRecords) where T : class
        {
            DataPaging<T> d = new DataPaging<T>
            {
                Data = data,
                TotalRecords = totalRecords
            };
            return d;
        }
        public long TotalRecords { get; set; }
    }
    public class DataPaging<T> : DataPaging where T : class
    {
        public T Data { get; set; }
    }
}
