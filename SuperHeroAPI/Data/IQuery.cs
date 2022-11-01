namespace SuperHeroAPI.Data
{
    public interface IQuery<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
