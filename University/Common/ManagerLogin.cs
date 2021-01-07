using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University
{
    [Serializable]
    public class ManagerLogin
    {
        public long ID { get; set; }
        public string Email { get; set; }
    }
}