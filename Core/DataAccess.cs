using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Core
{
    public static class DataAccess
    {
        public static List<TattooType> GetTattooTypes()
        {
            List<TattooType> tattooTypes = new List<TattooType>(DBconnection.connection.TattooType);
            List<TattooType> types = new List<TattooType>();
            foreach (var type in tattooTypes)
            {
                types.Add(
                    new TattooType
                    {
                        IdTattoType = type.IdTattoType,
                        Name = type.Name
                    });
            }
            return types;
        }

        public static List<BodyPart> GetBodyParts()
        {
            List<BodyPart> bodyParts = new List<BodyPart>(DBconnection.connection.BodyPart);
            List<BodyPart> parts = new List<BodyPart>();
            foreach (var part in bodyParts)
            {
                parts.Add(
                    new BodyPart
                    {
                        IdBodyPart = part.IdBodyPart,
                        Name = part.Name
                    });
            }
            return parts;
        }

        public static BodyPart GetBodyPart(int idBodyPart)
        {
            List<BodyPart> bodyParts = GetBodyParts();
            var bPart = bodyParts.Where(bp => bp.IdBodyPart == idBodyPart).FirstOrDefault();
            return bPart;
        }

        public static bool IsCorrectLogin(string login, string password)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(DBconnection.connection.User);

            var currentUser = users.Where(u => u.Login == login && u.Password == password).ToList();

            return currentUser.Count == 1;
        }

        public static User GetUser(string login, string password)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(DBconnection.connection.User);

            var currentUser = users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();

            return currentUser;
        }

        public static List<Tattoo> GetTattoos()
        {
            List<Tattoo> tattoo = new List<Tattoo>(DBconnection.connection.Tattoo);
            List<Tattoo> tattoos = new List<Tattoo>();
            foreach (var t in tattoo)
            {
                tattoos.Add(
                    new Tattoo
                    {
                        IdTattoo = t.IdTattoo,
                        Name = t.Name,
                        IdTattooType = t.IdTattooType,
                        Image = t.Image
                    });
            }
            return tattoos;
        }

        public static List<Tattoo> GetTattoos(int idTattooType)
        {
            List<Tattoo> tattoos = GetTattoos();
            return tattoos.Where(a => a.IdTattooType == idTattooType).ToList();
        }

        public static Tattoo GetTattoo(string name)
        {
            List <Tattoo> tattoos = GetTattoos();
            return tattoos.Where(t => t.Name == name).FirstOrDefault();
        }

        public static Tattoo GetTattoo(int idTattoo)
        {
            List<Tattoo> tattoos = GetTattoos();
            return tattoos.Where(t => t.IdTattoo == idTattoo).FirstOrDefault();
        }

        public static void DeleteTattoo(int idTattoo)
        {
            List<Tattoo> tattoos = GetTattoos();
            var tattoo = tattoos.Where(t => t.IdTattoo == idTattoo).FirstOrDefault();

            DBconnection.connection.Tattoo.Remove(tattoo);
            DBconnection.connection.SaveChanges();
        }

        public static void UpdateTattoo(int idTattoo, Tattoo tattoo)
        {

            DBconnection.connection.Tattoo.SingleOrDefault(t => t.IdTattoo == idTattoo);
            DBconnection.connection.SaveChanges();

        }

        public static void DeleteTattoo(Tattoo tattoo)
        { 
            DBconnection.connection.Tattoo.Remove(tattoo);
            DBconnection.connection.SaveChanges();
        }

        public static bool RegistrationUser(User user)
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

        public static bool AddNewRequest(Request request)
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
        
        public static bool AddNewRequest(int newIdUser, int newIdBodyPart, int newIdTattoo, DateTime newDate)
        {
            try
            {
                Request request = new Request()
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

        public static List<Request> GetRequests()
        {
            return new List<Request>(DBconnection.connection.Request); ;
        }

        public static List<Request> GetRequests(User user)
        {
            List<Request> requests = GetRequests();
            List<Request> currentUserRequests = requests.Where(r => r.IdUser == user.IdUser).ToList();
            return currentUserRequests;
        }
    }
}
