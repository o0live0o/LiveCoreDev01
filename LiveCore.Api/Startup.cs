using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LiveCore.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LiveCore.Api
{
    //配置自定义行为
    //组建 服务 功能
    //中间件管道
    public class Startup
    {
        private readonly IConfiguration _configuration = null;
        public Startup(IConfiguration configuration)
        {
            //多层级JSON用:读取
            _configuration = configuration;       
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //服务注册
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
             services.AddMvc();
             services.AddCors();
             services.AddDbContext<MyContext>(options=>{
                options.UseSqlite("Data Source=Live0x.db");
             });
            //services.AddSingleton<Interface,Class>();
            //services.AddScoped 作用域
            // services.AddTransient 瞬时
            //services.Configure<T>(_configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
       //配置中间件管道 处理请求 返回响应
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*,IOptions<T>*/)
        {
            // app.UseCors();
            // // 向应用程序的请求管道添加一个Func委托
            // //app.Run(c=>c.Response.WriteAsync("Hello!")); //断路式中间件，相应一切请求 
            // app.Use(async (context,next)=>{
            //     await context.Response.WriteAsync("Hello Use");
            //     await next();
            // });

            // //Map可以根据匹配的URL来执行 根据URL分支执行
            // //app.Map("/home",function);
            
            // //Run方法向应用程序请求管道添加一个RequestDelegate委托
            // //放在管道最后面 中断中间件
            // app.Run(async (context)=>{
            //     await context.Response.WriteAsync("break");
            // });
            

            //约定中间件类必须包括


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //中间件放在异常后面才能捕捉
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // app.Map("/Error",method)
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            //_configuration.Bind();
            //_configuration.GetSection("").Bind();


            app.UseEndpoints(endpoints =>
            {
                //mvc
                // endpoints.MapControllerRoute();

                //web api
                endpoints.MapControllers();
            });
        }
    }
}
