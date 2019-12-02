using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShop.API.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Revenue { get; set; }
    }
}