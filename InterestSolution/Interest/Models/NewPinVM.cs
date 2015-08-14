using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interest.Models
{
    public class NewPinVM
    {
        InterestUser Publisher { get; set; }
        HttpPostedFileBase Image { get; set; }

    }
}