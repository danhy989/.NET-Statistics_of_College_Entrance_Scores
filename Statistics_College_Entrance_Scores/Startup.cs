﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawl_College_Entrance_Scores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Statistics_College_Entrance_Scores.Repository;
using Statistics_College_Entrance_Scores.Service;

namespace Statistics_College_Entrance_Scores
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
            services.AddDbContext<EntranceScoresContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IMajorService,MajorService>();
            services.AddScoped<IMajorRepository, MajorRepository>();
            services.AddScoped<IMajorCollegeRepository, MajorCollegeRepository>();
            services.AddScoped<ICollegeRepository, CollegeRepository>();
            services.AddScoped<ICollegeService, CollegeService>();
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
