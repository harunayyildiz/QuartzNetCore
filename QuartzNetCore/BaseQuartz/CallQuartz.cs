﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Quartz.Impl;
using Quartz.Spi;

namespace QuartzNetCore.BaseQuartz
{
    public class CallQuartz
    {
        public static void UseQuartz(IServiceCollection services, params Type[] jobs)
        {
            services.AddSingleton<IJobFactory, QuartzJobFactory>();
            services.Add(jobs.Select(jobType => new ServiceDescriptor(
                jobType, jobType, ServiceLifetime.Singleton)));
            services.AddSingleton(provider =>
            {
                var sFactory = new StdSchedulerFactory();
                var scheduler = sFactory.GetScheduler().Result;
                scheduler.JobFactory = provider.GetService<IJobFactory>() ?? throw new InvalidOperationException();
                scheduler.Start();
                return scheduler;

            });

        }
    }
}
