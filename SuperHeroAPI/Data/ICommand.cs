namespace SuperHeroAPI.Data
{
    public interface ICommand<T>
    {
        T Add(T obj);
        T Update(T obj);
        T Delete(T obj);
    }
}
