using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem
{
    public class DatabaseObjects
    {
        public static string path = @"C:\Users\XRC\source\repos\airline.accdb";
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
    }
}
