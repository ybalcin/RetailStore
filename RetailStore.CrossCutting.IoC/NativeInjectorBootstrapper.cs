using Microsoft.Extensions.DependencyInjection;
using RetailStore.Application.Services;
using RetailStore.Application.Services.Abstract;
using RetailStore.Domain.Services;
using RetailStore.Domain.Services.Abstract;

namespace RetailStore.CrossCutting.IoC;

public static class NativeInjectorBootstrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IDiscountService, DiscountService>();
        services.AddScoped<IInvoiceAppService, InvoiceAppService>();
    }
}