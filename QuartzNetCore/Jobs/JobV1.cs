using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;

namespace QuartzNetCore.Jobs
{
    public class JobV1 : IJob
    {
        private readonly ILogger _logger;

        public JobV1(ILogger<JobV1> logger)
        {
            _logger = logger;
        }
        public async Task Execute(IJobExecutionContext context)
        {
          //  _logger.LogInformation("Dependency Injection Added");
            await Console.Out.WriteLineAsync("JobV1 Execute");
        }
    }
}
