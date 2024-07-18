using LibraryManagment.Interface;
using LibraryManagment.Services;

namespace LibraryManagment.Extantions
{
    public static class DIExtansion
    {
        public static IServiceCollection AddSevices(this IServiceCollection services)
        {
            services.AddScoped<IMemberService, MemberServices>();
            services.AddScoped<IBooksService, BooksService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<ILoanService, LoanService>();
            return services;
        }
     }
}
