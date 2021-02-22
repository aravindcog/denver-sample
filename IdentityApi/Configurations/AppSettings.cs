using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApi.Configurations
{
    public class AppSettings
    {
        public SftpSettings SftpSettings { get; set; }
        public StartUpSettings StartUpSettings { get; set; }
    }

    public class StartUpSettings
    {
        public string SwaggerUrl { get; set; }
    }

    public class SftpSettings
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string MBMCSourcePath { get; set; }
        public string MBMCDestinationPath { get; set; }
    }
}
