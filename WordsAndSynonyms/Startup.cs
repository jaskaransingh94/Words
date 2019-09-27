using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WordsAndSynonyms.Startup))]
namespace WordsAndSynonyms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
