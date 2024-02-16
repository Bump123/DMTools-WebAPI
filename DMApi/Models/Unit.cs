using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DMApi.Models
{
    public class Unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int AC { get; set; }

        public Unit(string name, int aC, int id)
        {
            Id = id;
            Name = name;
            AC = aC;
        }
    }
}
