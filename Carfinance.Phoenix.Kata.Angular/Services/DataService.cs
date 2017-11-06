using Carfinance.Phoenix.Kata.Angular.Services.Interfaces;
using System.Collections.Generic;
using System.Web;
using Carfinance.Phoenix.Kata.Angular.Models;
using Newtonsoft.Json;
using System.IO;
using Carfinance.Phoenix.Kata.Angular.Repository;
using System.Linq;

namespace Carfinance.Phoenix.Kata.Angular.Services
{

    /// <summary>
    /*
        This is not the file you're looking for.

                         .==.
                        ()''()-.
             .---.       ;--; /
           .'_:___". _..'.  __'.
           |__ --==|'-''' \'...;
           [  ]  :[|       |---\
           |__| I=[|     .'    '.
           / / ____|     :       '._
          |-/.____.'      | :       :
         /___\ /___\      '-'._----'

     */
    /// </summary>
    public class DataService : IDataService
    {
        private static IList<Booking> bookings;

        private RestaurantRepository _context;

        public IList<Booking> Initialize()
        {
           
            if (bookings == null)
            {
                bookings = new RestaurantRepository().All().ToList();
                //using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~/json/bookings.json")))
                //{
                //    string json = r.ReadToEnd();
                //    bookings = JsonConvert.DeserializeObject<List<Booking>>(json);
                //    //write to json file or replace this with DbContext EF to write to the Db
                //    //using (StreamWriter str = new StreamWriter(json))
                //    //{
                //    //    str.Write(HttpContext.Current.Server.MapPath("~/json/bookings.json"));
                //    //}
                //}
            }
          
            return bookings;
        }
    }
}