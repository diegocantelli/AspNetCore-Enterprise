using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Identitidade.API.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }

        //Issuer
        public string Emissor { get; set; }

        //Audience
        public string ValidoEm { get; set; }
    }
}
