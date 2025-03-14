using FruitVegBasket.Interfaces;
using Security;
using System;

namespace FruitVegBasket.Platforms.iOS
{
    class IosHttpMessageHandler : IPlatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler() =>
             new NSUrlSessionHandler
             {
                 TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust) => url.StartsWith("https://localhost")
             };
    }
}
