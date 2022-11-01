namespace SuperHeroAPI.Data
{
    public interface ISuperHeroDAO : ICommand<SuperHero>, IQuery<SuperHero>
    {
    }
}
