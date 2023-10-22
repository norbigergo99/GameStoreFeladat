namespace GameStoreBeGNorbi.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task Update(T entity);
        Task Delete(int id);
    }
}
