using Microsoft.Extensions.Logging;
using Observer_Design_Pattern.DAL.Entities;
using System;
using Microsoft.Extensions.DependencyInjection;
using Observer_Design_Pattern.DAL.Context;

namespace Observer_Design_Pattern.ObserverDesignPattern
{
    public class UserObserverCreateDiscount : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;
        public UserObserverCreateDiscount(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverCreateDiscount>>();
            using var scoped = _serviceProvider.CreateScope();
            var context = scoped.ServiceProvider.GetRequiredService<Context>();

            context.Discounts.Add(new Discount
            {
                UserID = appUser.Id,
                Rate = 15
            });

            context.SaveChanges();
            logger.LogInformation("Kullanıcı için %15 oranında indirim tanımlandı");
        }
    }
}
