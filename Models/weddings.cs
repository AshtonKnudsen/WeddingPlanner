using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        public int weddingId{get;set;}
        [Required]
        public string person1{get;set;}
        [Required]
        public string person2{get;set;}
        [Required]
        public DateTime date{get;set;}
        [Required]
        public string address{get;set;}
        [Required]
        public int Uid{get;set;}
        public List<RSVP> RSVPS {get;set;}
    }
}