namespace AirlineReservationSystem
{
    partial class FormEditDelete
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassengerId = new System.Windows.Forms.TextBox();
            this.txtPassengerName = new System.Windows.Forms.TextBox();
            this.txtSeatId = new System.Windows.Forms.TextBox();
            this.chkWaitingList = new System.Windows.Forms.CheckBox();
            this.btnPerformEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbSeatRow = new System.Windows.Forms.ComboBox();
            this.cmbSeatColumn = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Passenger ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Passenger name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Seat ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Seat row";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Seat column";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "On waiting list";
            // 
            // txtPassengerId
            // 
            this.txtPassengerId.Location = new System.Drawing.Point(183, 39);
            this.txtPassengerId.Name = "txtPassengerId";
            this.txtPassengerId.ReadOnly = true;
            this.txtPassengerId.Size = new System.Drawing.Size(218, 22);
            this.txtPassengerId.TabIndex = 7;
            // 
            // txtPassengerName
            // 
            this.txtPassengerName.Location = new System.Drawing.Point(183, 82);
            this.txtPassengerName.Name = "txtPassengerName";
            this.txtPassengerName.Size = new System.Drawing.Size(218, 22);
            this.txtPassengerName.TabIndex = 8;
            // 
            // txtSeatId
            // 
            this.txtSeatId.Location = new System.Drawing.Point(183, 125);
            this.txtSeatId.Name = "txtSeatId";
            this.txtSeatId.ReadOnly = true;
            this.txtSeatId.Size = new System.Drawing.Size(218, 22);
            this.txtSeatId.TabIndex = 9;
            // 
            // chkWaitingList
            // 
            this.chkWaitingList.AutoSize = true;
            this.chkWaitingList.Location = new System.Drawing.Point(183, 270);
            this.chkWaitingList.Name = "chkWaitingList";
            this.chkWaitingList.Size = new System.Drawing.Size(18, 17);
            this.chkWaitingList.TabIndex = 13;
            this.chkWaitingList.UseVisualStyleBackColor = true;
            // 
            // btnPerformEdit
            // 
            this.btnPerformEdit.Location = new System.Drawing.Point(62, 326);
            this.btnPerformEdit.Name = "btnPerformEdit";
            this.btnPerformEdit.Size = new System.Drawing.Size(100, 31);
            this.btnPerformEdit.TabIndex = 14;
            this.btnPerformEdit.Text = "Perfom Edit";
            this.btnPerformEdit.UseVisualStyleBackColor = true;
            this.btnPerformEdit.Click += new System.EventHandler(this.btnPerformEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(202, 326);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 31);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(342, 326);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 31);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbSeatRow
            // 
            this.cmbSeatRow.FormattingEnabled = true;
            this.cmbSeatRow.Items.AddRange(new object[] {
            "None",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbSeatRow.Location = new System.Drawing.Point(183, 168);
            this.cmbSeatRow.Name = "cmbSeatRow";
            this.cmbSeatRow.Size = new System.Drawing.Size(218, 24);
            this.cmbSeatRow.TabIndex = 17;
            // 
            // cmbSeatColumn
            // 
            this.cmbSeatColumn.FormattingEnabled = true;
            this.cmbSeatColumn.Items.AddRange(new object[] {
            "None",
            "A",
            "B",
            "C",
            "D"});
            this.cmbSeatColumn.Location = new System.Drawing.Point(183, 213);
            this.cmbSeatColumn.Name = "cmbSeatColumn";
            this.cmbSeatColumn.Size = new System.Drawing.Size(218, 24);
            this.cmbSeatColumn.TabIndex = 18;
            // 
            // FormEditDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(521, 406);
            this.Controls.Add(this.cmbSeatColumn);
            this.Controls.Add(this.cmbSeatRow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPerformEdit);
            this.Controls.Add(this.chkWaitingList);
            this.Controls.Add(this.txtSeatId);
            this.Controls.Add(this.txtPassengerName);
            this.Controls.Add(this.txtPassengerId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormEditDelete";
            this.Text = "Edit or Delete";
            this.Load += new System.EventHandler(this.FormEditDelete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassengerId;
        private System.Windows.Forms.TextBox txtPassengerName;
        private System.Windows.Forms.TextBox txtSeatId;
        private System.Windows.Forms.CheckBox chkWaitingList;
        private System.Windows.Forms.Button btnPerformEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbSeatRow;
        private System.Windows.Forms.ComboBox cmbSeatColumn;
    }
}