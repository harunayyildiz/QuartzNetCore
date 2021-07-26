using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;

namespace QuartzNetCore.Jobs
{
    public class JobV2 : IJob
    {
        private readonly ILogger _logger;

        public JobV2(ILogger<JobV2> logger)
        {
            _logger = logger;
        }
        public async Task Execute(IJobExecutionContext context)
        {
          //  _logger.LogInformation("Dependency Injection Added jobV2");
            await Console.Out.WriteLineAsync("JobV2 Execute");
        }
    }
}
