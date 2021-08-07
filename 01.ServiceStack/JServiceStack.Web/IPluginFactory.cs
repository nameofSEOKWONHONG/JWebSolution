using Microsoft.Extensions.DependencyInjection;

namespace JServiceStack.WebApiBase
{
    public interface IPluginFactory
    {
        void Configure(IServiceCollection services);
    }
}