using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Telelinkedin.Models;

namespace Telelinkedin.ViewModels
{
    public class SkillViewModel
    {
        public static SkillViewModel CreateViewModel(Skill skill)
        {
            var model = new SkillViewModel();
            model.Id = skill.Id;
            model.Name = skill.Name;
            model.Endorsements = skill.Endorsements.Select(x => ProfileConnectionViewModel.CreateViewModel(x.Endorser));

            return model;
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public bool CanBeEndorsed { get; set; }

        [ScaffoldColumn(false)]
        public bool AlreadyEndorsed { get; set; }

        [UIHint("Connections")]
        public IEnumerable<ProfileConnectionViewModel> Endorsements { get; set; }
    }
}