using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class UfModel : BaseModel
    {
        private string _sigla;

        public string Sigla
        {
            get { return _sigla; }
            set { _sigla = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }
    }
}
