using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PagoEfectivo.Net
{
    public class ConfigurationSettings
    {
        public string AccessKey
        {
            get
            {
                return this.getSettingFromConfigurationFile("AccessKey");
            }
        }

        public string IdService
        {
            get
            {
                return this.getSettingFromConfigurationFile("IdService");
            }
        }

        public string SecretKey
        {
            get
            {
                return this.getSettingFromConfigurationFile("SecretKey");
            }
        }

        public string PagoEfectivoAPIEndpoint {
            get {
                return this.getSettingFromConfigurationFile("PagoEfectivoAPIEndpoint");
            }
        }

        private string getSettingFromConfigurationFile(string variableName)
        {
            var configurationVariable = ConfigurationManager.AppSettings[variableName];
            if (configurationVariable == null) throw new ConfigurationErrorsException($"{variableName} setting is missing on config file");
            return configurationVariable;
        }

    }
}
