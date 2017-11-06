using Carfinance.Phoenix.Kata.Angular.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Carfinance.Phoenix.Kata.Angular.DAL.Mappings
{
    
        public class BookingMap : EntityTypeConfiguration<Booking>
        {
            public BookingMap()
            {
                // Primary Key
                HasKey(t => t.BookingId);

                // Properties
                Property(t => t.BookingId)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                ToTable("Restaurant_Booking");
       
            }
        }
    }
