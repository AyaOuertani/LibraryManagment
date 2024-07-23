using LibraryManagment.Interface;
using LibraryManagment.Services;

namespace LibraryManagment.Extantions
{
    public static class DIExtansion
    {
        public static IServiceCollection AddSevices(this IServiceCollection services)
        {
            return services.AddScoped<IMemberService, MemberServices>()
                           .AddScoped<IBooksService, BooksService>()
                           .AddScoped<ICategoriesService, CategoriesService>()
                           .AddScoped<ILoanService, LoanService>();
        }
    }
}
