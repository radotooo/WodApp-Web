using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using WodApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using WodApp.Services;
using WodApp.Services.Test;
using Microsoft.AspNetCore.Http;
using Wod.Data;
using LearningSystem.Repository;
using LearningSystem.Repository.Contracts;
using CloudinaryDotNet;
using Wod.Services.Claudinary.Contracts;
using Wod.Services.Claudinary;
using Wod.Services.Claims;

using WodApp.Models;
using System.Reflection;
using Wod.Services.PostService.Contracts;
using Wod.Services.PostService;
using Wod.Services.CategoryService.Contracts;
using Wod.Services.CategoryService;
using Wod.Services.CommentService.Contracts;
using Wod.Services.CommentService;
using Wod.Services.VoteService.Contracts;
using Wod.Services.VoteService;



namespace WodApp
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
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection"))) ;
            services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDefaultIdentity<ApplicationUser>(options =>
            { 
            options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                
            })
               
              .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddClaimsPrincipalFactory<MyUserClaimsPrincipalFactory>();

            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IHomeService, HomeService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IVoteSysService, VoteSysService>();







            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddControllersWithViews();
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });
            services.AddRazorPages();

            Account account = new CloudinaryDotNet.Account(
               this.Configuration["Cloudinary:CloudName"],
               this.Configuration["Cloudinary:ApiKey"],
               this.Configuration["Cloudinary:ApiSecret"]);

            Cloudinary cloudinary = new Cloudinary(account);

            services.AddSingleton(cloudinary);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("Posts", "{controller=Post}/{action=ShowPost}/{id}");
                //endpoints.MapControllerRoute("Category", "{controller=Category}/{action=Index}/");
               
                endpoints.MapRazorPages();
            });
        }
    }
}
