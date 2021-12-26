using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Core
{
    public class DataAccess
    {
        public static TattooParlorEntities connection = new TattooParlorEntities();

        public List<TattooType> GetTattooTypes()
        {
            return new List<TattooType>(connection.TattooType);
        }

        public List<BodyPart> GetBodyParts()
        {
            return new List<BodyPart>(connection.BodyPart);
        }

        public bool IsCorrectLogin(string login, string password)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(DBconnection.connection.User);

            var currentUser = users.Where(u => u.Login == login && u.Password == password).ToList();

            return currentUser.Count == 1;
        }

        public User GetUser(string login, string password)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(DBconnection.connection.User);

            var currentUser = users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();

            return currentUser;
        }

        public List<Tattoo> GetTattoos()
        {
            return new List<Tattoo>(DBconnection.connection.Tattoo);
        }

        public List<Tattoo> GetTattoos(int idTattooType)
        {
            ObservableCollection<Tattoo> tattoos = new ObservableCollection<Tattoo>(DBconnection.connection.Tattoo);

            return tattoos.Where(a => a.IdTattooType == idTattooType).ToList();
        }

        public Tattoo GetTattoo(string name)
        {
            List <Tattoo> tattoos = GetTattoos();
            return tattoos.Where(t => t.Name == name).FirstOrDefault();
        }

        public bool RegistrationUser(User user)
        {
            try
            {
                DBconnection.connection.User.Add(user);
                DBconnection.connection.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
        }

        public bool AddNewRequest(Request request)
        {
            try
            {
                DBconnection.connection.Request.Add(request);
                DBconnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public bool AddNewRequest(int newIdUser, int newIdBodyPart, int newIdTattoo, DateTime newDate)
        {
            try
            {
                Request request = new Request
                {
                    IdUser = newIdUser,
                    IdBodyPart = newIdBodyPart,
                    IdTattoo = newIdTattoo,
                    Date = newDate
                };

                DBconnection.connection.Request.Add(request);
                DBconnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Request> GetRequests()
        {
            return new List<Request>(DBconnection.connection.Request); ;
        }

        public List<Request> GetRequests(User user)
        {
            List<Request> requests = GetRequests();
            List<Request> currentUserRequests = requests.Where(r => r.IdUser == user.IdUser).ToList();
            return currentUserRequests;
        }
    }
}
