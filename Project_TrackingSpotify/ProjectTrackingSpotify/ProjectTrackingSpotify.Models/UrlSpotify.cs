﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackingSpotify.Models
{
    public class UrlSpotify
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public string Challenge { get; set; }
        public string Verifier { get; set; }
        
    }
}
