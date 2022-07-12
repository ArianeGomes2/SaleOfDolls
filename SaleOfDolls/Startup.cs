namespace SaleOfDolls
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configurantion = configuration;
        }

        public IConfiguration Configurantion { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {

        }
    }
}