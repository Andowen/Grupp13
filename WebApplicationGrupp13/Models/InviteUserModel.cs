using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationGrupp13.Models {
    public class InviteUserModel {
        public IEnumerable<string> SelectedUsers { get; set; }
        public IEnumerable<SelectListItem> AllUsers { get; set; }
    }
}