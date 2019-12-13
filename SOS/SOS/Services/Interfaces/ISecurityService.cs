using SOS.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOS.Services.Interfaces
{
    public interface ISecurityService
    {
        IList<MenuItem> GetAllowedAccessItems();
        bool LogIn(string userName, string password);
        void LogOut();
    }
}
