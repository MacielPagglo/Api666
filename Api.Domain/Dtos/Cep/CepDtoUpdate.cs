using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos.Cep
{
public class CepDtoUpdate
{

    [Required(ErrorMessage = "Id é campo Obrigatorio")]
            public Guid Id { get; set; }
    [Required(ErrorMessage = "CEP é campo Obrigatório")]

    public string Cep { get; set; }

    [Required(ErrorMessage = "Logradouro é campo obrigatório")]
    public string Logradouro { get; set; }

    public string Numero { get; set; }

    [Required(ErrorMessage = "Municipio é campo obrigatório")]

    public Guid MunicipioId { get; set; }

}
}
