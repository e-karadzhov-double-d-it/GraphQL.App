using System.ComponentModel.DataAnnotations;

namespace GraphQL.App.Models
{
    public class Superhero
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please specify a name for the superhero")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Height { get; set; }

        public ICollection<Superpower> Superpowers { get; set; } = new HashSet<Superpower>();
        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
