using Microsoft.Extensions.DependencyInjection;

namespace JServiceStack.Web
{
    public interface IPluginFactory
    {
        void Configure(IServiceCollection services);
    }
}