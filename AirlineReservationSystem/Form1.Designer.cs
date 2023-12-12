namespace AirlineReservationSystem
{
    partial class FormReservations
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
            this.txtNamePassenger = new System.Windows.Forms.TextBox();
            this.cmbSeatRow = new System.Windows.Forms.ComboBox();
            this.grpBoxRadioButtons = new System.Windows.Forms.GroupBox();
            this.radioD = new System.Windows.Forms.RadioButton();
            this.radioC = new System.Windows.Forms.RadioButton();
            this.radioB = new System.Windows.Forms.RadioButton();
            this.radioA = new System.Windows.Forms.RadioButton();
            this.btnAddPassenger = new System.Windows.Forms.Button();
            this.btnShowPassengers = new System.Windows.Forms.Button();
            this.btnSearchPassenger = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpBoxRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seat";
            // 
            // txtNamePassenger
            // 
            this.txtNamePassenger.Location = new System.Drawing.Point(97, 35);
            this.txtNamePassenger.Name = "txtNamePassenger";
            this.txtNamePassenger.Size = new System.Drawing.Size(174, 22);
            this.txtNamePassenger.TabIndex = 2;
            // 
            // cmbSeatRow
            // 
            this.cmbSeatRow.FormattingEnabled = true;
            this.cmbSeatRow.Location = new System.Drawing.Point(97, 84);
            this.cmbSeatRow.Name = "cmbSeatRow";
            this.cmbSeatRow.Size = new System.Drawing.Size(174, 24);
            this.cmbSeatRow.TabIndex = 3;
            // 
            // grpBoxRadioButtons
            // 
            this.grpBoxRadioButtons.Controls.Add(this.radioD);
            this.grpBoxRadioButtons.Controls.Add(this.radioC);
            this.grpBoxRadioButtons.Controls.Add(this.radioB);
            this.grpBoxRadioButtons.Controls.Add(this.radioA);
            this.grpBoxRadioButtons.Location = new System.Drawing.Point(97, 131);
            this.grpBoxRadioButtons.Name = "grpBoxRadioButtons";
            this.grpBoxRadioButtons.Size = new System.Drawing.Size(174, 95);
            this.grpBoxRadioButtons.TabIndex = 4;
            this.grpBoxRadioButtons.TabStop = false;
            // 
            // radioD
            // 
            this.radioD.AutoSize = true;
            this.radioD.Location = new System.Drawing.Point(108, 51);
            this.radioD.Name = "radioD";
            this.radioD.Size = new System.Drawing.Size(38, 20);
            this.radioD.TabIndex = 3;
            this.radioD.TabStop = true;
            this.radioD.Text = "D";
            this.radioD.UseVisualStyleBackColor = true;
            // 
            // radioC
            // 
            this.radioC.AutoSize = true;
            this.radioC.Location = new System.Drawing.Point(23, 51);
            this.radioC.Name = "radioC";
            this.radioC.Size = new System.Drawing.Size(37, 20);
            this.radioC.TabIndex = 2;
            this.radioC.TabStop = true;
            this.radioC.Text = "C";
            this.radioC.UseVisualStyleBackColor = true;
            // 
            // radioB
            // 
            this.radioB.AutoSize = true;
            this.radioB.Location = new System.Drawing.Point(108, 21);
            this.radioB.Name = "radioB";
            this.radioB.Size = new System.Drawing.Size(37, 20);
            this.radioB.TabIndex = 1;
            this.radioB.TabStop = true;
            this.radioB.Text = "B";
            this.radioB.UseVisualStyleBackColor = true;
            // 
            // radioA
            // 
            this.radioA.AutoSize = true;
            this.radioA.Location = new System.Drawing.Point(23, 22);
            this.radioA.Name = "radioA";
            this.radioA.Size = new System.Drawing.Size(37, 20);
            this.radioA.TabIndex = 0;
            this.radioA.TabStop = true;
            this.radioA.Text = "A";
            this.radioA.UseVisualStyleBackColor = true;
            // 
            // btnAddPassenger
            // 
            this.btnAddPassenger.Location = new System.Drawing.Point(97, 334);
            this.btnAddPassenger.Name = "btnAddPassenger";
            this.btnAddPassenger.Size = new System.Drawing.Size(160, 31);
            this.btnAddPassenger.TabIndex = 5;
            this.btnAddPassenger.Text = "Add passenger";
            this.btnAddPassenger.UseVisualStyleBackColor = true;
            this.btnAddPassenger.Click += new System.EventHandler(this.btnAddPassenger_Click);
            // 
            // btnShowPassengers
            // 
            this.btnShowPassengers.Location = new System.Drawing.Point(97, 388);
            this.btnShowPassengers.Name = "btnShowPassengers";
            this.btnShowPassengers.Size = new System.Drawing.Size(160, 31);
            this.btnShowPassengers.TabIndex = 6;
            this.btnShowPassengers.Text = "Show passengers";
            this.btnShowPassengers.UseVisualStyleBackColor = true;
            this.btnShowPassengers.Click += new System.EventHandler(this.btnShowPassengers_Click);
            // 
            // btnSearchPassenger
            // 
            this.btnSearchPassenger.Location = new System.Drawing.Point(97, 442);
            this.btnSearchPassenger.Name = "btnSearchPassenger";
            this.btnSearchPassenger.Size = new System.Drawing.Size(160, 31);
            this.btnSearchPassenger.TabIndex = 7;
            this.btnSearchPassenger.Text = "Search passenger";
            this.btnSearchPassenger.UseVisualStyleBackColor = true;
            this.btnSearchPassenger.Click += new System.EventHandler(this.btnSearchPassenger_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(97, 496);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(160, 31);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lstOutput
            // 
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.ItemHeight = 16;
            this.lstOutput.Location = new System.Drawing.Point(311, 59);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.Size = new System.Drawing.Size(222, 468);
            this.lstOutput.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "(1A, 1B, 1C, 1D, ...10D)";
            // 
            // FormReservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(581, 624);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstOutput);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSearchPassenger);
            this.Controls.Add(this.btnShowPassengers);
            this.Controls.Add(this.btnAddPassenger);
            this.Controls.Add(this.grpBoxRadioButtons);
            this.Controls.Add(this.cmbSeatRow);
            this.Controls.Add(this.txtNamePassenger);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormReservations";
            this.Text = "Airline Reservations";
            this.Load += new System.EventHandler(this.FormReservations_Load);
            this.grpBoxRadioButtons.ResumeLayout(false);
            this.grpBoxRadioButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNamePassenger;
        private System.Windows.Forms.ComboBox cmbSeatRow;
        private System.Windows.Forms.GroupBox grpBoxRadioButtons;
        private System.Windows.Forms.Button btnAddPassenger;
        private System.Windows.Forms.Button btnShowPassengers;
        private System.Windows.Forms.Button btnSearchPassenger;
        private System.Windows.Forms.Button btnExit;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioD;
        private System.Windows.Forms.RadioButton radioC;
        private System.Windows.Forms.RadioButton radioB;
        private System.Windows.Forms.RadioButton radioA;
    }
}

