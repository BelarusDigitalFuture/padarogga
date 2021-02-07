using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Shared
{
    public enum Difficulty
    {
        [Display(Name = "Легко")]
        Easy,
        [Display(Name = "Нормально")]
        Normal,
        [Display(Name = "Сложно")]
        Hard            
    }
}
