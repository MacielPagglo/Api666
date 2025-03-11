using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Entities;

namespace Domain.Entities
{
    public class UfEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string Sigla { get; set; }

        [Required]
        [MaxLength(45)]
        public string Nome { get; set; }

        // Um UF pode ter vários municípios
        public IEnumerable<MunicipioEntity> Municipios { get; set; }

        // CodIBGE do estado (se necessário, como int ou string)
        public int CodIBGE { get; set; }

        // Lista de CEPs associados a este estado, via municípios
        public IEnumerable<CepEntity> Ceps { get; set; }
        public object Uf { get; set; }
        public object Cep { get; set; }
    }
}
