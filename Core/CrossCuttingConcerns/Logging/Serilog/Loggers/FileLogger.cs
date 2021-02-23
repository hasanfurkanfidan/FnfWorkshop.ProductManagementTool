﻿using Core.CrossCuttingConcerns.Logging.Serilog.Loggers.LoggerConfigurations;
using Core.Utilities.IOC;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class FileLogger:LoggerServiceBase
    {
        public FileLogger()
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();


            var logFilePath = string.Format("{0}{1}", Directory.GetCurrentDirectory() + @"\log\", ".txt");

            Logger = new LoggerConfiguration()
                    .WriteTo.File(logFilePath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null,
                    fileSizeLimitBytes: 5000000,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
                    .CreateLogger();
        }

    }
}
