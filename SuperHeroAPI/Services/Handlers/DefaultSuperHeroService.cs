namespace SuperHeroAPI.Services.Handlers
{
    public class DefaultSuperHeroService : ISuperHeroService
    {
        ISuperHeroDAO _superHero;

        public DefaultSuperHeroService(ISuperHeroDAO superHero)
        {
            _superHero = superHero;
        }

        public IEnumerable<SuperHero> GetAllSuperHeroes()
        {
            return _superHero.GetAll();
        }

        public SuperHero GetAllSuperHeroesById(int id)
        {
            return _superHero.GetById(id);
        }


    }
}
