using GraphQL.App.Interfaces;
using GraphQL.App.Models;

namespace GraphQL.App.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLName("GetSuperHeroes")]
        [GraphQLDescription("Get collection")]
        public async Task<IQueryable<Superhero>> GetSuperheroes(string? heroId, [Service] ISuperheroRepository context)
        {
            if (heroId != null)
            {
                return (IQueryable<Superhero>)await context.GetSuperheroeByIdAsync(heroId);
            }

            return await context.GetSuperheroesAsync();
        }

        [GraphQLName("CreateSuperHero")]
        [GraphQLDescription("Create new Super Hero")]
        public async Task<Superhero> PostSuperheroes(Superhero superhero, [Service] ISuperheroRepository context)
        {
            return await context.CreateNewSuperherAsync(superhero);
        }
    }
}
