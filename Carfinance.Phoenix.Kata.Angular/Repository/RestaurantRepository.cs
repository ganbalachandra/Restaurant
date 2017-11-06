using Carfinance.Phoenix.Kata.Angular.DAL;
using Carfinance.Phoenix.Kata.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carfinance.Phoenix.Kata.Angular.Repository
{
    public class RestaurantRepository :BaseRepository<Booking>
    {
        public RestaurantRepository() : base(new RestaurantContext())
        {

        }
    }
}