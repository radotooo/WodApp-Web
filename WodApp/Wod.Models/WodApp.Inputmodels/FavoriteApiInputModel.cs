using System;
using System.Collections.Generic;
using System.Text;

namespace Wod.Models.WodApp.Inputmodels
{
    public class FavoriteApiInputModel
    {
        public string UserId { get; set; }
        public int PostId { get; set; }
        public string Tittle { get; set; }
    }
}
