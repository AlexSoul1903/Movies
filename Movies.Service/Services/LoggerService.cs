using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Services
{
    public class LoggerService<TService> : Contracts.ILoggerService<TService> where TService : Core.IBaseService
    {
        private readonly ILogger<TService> logger;
        public LoggerService(ILogger<TService> logger) => this.logger = logger;
        public void LogDebug(string message, params object[] args) => this.logger.LogDebug(message, args);

        public void LogError(string message, params object[] args) => this.logger.LogError(message, args);

        public void LogInformation(string message, params object[] args) => this.logger.LogInformation(message, args);

        public void LogWarning(string message, params object[] args) => this.logger.LogWarning(message, args);
    }
}
