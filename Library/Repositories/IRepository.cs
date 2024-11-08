namespace LibraryCorner.Repositories
{
    public interface IRepository<T, T1Request,T2Request>
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        T Get(int id);
        IEnumerable<T> GetAll();
        T Find(T1Request request);
    }
}
