using System.ComponentModel.DataAnnotations;

namespace PizzaExpress.Models
{
    public abstract class DbEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
