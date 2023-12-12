using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservationSystem
{
    public partial class FormReservations : Form
    {
        //passenger and seat objects
        Passenger passenger;
        Seat seat;

        //list of all seats (used to display the seats in the list box)
        public static List<Seat> seats;

        //db objects
        private OleDbCommand command;
        private OleDbDataReader reader;

        public FormReservations()
        {
            InitializeComponent();
            command = new OleDbCommand();
            seats = new List<Seat>();
        }

        //when form loads, display the list of seats and populate the drop down with seat rows
        private void FormReservations_Load(object sender, EventArgs e)
        {
            PopulateSeatRows();
            PopulateAirplane();
        }

        //add passenger
        private void btnAddPassenger_Click(object sender, EventArgs e)
        {
            //passenger and seat objects
            passenger = new Passenger();
            seat = new Seat();

            //see what seat column was selected (A, B, C or D)
            var checkedButton = Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked);

            //validate input: valid name, seat row and selection of seat column is required
            if (!passenger.IsValidPassenger(txtNamePassenger.Text) || cmbSeatRow.SelectedIndex == -1 || checkedButton == null)
            {
                MessageBox.Show("Please enter valid name and seat", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if plane is full; if it is, place passenger on waiting list
            if (seat.IsPlaneFull())
            {
                var message = MessageBox.Show("The plane is full\nAdd passenger on waiting list?", "Plane is full", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (message == DialogResult.No) return;

                using (var connection = new OleDbConnection(DatabaseObjects.connectionString))
                {
                    connection.Open();
                    command = new OleDbCommand("INSERT INTO Passengers (PassengerName, PassengerOnWaitingList) VALUES (@passengerName, true", connection);
                    command.Parameters.Add(new OleDbParameter("PassengerName", txtNamePassenger.Text));
                    command.ExecuteNonQuery();

                    command = new OleDbCommand("INSERT INTO PassengerSeats (PassengerID, SeatID) SELECT MAX(PassengerID), 0 FROM Passengers)", connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Passenger " + txtNamePassenger.Text + " was added to the waiting list", "Waiting list", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return;
            }

            //check if seat is taken; if it is, exit so the user can select a different seat
            if (seat.IsSeatAlreadyTaken(cmbSeatRow.SelectedItem.ToString(), checkedButton.Text))
            {
                MessageBox.Show("The seat is already taken - please select different seat", "Seat taken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //if everything is OK add passenger and seat to database along with the assigned seat
            //insert new passenger to Passengers db
            //update seat to Taken in Seat db
            //insert Passenger and Seat ID in Passengers db
            using (var connection = new OleDbConnection(DatabaseObjects.connectionString))
            {
                connection.Open();
                command = new OleDbCommand("INSERT INTO Passengers (PassengerName) VALUES (@passengerName)", connection);
                command.Parameters.Add(new OleDbParameter("PassengerName", txtNamePassenger.Text));
                command.ExecuteNonQuery();

                command = new OleDbCommand("UPDATE Seats SET IsTaken = true WHERE SeatRow = @SeatRow AND SeatColumn = @SeatColumn", connection);
                command.Parameters.Add(new OleDbParameter("SeatRow", cmbSeatRow.Text));
                command.Parameters.Add(new OleDbParameter("SeatColumn", checkedButton.Text));
                command.ExecuteNonQuery();

                command = new OleDbCommand("INSERT INTO PassegerSeats (SeatID, PassengerID) " +
                    "SELECT Seats.SeatsID, (SELECT MAX(PassengerID FROM Passengers)" +
                    "FROM Seats WHERE Seat.SeatRow = @SeatRow AND Seat.SeatColumn = @SeatColumn", connection);
                command.Parameters.Add(new OleDbParameter("SeatRow", cmbSeatRow.Text));
                command.Parameters.Add(new OleDbParameter("SeatColumn", checkedButton.Text));
                command.ExecuteNonQuery();

                MessageBox.Show("Passenger has been added", "Added passenger", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PopulateAirplane();
            }
        }

        //show all passengers
        private void btnShowPassengers_Click(object sender, EventArgs e)
        {
            //get all passenger information from all 3 tables (will use Inner Join)
            //place the result into DataTable and display the result in Lookups form
            //when focus is back, repopulate the list box with updated records
            using (var connection = new OleDbConnection(DatabaseObjects.connectionString))
            {
                connection.Open();
                command = new OleDbCommand
                    ("SELECT p.PassengerID as ID, p.PassengerName AS Name, s.SeatRow, s.SeatColumn, p.PassengerOnWaitingList AS OnWaitingList " +
                    "FROM (Passengers p " +
                    "INNER JOIN PassengerSeats ps ON p.PassengerID = ps.PassengerID) " +
                    "INNER JOIN Seats s ON s.SeatID = ps.SeatID " +
                    "UNION " +
                    "SELECT p.PassengerID, p.PassengerName, null, null, p.PassengerOnWaitingList " +
                    "FROM Passengers p " +
                    "WHERE p.PassengerOnWaitingList = true " +
                    "ORDER BY s.SeatRow, s.SeatColumn", connection);
                command.Parameters.Add(new OleDbParameter("PassengerName", "%" + txtNamePassenger.Text + "%"));
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                FormPassengerLookup form = new FormPassengerLookup(dt);
                form.ShowDialog();
                PopulateAirplane();
            }
        }

        //search for passenger
        private void btnSearchPassenger_Click(object sender, EventArgs e)
        {
            //make surer a seach string was entered in the text box
            //get all passengers that match the seach string; get all the information from all 3 tables
            //place the result in a DataTable and then display it in Lookups form
            using (var connection = new OleDbConnection(DatabaseObjects.connectionString))
            {
                connection.Open();
                if (!txtNamePassenger.Text.Trim().Equals(""))
                {
                    command = new OleDbCommand
                    ("SELECT p.PassengerID as ID, p.PassengerName AS Name, s.SeatRow, s.SeatColumn, p.PassengerOnWaitingList AS OnWaitingList " +
                    "FROM (Passengers p " +
                    "INNER JOIN PassengerSeats ps ON p.PassengerID = ps.PassengerID) " +
                    "INNER JOIN Seats s ON s.SeatID = ps.SeatID " +
                    "WHERE p.PassengerName LIKE @PassengerName " +
                    "UNION " +
                    "SELECT p.PassengerID, p.PassengerName, null, null, p.PassengerOnWaitingList " +
                    "FROM Passengers p " +
                    "WHERE p.PassengerOnWaitingList = true AND p.PassengerName LIKE @PassengerName " +
                    "ORDER BY s.SeatRow, s.SeatColumn", connection);
                    command.Parameters.Add(new OleDbParameter("PassengerName",  "%" + txtNamePassenger.Text + "%"));
                }
                else
                {
                    MessageBox.Show("Please enter a valid name", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //display the seats in list box
        private void PopulateAirplane()
        {
            //clear previous listbox and list of seats
            lstOutput.Items.Clear();
            seats.Clear();


            //Select * seats from Seats db; read result andcreate a seat obecjt with 
            //ID, Row, Column and IsTaken property from the reader

            //add the seats object to the list

            //loop through the list and display the content in the list box
            using (var connection = new OleDbConnection(DatabaseObjects.connectionString))
            {
                connection.Open();
                command = new OleDbCommand("SELECT * FROM Seats ORDER BY SeatRow, SeatColumn", connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var seat = new Seat();
                    seat.SeatId = Convert.ToInt32(reader["SeatID"]);
                    seat.SeatRow = Convert.ToInt32(reader["SeatRow"]);
                    seat.SeatColumn = reader["SeatColumn"].ToString();
                    seat.IsSeatTaken = Convert.ToBoolean(reader["IsTaken"]);
                    seats.Add(seat);
                }

                string message = "";
                int counter = 0;
                for (int i = 0; i < seats.Count; i++)
                {
                    counter++;
                    if (seats[i].IsSeatTaken)
                        message += "  " + "XX" + "   ";
                    else
                        message += "  " + seats[i].SeatRow + seats[i].SeatColumn + "   ";

                    if (counter % 4 == 0)
                    {
                        lstOutput.Items.Add(message);
                        message = "";
                    }
                    else if (counter % 2 == 0)
                    {
                        message += "      ";
                    }
                }
            }
        }

        //populate drop down with seat rows
        private void PopulateSeatRows()
        {
            //get row numbers
            using (var connection = new OleDbConnection(DatabaseObjects.connectionString))
            {
                connection.Open();
                command = new OleDbCommand("SELECT DISTINCT SeatRow FROM Seats ORDER BY SeatRow", connection);
                reader=command.ExecuteReader();

                while (reader.Read())
                {
                    cmbSeatRow.Items.Add(reader["SeatRow"]);
                }
            }
        }
    }
}
