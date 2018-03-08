using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using SoftBreeze.BlueHrm.SystemConfiguration.Dto;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Models.Qualification
{
    public class CreateOrEditSkillModel
    {
        public CreateOrEditSkillModel(SkillDto skill)
        {
            Skill = skill;
        }

        public SkillDto Skill { get; set; }
        public bool IsEditMode { get { return !Skill.Name.IsNullOrEmpty(); } }
    }
}