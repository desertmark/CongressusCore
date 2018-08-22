using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CongressusCore.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CongressusCore.Areas.Posts.Repositories;
using CongressusCore.Areas.Users.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using CongressusCore.Areas.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CongressusCore
{
    public class Startup
    {
        private static readonly string secretKey = "secret12312523";
        private static readonly string issuer = "CongressusCore";
        private static readonly string audience = "CongressusAudience";
        private static SymmetricSecurityKey signingKey;
        public IHostingEnvironment Env;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services
            .AddDbContext<MyDbContext>()
            .AddSingleton<IConfiguration>(Configuration)
            .AddTransient<PostRepository,PostRepository>();

            services
            .AddIdentity<User,IdentityRole>()
            .AddEntityFrameworkStores<MyDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters() {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,

                    ValidateIssuer = true,
                    ValidIssuer = issuer,

                    ValidateAudience = true,
                    ValidAudience = audience,

                    ClockSkew = TimeSpan.Zero

                };
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseMvc();
            app.UseAuthentication();

            app.UseJWTTokenProviderMiddleware(Options.Create(new TokenProviderOptions(){
                Audience = audience,
                Issuer = issuer,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.RsaSha256)
            }));
        }
    }
}
