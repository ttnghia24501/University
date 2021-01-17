using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University.Common
{
    [Serializable]
    public class StudentLogin
    {
        public long ID { get; set; }
        public string Email { get; set; }
    }
}