using Castle.Core.Configuration;
using Core.Utilities.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Threading.Tasks;
using Serilog.Configuration;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers.LoggerConfigurations;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Core.CrossCuttingConcerns.Logging.Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class DatabaseLogger : LoggerServiceBase
    {
        public DatabaseLogger()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var sinkOpts = new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true };

            var seriLogConfig = new LoggerConfiguration()
                                        .ReadFrom.Configuration(configuration)
                                        .CreateLogger();
            Logger = seriLogConfig;
        }
    }
}
