using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class CepEntity
    {
        [Key]  // Marcar como chave primária
        public Guid Id { get; set; }  // Altere o tipo de 'object' para 'Guid'

        [Required]
        [MaxLength(10)]
        public string Cep { get; set; }

        [Required]
        [MaxLength(60)]
        public string Logradouro { get; set; }

        [MaxLength(10)]
        public string Numero { get; set; }

        [Required]
        public Guid MunicipioId { get; set; }

        public MunicipioEntity Municipio { get; set; }
        public object Uf { get; set; }  // Se 'Uf' não for chave estrangeira ou relação, pode ser mantido
    }
}
