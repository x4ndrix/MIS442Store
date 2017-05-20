using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIS442Store.DataLayer.DataModels;
using MIS442Store.Models;

namespace MIS442Store.DataLayer.Interfaces
{
    public interface IRegistrationRepository
    {

        //List<Registration> GetList();

        List<Registration> GetUserRegistrations(string username);
        List<Registration> GetRegistrations();
        Registration GetRegistration(int id);
        void SaveRegistration(Registration registration);
    }
}
