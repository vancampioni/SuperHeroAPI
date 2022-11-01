namespace SuperHeroAPI.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        ISuperHeroDAO _superHero;

        public DefaultAdminService(ISuperHeroDAO superHero)
        {
            _superHero = superHero;
        }

        public IEnumerable<SuperHero> GetAllSuperHeroes()
        {
            return _superHero.GetAll();
        }

        public SuperHero GetSuperHeroById(int id)
        {
            return _superHero.GetById(id);
        }

        public SuperHero AddSuperHero(SuperHero superHero)
        {
            _superHero.Add(superHero);
            return superHero;
        }

        public SuperHero UpdateSuperHero(SuperHero superHero)
        {
            _superHero.Update(superHero);
            return superHero;
        }

        public SuperHero DeleteSuperHero(SuperHero superHero)
        {
            _superHero.Delete(superHero);
            return superHero;
        }
    }
}
