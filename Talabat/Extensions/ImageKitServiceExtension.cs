
using Imagekit.Sdk;

namespace Talabat.Extensions
{
    public static class ImageKitServiceExtension
    {
        public static void ConfigureImageKitService(
            this IServiceCollection services,
            IConfiguration configuration
        )

        {
            var config = configuration.GetSection("Bucket");
            var publicKey = config.GetValue<string>("publicKey");
            var privateKey = config.GetValue<string>("privateKey");
            var urlEndPoint = config.GetValue<string>("urlEndPoint");
            services.AddSingleton<ImagekitClient>(new ImagekitClient(
                publicKey,
                privateKey,
                urlEndPoint
            ));
        }

    }
}
