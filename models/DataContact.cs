using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmailApi.models
{
    [Table("DataContact")]
    public class DataContact
    {
        [Column("Id")]
        [Display(Name = "Código da request")]
        public int Id { get; set; }

        [Column("Name")]
        [Display(Name = "Nome da pessoa")]
        public string Name { get; set; } = string.Empty;

        [Column("Email")]
        [Display(Name = "Email da pessoa")]
        public string Email { get; set; } = string.Empty;

        [Column("Request")]
        [Display(Name = "Requisição da pessoa")]
        public string Request { get; set; } = string.Empty;
    }
}
