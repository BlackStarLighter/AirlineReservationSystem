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
    public partial class FormPassengerLookup : Form
    {
        private OleDbCommand command;
        private DataTable table;

        public FormPassengerLookup(DataTable dataTable)
        {
            InitializeComponent();
            table = dataTable;
        }

        private void FormPassengerLookup_Load(object sender, EventArgs e)
        {
            dgvOutput.DataSource = table;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvOutput_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //get the row number that was clicked
            var index = e.RowIndex;

            //get the passengerID from the clicked row and pass it to the command
            int selectedId = Convert.ToInt32(dgvOutput.Rows[index].Cells[0].Value);

            //select all the passenger information from all three tables that matches
            // the passengerID of the passenger that was clicked
            using (var connection = new OleDbConnection(DatabaseObjects.connectionString))
            {
                connection.Open();
                command = new OleDbCommand
                    ("SELECT p.PassengerID as ID, s.SeatID, p.PassengerName AS Name, s.SeatRow, s.SeatColumn, p.PassengerOnWaitingList AS OnWaitingList " +
                    "FROM (Passengers p " +
                    "INNER JOIN PassengerSeats ps ON p.PassengerID = ps.PassengerID) " +
                    "INNER JOIN Seats s ON s.SeatID = ps.SeatID " +
                    "WHERE p.PassengerID = @PassengerID" +
                    "UNION " +
                    "SELECT p.PassengerID, null, p.PassengerName, null, null, p.PassengerOnWaitingList " +
                    "FROM Passengers p " +
                    "WHERE p.PassengerOnWaitingList = true AND PassengerID = @PassengerID " +
                    "ORDER BY s.SeatRow, s.SeatColumn", connection);
                command.Parameters.Add(new OleDbParameter("PassengerID", selectedId));
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                FormEditDelete form = new FormEditDelete(dt);
                form.ShowDialog();
            }

            //execute command and place results to DataTable and pass itto the EditDelete
        }
    }
}
