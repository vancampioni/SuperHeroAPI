namespace SuperHeroAPI.Services
{
    public interface ISuperHeroService
    {
        IEnumerable<SuperHero> GetAllSuperHeroes();

        SuperHero GetAllSuperHeroesById(int id);
    }
}
