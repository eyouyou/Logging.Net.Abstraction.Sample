using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Net.Abstraction.Sample
{
    public class Task
    {
        readonly ILogger<Task> _logger;
        public Task()
        {
            _logger = Logger.CreateLogger<Task>();
        }

        public void Run()
        {
            _logger.LogInformation("Task Run");
            Logger.Current.LogInformation("Host Task Run");
        }
    }
}
