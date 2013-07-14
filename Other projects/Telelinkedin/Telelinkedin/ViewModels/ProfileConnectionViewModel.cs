using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Telelinkedin.Models;

namespace Telelinkedin.ViewModels
{
    public class ProfileConnectionViewModel
    {
        public static ProfileConnectionViewModel CreateViewModel(UserProfile user)
        {
            var model = new ProfileConnectionViewModel();

            model.Id = user.UserId;
            model.Name = string.Format("{0} {1}", user.FirstName, user.LastName);
            model.Email = user.Email;

            return model;
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}