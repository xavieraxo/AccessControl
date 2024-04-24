using AccessControlWebRazor.Data;
using Microsoft.EntityFrameworkCore;
using AccessControlWebRazor.Areas.Identity.Data;
using MediatR;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Data;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Service;
using AccessControlWebRazor.Modules.PersonalModule.Data;
using AccessControlWebRazor.Modules.UsuarioModule.Data;
using AccessControlWebRazor.Modules.UsuarioModule.Service;
using AccessControlWebRazor.Modules.PersonalModule.Service;
using AccessControlWebRazor.Integrations;
using AccessControlWebRazor.Modules.CertronicModule.Service;
using AccessControlWebRazor.Modules.CentroCostoModule.Data;
using AccessControlWebRazor.Modules.CentroCostoModule.Service;
using AccessControlWebRazor.Modules.VehiculosModule.Service;
using AccessControlWebRazor.Modules.VehiculosModule.Data;
using AccessControlWebRazor.Modules.CertronicModule.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using AccessControlWebRazor.HikVisionIntegration;
using AccessControlWebRazor.Modules.ProcessExternalModule.Service;
using AccessControlWebRazor.Modules.ProcessExternalModule.Data;
using AccessControlWebRazor.Modules.InvitadosModule.Data;
using AccessControlWebRazor.Modules.InvitadosModule.Service;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Data;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Service;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Data;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Service;
using OfficeOpenXml;
using AccessControlWebRazor.Services;

namespace AccessControlWebRazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionJavier")));
            //builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSebastian")));
            //builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionIvan2")));

            builder.Services.AddDefaultIdentity<AccessControlWebRazorUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DataContext>();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Login";
            options.AccessDeniedPath = "/AccessDenied";
            options.LogoutPath = "/Logout";
        });

            builder.Services.AddAuthorization();


            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddMediatR(typeof(Program));
            builder.Services.AddTransient<IMediator, Mediator>();
            builder.Services.AddHttpClient();

            //Repositories
            builder.Services.AddTransient<ILecturasGaritaLogRepository, LecturasGaritaLogRepository>();
            builder.Services.AddTransient<IPersonalRepository, PersonalRepository>();
            builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddTransient<ICentroCostoRepository, CentroCostoRepository>();
            builder.Services.AddTransient<Modules.VehiculosModule.Data.IVehiculoRepository, Modules.VehiculosModule.Data.VehiculoRepository>();
            builder.Services.AddTransient<IMaquinariaRepository, MaquinariaRepository>();
            builder.Services.AddTransient<Modules.CertronicModule.Data.IVehiculosRepository, Modules.CertronicModule.Data.VehiculoRepository>();
            builder.Services.AddTransient<IPersonalExtrenoRepository, PersonalExtrenoRepository>();
            builder.Services.AddTransient<IProcesamientoPersonalExternoRepository, ProcesamientoPersonalExternoRepository>();
            builder.Services.AddTransient<IInvitadosRepository, InvitadosRepository>();
            builder.Services.AddTransient<IProcesamientoPersonalRepository, ProcesamientoPersonalRepository>();
            builder.Services.AddTransient<IProcesamientoVehiculoExternoRepository, ProcesamientoVehiculoExternoRepository>();




            //Services
            builder.Services.AddTransient<ILecturaGaritaLogService, LecturaGaritaLogService>();
            builder.Services.AddTransient<IUsuarioService, UsuarioService>();
            builder.Services.AddTransient<IPersonalService, PersonalService>();
            builder.Services.AddTransient<ICertronicService, CertronicService>();
            builder.Services.AddTransient<ICentroCostoService, Modules.CentroCostoModule.Service.CentroCostoService>();
            builder.Services.AddTransient<IVehiculoService, VehiculoService>();
            builder.Services.AddTransient<IProcesamientoPersonalExternoService, ProcesamientoPersonalExternoService>();
            builder.Services.AddTransient<IInvitadosServices, InvitadosService>();
            builder.Services.AddTransient<IHttpManager, HttpManager>();
            builder.Services.AddTransient<IProcesamientoPersonalService, ProcesamientoPersonalService>();
            builder.Services.AddTransient<IProcesamientoVehiculoExternoService, ProcesamientoVehiculoExternoService>();
            builder.Services.AddTransient<IAllProcesamientosServices, AllProcesamientosServices>();





            //Integrations
            builder.Services.AddTransient<IHvAC, HvAC>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

          
            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Esto mapea los controladores API
            });
            app.MapRazorPages();

            app.Run();

        }
    }
}