using Microsoft.EntityFrameworkCore;
using Infraestructura.EF;
using LibreriaLogicaNegocio.RepoInterfaces;
using LibreriaLogicaNegocio.ApplicationInterfaces;
using LibreriaLogicaAplicacion.Dtos.Expense;
using LibreriaLogicaNegocio.Entities;
using LibreriaLogicaAplicacion.CU.ExpenseCu;
using LibreriaLogicaAplicacion.Dtos.Payment;
using LibreriaLogicaAplicacion.Mapper;
using LibreriaLogicaAplicacion.CU.PaymentCu;
using LibreriaLogicaAplicacion.Dtos.User;
using LibreriaLogicaAplicacion.CU.UserCu;
using Infraestructura.Data;
using LibreriaLogicaNegocio.CasosDeUso;
using LibreriaLogicaAplicacion.Dtos.Team;
using LibreriaLogicaAplicacion.CU.Team;
using LibreriaLogicaAplicacion.Dtos.Log;
using LibreriaLogicaAplicacion.CU.LogCu;
using API.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Injections
            builder.Services.AddScoped<IExpenseRepo, ExpenseRepo>();
            builder.Services.AddScoped<IUserRepo, UsersRepo>();
            builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
            builder.Services.AddScoped<ILogRepo, LogRepo>();
            builder.Services.AddScoped<ITeamRepo, TeamRepo>();

            // CU
            builder.Services.AddScoped<ICULogin<UserLoginDto>, UserLogin>();
            builder.Services.AddScoped<ICuGetAll<UserIndexDto>, GetAllUsers>();
            builder.Services.AddScoped<ICuGetByHigherAmount<UserIndexDto>, GetUsersByHigherAmount>();
            builder.Services.AddScoped<ICuAdd<UserCreateDto>, CreateUser>();
            builder.Services.AddScoped<ICuGetAll<TeamForSelectDto>, GetAllTeamsForSelect>();
            builder.Services.AddScoped<ICuGetAll<UserSelectDto>, GetAllUsersForSelect>();
            builder.Services.AddScoped<ICuGetPaymentsByUserId<GetAllPaymentsDto>, GetPaymentsByUserId>();
            builder.Services.AddScoped<ICuUpdatePassword<UserResetDto>, ResetPassword>();
            builder.Services.AddScoped<ICuGetTeamsWithHigherPayments<TeamDto>, GetTeamsWithHigherPayments>();

            // Expenses
            builder.Services.AddScoped<ICuAdd<AddExpenseDto>, AddExpense>();
            builder.Services.AddScoped<ICuGetAll<ExpenseDto>, GetAllExpense>();
            builder.Services.AddScoped<ICuDelete<ExpenseDto>, DeleteExpense>();
            builder.Services.AddScoped<ICuGetById<ExpenseDto>, GetExpenseById>();
            builder.Services.AddScoped<ICuUpdate<ExpenseDto>, UpdateExpense>();
            builder.Services.AddScoped<GetLogsByExpenseId>();

            // Payments
            builder.Services.AddScoped<ICuAdd<AddPaymentDto>, AddPayment>();
            builder.Services.AddScoped<ICuGetAll<GetAllPaymentsDto>, GetAllPayments>();
            builder.Services.AddScoped<ICuGetPaymentByYearMonth<GetAllPaymentsDto>, GetPaymentByYearMonth>();
            builder.Services.AddScoped<PaymentMapper>();
            builder.Services.AddScoped<ICuGetById<GetAllPaymentsDto>, GetPaymentById>();
            builder.Services.AddScoped<ICuAddPaymentAPI<AddPaymentDto>, AddPaymentAPI>();
            builder.Services.AddScoped<ICuGetTeamsWithHigherPayments<TeamDto>, GetTeamsWithHigherPayments>();

            // JWT settings
            var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
            builder.Services.AddSingleton(jwtSettings);

            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.Key))
                    };
                });

            builder.Services.AddScoped<IJwtGenerator<AuthenticatedUserDto>, JwtGenerator>();

            builder.Services.AddAuthorization();

            // Database
            builder.Services.AddDbContext<LibreriaContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Libreria"));
            });

            // Seeder
            builder.Services.AddScoped<SeedData>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
