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

        public List<Tattoo> GetTattoos()
        {
            return new List<Tattoo>(DBconnection.connection.Tattoo);
        }

        public List<Tattoo> GetTattoos(int idTattooType)
        {
            ObservableCollection<Tattoo> tattoos = new ObservableCollection<Tattoo>(DBconnection.connection.Tattoo);

            return tattoos.Where(a => a.IdTattooType == idTattooType).ToList();
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

        public bool AddNewReauest(Request request)
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

        public List<Request> GetRequests()
        {
            return new List<Request>(DBconnection.connection.Request); ;
        }

        public List<Request> GetRequests(User user)
        {
            ObservableCollection<Request> requests = new ObservableCollection<Request>(DBconnection.connection.Request);
            List<Request> currentUserRequests = requests.Where(r => r.IdUser == user.IdUser).ToList();
            return currentUserRequests;
        }

        public List<Request> GetRequests(User user, BodyPart bodyPart)
        {
            List<Request> currentUserRequests = GetRequests(user).Where(r => r.IdBodyPart == bodyPart.IdBodyPart).ToList();
            return currentUserRequests;
        }
    }
}
