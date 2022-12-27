using GraphQL.App.Models;

namespace GraphQL.App.Interfaces
{
    public interface ISuperheroRepository
    {
        Task<IQueryable<Superhero>> GetSuperheroesAsync();

        Task<Superhero> GetSuperheroeByIdAsync(string heroId);

        Task<Superhero> CreateNewSuperherAsync(Superhero superhero);

    }
}
