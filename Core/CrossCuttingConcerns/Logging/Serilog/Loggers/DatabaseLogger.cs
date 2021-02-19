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
using Core.CrossCuttingConcerns.Logging.Log4Net;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class DatabaseLogger:LoggerServiceBase
    {
        public DatabaseLogger()
        {
			var configuration = ServiceTool.ServiceProvider.GetService<Microsoft.Extensions.Configuration.IConfiguration>();

			var logConfig = configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration")
					.Get<MsSqlConfiguration>() ?? throw new Exception("Null");
			var sinkOpts = new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true };

			var seriLogConfig = new LoggerConfiguration()
										.WriteTo.MSSqlServer(connectionString: "Server=ProductManagementTool.mssql.somee.com;Database=ProductManagementTool;user id=hasanfurkanfidan_SQLLogin_1;password=b9w53l2io7", sinkOptions: sinkOpts)
										.CreateLogger();
			Logger = seriLogConfig;
		}
    }
}
