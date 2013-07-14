using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Telelinkedin.Models;

namespace Telelinkedin.ViewModels
{
    public class ProfileListViewModel
    {
        public static ProfileListViewModel CreateViewModel(UserProfile user)
        {
            var profileListViewModel = new ProfileListViewModel();
            profileListViewModel.Name = string.Format("{0} {1}", user.FirstName, user.LastName);
            profileListViewModel.Id = user.UserId;

            return profileListViewModel;
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}