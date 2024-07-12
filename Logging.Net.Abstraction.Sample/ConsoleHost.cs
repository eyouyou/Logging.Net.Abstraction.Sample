using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Logging.Net.Abstraction.Sample
{
    public class ConsoleHost
    {
        /// <summary>
        /// 注入形式的日志
        /// </summary>
        readonly ILogger<ConsoleHost> _logger;
        readonly Task task = new();

        public ConsoleHost(ILogger<ConsoleHost> logger)
        {
            _logger = logger;
        }


        public void Start()
        {
            _logger.LogInformation("Start");

            task.Run();
        }
    }
}
