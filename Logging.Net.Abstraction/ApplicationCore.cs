using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Net.Abstraction
{
    public class ApplicationCore
    {
        private static IServiceProvider? _globalServiceProvider;
        private static readonly Lazy<ApplicationCore> _instanse = new(() => { return new ApplicationCore(_globalServiceProvider); });
        public static ApplicationCore Current
        {
            get
            {
                return _instanse.Value;
            }
        }

        public static void Init(IServiceProvider? serviceProvider)
        {
            _globalServiceProvider = serviceProvider;
        }

        private readonly IServiceProvider _serviceProvider;
        public IServiceProvider ServiceProvider
        {
            get
            {
                return _serviceProvider;
            }
        }

        internal ApplicationCore(IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider), $"please call {nameof(Init)} first");
        }

    }
}
