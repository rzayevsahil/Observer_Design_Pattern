using Observer_Design_Pattern.DAL.Entities;

namespace Observer_Design_Pattern.ObserverDesignPattern
{
    public interface IUserObserver
    {
        void CreateUser(AppUser appUser);
    }
}
