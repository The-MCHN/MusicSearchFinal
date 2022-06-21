using MusicSearchFinal.DAL.Entities;
using MusicSearchFinal.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.MVVM.Models
{
    class LoginModel
    {
        ObservableCollection<string> Role = new ObservableCollection<string>();
        public ObservableCollection<Users> Users { get; set; } = new ObservableCollection<Users>();

        public LoginModel()
        {
            Role = SetRole();

            var users = UsersRepository.DownloadAllUsers();
            foreach (var u in users)
                Users.Add(u);
        }

        public ObservableCollection<string> SetRole()
        {
            return new ObservableCollection<string>() {"Wyjadacz", "Laik"};
        }

        public bool AddUserToDB(Users user)
        {
            if (!IsUserInRepo(user))
            {
                if (UsersRepository.AddUserToDB(user))
                {
                    Users.Add(user);
                    return true;
                }
            }
            return false;
        }
        public bool IsUserInRepo(Users user) => Users.Contains(user);
        public bool IsUserInRepo(string Name, string Surname) 
        {
            foreach (var u in Users)
            {
                if (u.Name.Equals(Name) && u.Surname.Equals(Surname))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
