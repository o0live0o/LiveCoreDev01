using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LiveCore.Api
{
    //基础设施配置 很少发生变化
    //Httpserver
    //集成IIS
    //配置信息来源
    public class Program
    {
        public static void Main(string[] args)
        {
            //Nlog  Nlog.Web.AspNetCore
            // var logger = NLog.Web.NlogBuilder.ConfigerNLog("xxx.config").getCurrentClassLogger
            //logger.Debug("");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        //创建默认主机生成器
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.ConfigureLogging((context,builder)=>builder.SetMinimumLevel(LogLevel.Debug));
                    //webBuilder.ConfigureKestrel((context,options)=>options.Limits.MaxRequestBodySize = null);
                    //webBuilder.UseUrls("http://*:8888");  //配置文件的优先级高   配置文件 命令行 硬编码 环境变量
                    //dotnet xxx.dll --urls "http//*:8888"
                    //指定Web应用的启动类
                    webBuilder.UseStartup<Startup>();
                    // webBuilder.UseStartup(Assembly.)
                });
    }
}
