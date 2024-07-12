using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Net.Abstraction
{
    public class Logger
    {
        private static ILoggerFactory GetFactory()
        {
            var loggerFactory = ApplicationCore.Current.ServiceProvider.GetService<ILoggerFactory>();
            if (loggerFactory == null)
            {
                throw new NotImplementedException($"{nameof(ILoggerFactory)} is not resolved");
            }
            return loggerFactory;
        }

        private static readonly Lazy<ILogger> _globalLogger = new(() =>
        {
            var loggerFactory = GetFactory();
            return loggerFactory.CreateLogger("Global");
        });

        /// <summary>
        /// 方式一：全局唯一Logger
        /// </summary>
        public static ILogger Current
        {
            get
            {
                return _globalLogger.Value;
            }
        }

        /// <summary>
        /// 方式二：通过T 创建特定Logger
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ILogger<T> CreateLogger<T>()
        {
            var loggerFactory = GetFactory();
            return loggerFactory.CreateLogger<T>();
        }
    }
}
