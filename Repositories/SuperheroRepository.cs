using GraphQL.App.Data;
using GraphQL.App.Interfaces;
using GraphQL.App.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.App.Repositories
{
    public class SuperheroRepository : ISuperheroRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public SuperheroRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IQueryable<Superhero>> GetSuperheroesAsync()
        {
            var heroes = await _appDbContext.Superheroes
                .Include(x => x.Superpowers)
                .Include(x => x.Movies)
                .ToListAsync();

            return heroes.AsQueryable();
        }

        public async Task<Superhero> GetSuperheroeByIdAsync(string heroId)
        {
            var hero = await _appDbContext.Superheroes
                .AsQueryable()
                .Include(x => x.Superpowers)
                .Include(x => x.Movies)
                .FirstOrDefaultAsync(x => x.Id.ToString() == heroId);

            return hero;
        }

        public async Task<Superhero> CreateNewSuperherAsync(Superhero superhero)
        {
            var newHero = new Superhero()
            {
                Name = superhero.Name,
                Description = superhero.Description,
                Height = superhero.Height,
            };

            await _appDbContext.Superheroes.AddAsync(newHero);
            await _appDbContext.SaveChangesAsync();

            return newHero;
        }
    }
}
