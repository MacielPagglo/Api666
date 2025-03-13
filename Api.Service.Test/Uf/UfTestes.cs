using System;
using System.Collections.Generic;
using System.Text;
using Api.Domain.Dtos.Uf;

namespace Api.Service.Test.Uf
{
    public class UfTestes
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public Guid IdUf { get; set; }

        public List<UfDto> listaUfDto = new List<UfDto>();

        public UfDto listaufDto;


        public UfTestes()
        {
            IdUf = Guid.NewGuid();
            Sigla = Faker.Address.UsState().Substring(1, 3);
            Nome = Faker.Address.UsState();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UfDto();
                {
                    IdUf = Guid.NewGuid();
                    Sigla = Faker.Address.UsState(1, 3),
                    Nome = Faker.Address.UsState()


                };

                listaUfDto.Add(dto);
            };

            UfDto = new UfDto
            {
                Id = IdUf,
                Sigla = Sigla,
                Nome = Nome

            };


        }
    }

}
