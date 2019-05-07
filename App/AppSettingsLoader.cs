using App.Core;
using App.Core.Interfaces;
using Microsoft.Extensions.Options;

namespace App
{
    public class AppSettingsLoader : IAppSettingsLoader
    {
        private readonly AppSettings settings;

        public AppSettingsLoader(IOptions<AppSettings> settings)
        {
            this.settings = settings.Value;
        }

        public AppSettings GetSettings()
        {
            return settings;
        }
    }
}
