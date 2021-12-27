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
        public static ObservableCollection<TattooType> GetTattooTypes()
        {
            ObservableCollection<TattooType> tattooTypes = new ObservableCollection<TattooType>(DBconnection.connection.TattooType);
            return tattooTypes;
        }
        public static TattooType GetTattooType(int idTattooType)
        {
            ObservableCollection<TattooType> tattooTypes = GetTattooTypes();
            var type = tattooTypes.Where(tt => tt.IdTattoType == idTattooType).FirstOrDefault();
            return type;
        }

        public static ObservableCollection<BodyPart> GetBodyParts()
        {
            ObservableCollection<BodyPart> bodyParts = new ObservableCollection<BodyPart>(DBconnection.connection.BodyPart);
            return bodyParts;
        }

        public static BodyPart GetBodyPart(int idBodyPart)
        {
            ObservableCollection<BodyPart> bodyParts = GetBodyParts();
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

        public static User GetUser(int idUser)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(DBconnection.connection.User);

            var currentUser = users.Where(u => u.IdUser == idUser).FirstOrDefault();

            return currentUser;
        }

        public static ObservableCollection<Tattoo> GetTattoos()
        {
            ObservableCollection<Tattoo> tattoos = new ObservableCollection<Tattoo>(DBconnection.connection.Tattoo);
            return tattoos;
        }

        public static List<Tattoo> GetTattoos(int idTattooType)
        {
            ObservableCollection<Tattoo> tattoos = GetTattoos();
            return tattoos.Where(a => a.IdTattooType == idTattooType).ToList();
        }

        public static Tattoo GetTattoo(string name)
        {
            ObservableCollection<Tattoo> tattoos = GetTattoos();
            return tattoos.Where(t => t.Name == name).FirstOrDefault();
        }

        public static Tattoo GetTattoo(int idTattoo)
        {
            ObservableCollection<Tattoo> tattoos = GetTattoos();
            return tattoos.Where(t => t.IdTattoo == idTattoo).FirstOrDefault();
        }

        public static bool AddNewTattoo(Tattoo tattoo)
        {
            try
            {
                DBconnection.connection.Tattoo.Add(tattoo);
                DBconnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void DeleteRequest(int idRequest)
        {
            Request request = GetRequest(idRequest);

            DBconnection.connection.Request.Remove(request);
            DBconnection.connection.SaveChanges();
        }

        public static void UpdtaeRequest(int idRequest, Request request)
        {
            DBconnection.connection.Request.SingleOrDefault(r => r.IdRequest == idRequest);
            DBconnection.connection.SaveChanges();

        }

        public static void DeleteRequest(Request request)
        {
            DBconnection.connection.Request.Remove(request);
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
            List<Request> request = new List<Request>(DBconnection.connection.Request);
            List<Request> requests = new List<Request>();
            foreach (var r in request)
            {
                requests.Add(
                    new Request
                    {
                        IdRequest = r.IdRequest,
                        IdBodyPart = r.IdBodyPart,
                        IdTattoo = r.IdTattoo,
                        IdUser = r.IdUser,
                        Date = r.Date
                    });
            }
            return requests;
        }

        public static List<Request> GetRequests(User user)
        {
            List<Request> requests = GetRequests();
            List<Request> currentUserRequests = requests.Where(r => r.IdUser == user.IdUser).ToList();
            return currentUserRequests;
        }

        public static Request GetRequest(int idRequest)
        {
            List<Request> requests = GetRequests();
            Request request = requests.Where(r => r.IdRequest == idRequest).FirstOrDefault();
            return request;
        }

        public static List<SpecialRequest> GetSpecialRequests(User user)
        {
            var requests = GetRequests(user);
            List<SpecialRequest> Requests = new List<SpecialRequest>();
            foreach (var r in requests)
            {
                Requests.Add(new SpecialRequest
                {
                    IdRequest = (int)r.IdRequest,
                    IdUser = (int)r.IdUser,
                    IdTattoo = (int)r.IdTattoo,
                    IdBodyPart = (int)r.IdBodyPart,
                    Date = (DateTime)r.Date
                });
            }

            return Requests;
        }
    }
}
