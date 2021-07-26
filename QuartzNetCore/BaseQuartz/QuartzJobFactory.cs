using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using Quartz.Spi;

namespace QuartzNetCore.BaseQuartz
{
    class QuartzJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QuartzJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            //Dependency Injection
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var jobDetail = bundle.JobDetail;
            var job = (IJob)_serviceProvider.GetService(jobDetail.JobType);
            return job;
        }

        public void ReturnJob(IJob job)
        {
          //  throw new NotImplementedException();
        }
    }
}
