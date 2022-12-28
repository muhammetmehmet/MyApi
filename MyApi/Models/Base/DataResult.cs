namespace MyApi.Models.Base
{

    // Tüm dönüşleri bu class'tan alıyoruz çünkü her model aslında bize message ve success dönebilir.
    public class DataResult<TEntity>
    {
        public TEntity Data { get; set; }
        public List<TEntity> ListData { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
