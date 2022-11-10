using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    internal class AddFriendView
    {
        UserService userService;
        public AddFriendView(UserService userService)
        {
            this.userService = userService;
        }
        public void Show(User user)
        {
            string? email = "";
            try
            {
                

                Console.WriteLine("Введите email добавляемого в друзья пользователя ");

                email =  Console.ReadLine();
           
                this.userService.AddFriend(email, user.Id);

                SuccessMessage.Show("Пользователь пользователя в друзья!");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show($"Пользователя с  email:{email} не существует!");
            }

            catch (Exception ex)
            {
                AlertMessage.Show(ex.ToString());
            }

        }
    }
}
