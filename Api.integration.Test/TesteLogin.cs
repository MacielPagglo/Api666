using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Integration.Test
{
    public class TesteLogin : BaseIntegration
    {
        public async Task TesteDoToken()
        {
            await AdicionarToken();

        }
    }
}
