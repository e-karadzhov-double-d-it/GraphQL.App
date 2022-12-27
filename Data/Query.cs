using GraphQL.App.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.App.Data
{
    public class Query
    {
        [GraphQLName("GetSuperHeroes")]
        [GraphQLDescription("Get collection")]
        public async Task<IQueryable<Superhero>> GetSuperheroes(string? heroId, [Service] ApplicationDbContext context)
        {
            var heroes = new List<Superhero>();
            if (heroId != null)
            {
                var hero = await context.Superheroes.FirstOrDefaultAsync(x => x.Id.ToString() == heroId);
                heroes.Add(hero);
            }
            else
            {
                heroes.AddRange(context.Superheroes);
            }

            return heroes.AsQueryable();
        }

        [GraphQLName("PostSuperHeroes")]
        [GraphQLDescription("Post method")]
        public async Task<Superhero> PostSuperheroes(string name, string description, double height, [Service] ApplicationDbContext context)
        {
            var hero = new Superhero()
            {
                Name = name,
                Description = description,
                Height = height,
            };

            await context.Superheroes.AddAsync(hero);
            await context.SaveChangesAsync();
            return await context.Superheroes.AsQueryable().FirstAsync(x => x.Id == hero.Id);
        }
    }
}
