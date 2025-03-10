using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Api.Domain.Entities;

namespace Domain.Entities
{
    public class MunicipioEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        public int CodIBGE { get; set; }

        [Required]
        public Guid UfId { get; set; }

        public UfEntity Uf { get; set; }  // Relacionamento com UfEntity, nome da propriedade alterado para 'Uf' (U maiúsculo)

        public IEnumerable<CepEntity> Ceps { get; set; }
    }
}
