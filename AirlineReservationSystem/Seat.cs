using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int SeatRow { get; set; }
        public string SeatColumn { get; set;}
        public bool IsSeatTaken { get; set; }

        private OleDbCommand _command;
        private OleDbDataReader _reader;

        //check if plane is already full (used to place passenger on waiting list)
        public bool IsPlaneFull()
        {
            using (var connection = new OleDbConnection(DatabaseObjects.connectionString))
            {
                connection.Open();
                _command = new OleDbCommand("SELECT * FROM Seats WHERE IsTaken = false", connection);
                _reader = _command.ExecuteReader();

                return !_reader.HasRows ? true : false;
            }
        }

        //check if seat is already taken
        public bool IsSeatAlreadyTaken(string seatRow, string seatColumn)
        {
            using (var connection = new OleDbConnection(DatabaseObjects.connectionString))
            {
                connection.Open();
                _command = new OleDbCommand("SELECT * FROM Seats WHERE SeatRow = @seatRow AND SeatColumn = @seatColumn AND IsTaken = false", connection);
                _command.Parameters.Add(new OleDbParameter("SeatRow", seatRow));
                _command.Parameters.Add(new OleDbParameter("SeatColumn", seatColumn));
                _reader = _command.ExecuteReader();

                return !_reader.HasRows ? true : false;
            }
        }
    }
}
