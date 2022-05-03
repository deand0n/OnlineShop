using AutoMapper;

namespace OnlineShop.API.MapperConfigurations;

public class AutoMapperConfiguration
{
    public MapperConfiguration Configure()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductProfile>();
        });
        
        return config;
    }
}