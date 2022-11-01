using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Data.EfCore
{
    public class SuperHeroDAO : ISuperHeroDAO
    {
        DataContext _context;

        public SuperHeroDAO(DataContext context)
        {
            _context = context;
        }

        IEnumerable<SuperHero> IQuery<SuperHero>.GetAll()
        {
            return _context.SuperHeroes; 
        }

        [HttpGet("{id}")] // Parameter for the route
        public SuperHero GetById(int id)
        {
            var hero = _context.SuperHeroes.FirstOrDefault(x => x.Id == id);

            return (hero);
        }

        SuperHero ICommand<SuperHero>.Add(SuperHero obj)
        {
            _context.SuperHeroes.Add(obj);

            return (obj);
        }

        SuperHero ICommand<SuperHero>.Update(SuperHero obj)
        {
            _context.SuperHeroes.Update(obj);
            _context.SaveChanges();

            return(obj);
        }

        public SuperHero Delete(SuperHero obj)
        {
            _context.SuperHeroes.Remove(obj);
            _context.SaveChanges();

            return (obj);
        }

    }
}
