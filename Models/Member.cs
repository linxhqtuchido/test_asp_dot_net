using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcMembers.Models  
{  
    public class Member  
    {  
        // private MemberDBContext context;
  
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public string Email { get; set; }
    }  
}