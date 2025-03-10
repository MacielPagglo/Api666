using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit.Sdk;

namespace Domain.Dtos.Municipio
{
    public   class MunicipioDtoUpdate
    {
        [Required(ErrorMessage = "Id é Campo Obrigatorio")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome de Município é Campo Obrigatorio")]
        [StringLength(60, ErrorMessage = "Nome de Municipio deve ter no máximo {1} caracteres. ")]
        public string Nome { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "O Código do IBGE Inválido")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Código de UF é Campo Obrigatorio")]
        public Guid UfId { get; set; }
    }
}
