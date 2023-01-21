using System.Collections.Generic;
using Observer_Design_Pattern.DAL.Entities;

namespace Observer_Design_Pattern.ObserverDesignPattern
{
    public class UserObserverObject
    {
        private readonly List<IUserObserver> _userObservers;
        public UserObserverObject()
        {
            _userObservers = new List<IUserObserver>();
        }

        public void RegisterObserver(IUserObserver userObserver)
        {
            _userObservers.Add(userObserver);
        }

        public void RemoveObserver(IUserObserver userObserver)
        {
            _userObservers.Remove(userObserver);
        }

        public void NotifyObserver(AppUser appUser)
        {
            _userObservers.ForEach(x => x.CreateUser(appUser));
        }
    }
}
