namespace SuperHeroAPI.Services
{
    public interface IAdminService
    {
        IEnumerable<SuperHero> GetAllSuperHeroes();

        SuperHero GetSuperHeroById(int id);

        SuperHero AddSuperHero(SuperHero superHero);

        SuperHero UpdateSuperHero(SuperHero superHero);

        SuperHero DeleteSuperHero(SuperHero superHero);
    }
}