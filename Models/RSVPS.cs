using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace WeddingPlanner.Models
{
    public class RSVP
    {
        public int RSVPId{get;set;}
        [Required]
        public int userid{get;set;}
        [Required]
        public int weddingId{get;set;}
        [Required]
        public Wedding wedding{get;set;}
        [Required]
        public User user {get;set;}
    }
}