using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_02
{
    public class Program
    {
        //EFCore ile oluþturacaðýmýz EF projelerinde 
        //EF.netframeworkte yaptýðýmýz gibi sihirbaz ile
        //EF ' i projeye dahil edemeyiz.
        //Bunun için kod yazmalýyýz.

        //Yazacaðýmýz kod, context ve enetity classlarýný oluþturarak modelimizi yaratacak.
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
