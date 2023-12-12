using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservationSystem
{
    public partial class FormEditDelete : Form
    {
        //create DB objects
        private DataTable table;
        private OleDbCommand command;
        private OleDbDataReader reader;

        public FormEditDelete(DataTable table)
        {
            InitializeComponent();
            this.table = table;
            command = new OleDbCommand();

        }

        //bind the form objects to the data from the DataTable
        private void FormEditDelete_Load(object sender, EventArgs e)
        {
            //bind text boxes
            txtPassengerId.DataBindings.Add("Text", table, "ID");
            txtPassengerName.DataBindings.Add("Text", table, "Name");
            txtSeatId.DataBindings.Add("Text", table, "SeatID");

            //bind drop downs
            //if seats are empty (passenger is on waiting list)
            //make the first index in drop down selected ("None" for seat row and column)
            var r = table.Rows[0]["SeatRow"].ToString();
            var row = r.Equals("") ? 0 : Convert.ToInt32(r);
            var c = table.Rows[0]["SeatColumn"].ToString();
            var column = c.Equals("") ? "None" : c;
            cmbSeatRow.SelectedIndex = row;
            cmbSeatColumn.SelectedItem = column;

            chkWaitingList.Checked = Convert.ToBoolean(table.Rows[0]["OnWaitingList"]);
        }

        //edit record
        private void btnPerformEdit_Click(object sender, EventArgs e)
        {
            //validate input
            //make sure passenger name has benn entered
            if (txtPassengerName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Passenger Name is required", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //passenger cannot be on waiting list and have seat assigned
            if (chkWaitingList.Checked && (cmbSeatRow.SelectedIndex > 0 || cmbSeatColumn.SelectedIndex > 0))
            {
                MessageBox.Show("Passenger cannot be on waiting list and have a seat assigned", "Bad input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //passenger must be either on waiting list or have seat assigned
            if (!chkWaitingList.Checked && (cmbSeatRow.SelectedIndex <= 0 || cmbSeatColumn.SelectedIndex <= 0))
            {
                MessageBox.Show("Passenger seat hat to have row and column assigned", "Bad input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //update record
            //1. Get the id of the new seat
            //2. Check if the new seat is already taken
            //  if so, then ignore that the seat is taken (it is taken by the same passegner
            // 4. Update all tables
            //      - update passenger name in Passenger table
            //      - update seats table, the old seat needs to be updated to not taken, and new seat to taken
            using (var connection = new OleDbConnection(DatabaseObjects.connectionString))
            {
                connection.Open();
                command = new OleDbCommand("SELECT SeatID, IsTaken FROM Seats WHERE SeatRow = @SeatRow AND SeatColumn = @SeatColumn", connection);
                command.Parameters.Add(new OleDbParameter("SeatRow", cmbSeatRow.SelectedItem));
                command.Parameters.Add(new OleDbParameter("SeatColumn", cmbSeatColumn.SelectedItem));
                reader = command.ExecuteReader();

                var newSeatID = 0;
                bool newIsTaken = false;
                while (reader.Read())
                {
                    newSeatID = Convert.ToInt32(reader["SeatID"]);
                    newIsTaken = Convert.ToBoolean(reader["IsTaken"]);
                }

                //check if only the name is being updated
                //if not, exit beacause the user needs to pick a different seat
                var oldId = 0;
                if (txtSeatId.Text.Equals(""))
                    oldId = 0;
                else
                    oldId = Convert.ToInt32(txtSeatId.Text);

                if (newSeatID != oldId && newIsTaken)
                {
                    MessageBox.Show("Seat is already taken", "Seat taken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //update passenger's name
                command = new OleDbCommand("UPDATE Passengers SET PassengerName = @PassengerName, PassengerOnWaitingList = @OnWaitingList WHERE PassengerID = @PassengerID", connection);
                command.Parameters.Add(new OleDbParameter("PassengerName", txtPassengerName.Text));
                command.Parameters.Add(new OleDbParameter("OnWaitingList", chkWaitingList.Checked));
                command.Parameters.Add(new OleDbParameter("PassengerID", txtPassengerId.Text));
                command.ExecuteNonQuery();

                command = new OleDbCommand("UPDATE Seats SET IsTaken = false WHERE SeatID = @seatId", connection);
                command.Parameters.Add(new OleDbParameter("seatID", txtSeatId.Text));
                command.ExecuteNonQuery();

                //update old seatID with the new one
                command = new OleDbCommand("UPDATE PassengerSeats SET SeatID = @SeatID WHERE PassengerID = @PassengerID", connection);
                command.Parameters.Add(new OleDbParameter("SeatID", newSeatID));
                command.Parameters.Add(new OleDbParameter("PassengerID", txtPassengerId.Text));
                command.ExecuteNonQuery();

                MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //ask user if he wants to delete passenger

            //if not to delete, then exit and do nothing

            //if to delete, then delete passenger from Passengers and PassengersSeat table
            
            //the seat still exists, but we need to update the Seats Table and marke the seat as not taken
            using (var connection = new OleDbConnection(DatabaseObjects.connectionString))
            {
                connection.Open();
                var message = MessageBox.Show("Are you sure you want to delete " + txtPassengerName + " from the database?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (message == DialogResult.No) return;

                command = new OleDbCommand("DELETE FROM Passengers WHERE {PassengerID = @PassengerID", connection);
                command.Parameters.Add(new OleDbParameter("PassengerID", txtPassengerId.Text));
                command.ExecuteNonQuery();

                command = new OleDbCommand("DELETE FROM PassengerSeats WHERE PassengerID = @PassengerID", connection);
                command.Parameters.Add(new OleDbParameter("PassengerID", txtPassengerId.Text));
                command.ExecuteNonQuery();

                if (!txtSeatId.Text.Equals(""))
                {
                    command = new OleDbCommand("UPDATE FROM Seats SET IsTaken = false WHERE seatID = @seatID", connection);
                    command.Parameters.Add(new OleDbParameter("SeatID", txtSeatId.Text));
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Record has been deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
