namespace NSE.WebApi.Core.Identidade
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
