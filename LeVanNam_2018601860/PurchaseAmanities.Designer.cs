namespace GUI
{
    partial class PurchaseAmanities
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
            this.lbBookinReference = new System.Windows.Forms.Label();
            this.tbBookReference = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFlightList = new System.Windows.Forms.GroupBox();
            this.lbTest = new System.Windows.Forms.Label();
            this.btnShowAnimities = new System.Windows.Forms.Button();
            this.cbFlights = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbFullname = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPassportNumber = new System.Windows.Forms.Label();
            this.lbCabinClass = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbAmenities = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbDutiesAndTaxes = new System.Windows.Forms.Label();
            this.lbItemsSelected = new System.Windows.Forms.Label();
            this.lbTotalPayable = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lbPaid = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gbFlightList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbBookinReference
            // 
            this.lbBookinReference.AutoSize = true;
            this.lbBookinReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBookinReference.Location = new System.Drawing.Point(39, 37);
            this.lbBookinReference.Name = "lbBookinReference";
            this.lbBookinReference.Size = new System.Drawing.Size(121, 16);
            this.lbBookinReference.TabIndex = 0;
            this.lbBookinReference.Text = "Booking reference:";
            // 
            // tbBookReference
            // 
            this.tbBookReference.Location = new System.Drawing.Point(166, 37);
            this.tbBookReference.Name = "tbBookReference";
            this.tbBookReference.Size = new System.Drawing.Size(306, 20);
            this.tbBookReference.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(478, 35);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose your flight:";
            // 
            // gbFlightList
            // 
            this.gbFlightList.Controls.Add(this.lbTest);
            this.gbFlightList.Controls.Add(this.btnShowAnimities);
            this.gbFlightList.Controls.Add(this.cbFlights);
            this.gbFlightList.Controls.Add(this.label1);
            this.gbFlightList.Enabled = false;
            this.gbFlightList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFlightList.Location = new System.Drawing.Point(42, 80);
            this.gbFlightList.Name = "gbFlightList";
            this.gbFlightList.Size = new System.Drawing.Size(702, 100);
            this.gbFlightList.TabIndex = 5;
            this.gbFlightList.TabStop = false;
            this.gbFlightList.Text = "Flight list";
            // 
            // lbTest
            // 
            this.lbTest.AutoSize = true;
            this.lbTest.Location = new System.Drawing.Point(149, 72);
            this.lbTest.Name = "lbTest";
            this.lbTest.Size = new System.Drawing.Size(125, 16);
            this.lbTest.TabIndex = 7;
            this.lbTest.Text = "Test Result Here";
            this.lbTest.Visible = false;
            // 
            // btnShowAnimities
            // 
            this.btnShowAnimities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAnimities.Location = new System.Drawing.Point(517, 45);
            this.btnShowAnimities.Name = "btnShowAnimities";
            this.btnShowAnimities.Size = new System.Drawing.Size(135, 23);
            this.btnShowAnimities.TabIndex = 6;
            this.btnShowAnimities.Text = "Show animities";
            this.btnShowAnimities.UseVisualStyleBackColor = true;
            this.btnShowAnimities.Click += new System.EventHandler(this.btnShowAnimities_Click);
            // 
            // cbFlights
            // 
            this.cbFlights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFlights.FormattingEnabled = true;
            this.cbFlights.Location = new System.Drawing.Point(152, 45);
            this.cbFlights.Name = "cbFlights";
            this.cbFlights.Size = new System.Drawing.Size(359, 24);
            this.cbFlights.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Full name:";
            // 
            // lbFullname
            // 
            this.lbFullname.AutoSize = true;
            this.lbFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFullname.Location = new System.Drawing.Point(114, 210);
            this.lbFullname.Name = "lbFullname";
            this.lbFullname.Size = new System.Drawing.Size(94, 16);
            this.lbFullname.TabIndex = 7;
            this.lbFullname.Text = "[XXXX XXXX]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(309, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Passport number:";
            // 
            // lbPassportNumber
            // 
            this.lbPassportNumber.AutoSize = true;
            this.lbPassportNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassportNumber.Location = new System.Drawing.Point(428, 210);
            this.lbPassportNumber.Name = "lbPassportNumber";
            this.lbPassportNumber.Size = new System.Drawing.Size(94, 16);
            this.lbPassportNumber.TabIndex = 9;
            this.lbPassportNumber.Text = "[XXXX XXXX]";
            // 
            // lbCabinClass
            // 
            this.lbCabinClass.AutoSize = true;
            this.lbCabinClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCabinClass.Location = new System.Drawing.Point(168, 242);
            this.lbCabinClass.Name = "lbCabinClass";
            this.lbCabinClass.Size = new System.Drawing.Size(94, 16);
            this.lbCabinClass.TabIndex = 11;
            this.lbCabinClass.Text = "[XXXX XXXX]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Your cabin class is:";
            // 
            // gbAmenities
            // 
            this.gbAmenities.Enabled = false;
            this.gbAmenities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAmenities.Location = new System.Drawing.Point(42, 298);
            this.gbAmenities.Name = "gbAmenities";
            this.gbAmenities.Size = new System.Drawing.Size(702, 153);
            this.gbAmenities.TabIndex = 12;
            this.gbAmenities.TabStop = false;
            this.gbAmenities.Text = "AMONIC Airlines Amenities";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 514);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Items Selected:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 542);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Duties and taxes:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(39, 570);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Total payable:";
            // 
            // lbDutiesAndTaxes
            // 
            this.lbDutiesAndTaxes.AutoSize = true;
            this.lbDutiesAndTaxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDutiesAndTaxes.Location = new System.Drawing.Point(155, 542);
            this.lbDutiesAndTaxes.Name = "lbDutiesAndTaxes";
            this.lbDutiesAndTaxes.Size = new System.Drawing.Size(44, 16);
            this.lbDutiesAndTaxes.TabIndex = 16;
            this.lbDutiesAndTaxes.Text = "[$XX]";
            // 
            // lbItemsSelected
            // 
            this.lbItemsSelected.AutoSize = true;
            this.lbItemsSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemsSelected.Location = new System.Drawing.Point(155, 514);
            this.lbItemsSelected.Name = "lbItemsSelected";
            this.lbItemsSelected.Size = new System.Drawing.Size(44, 16);
            this.lbItemsSelected.TabIndex = 17;
            this.lbItemsSelected.Text = "[$XX]";
            // 
            // lbTotalPayable
            // 
            this.lbTotalPayable.AutoSize = true;
            this.lbTotalPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPayable.Location = new System.Drawing.Point(155, 570);
            this.lbTotalPayable.Name = "lbTotalPayable";
            this.lbTotalPayable.Size = new System.Drawing.Size(44, 16);
            this.lbTotalPayable.TabIndex = 18;
            this.lbTotalPayable.Text = "[$XX]";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(520, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(224, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save and Confirm";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(520, 563);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(224, 23);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "12345E";
            this.label8.Visible = false;
            // 
            // lbPaid
            // 
            this.lbPaid.AutoSize = true;
            this.lbPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaid.Location = new System.Drawing.Point(155, 489);
            this.lbPaid.Name = "lbPaid";
            this.lbPaid.Size = new System.Drawing.Size(44, 16);
            this.lbPaid.TabIndex = 23;
            this.lbPaid.Text = "[$XX]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(39, 489);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Paid:";
            // 
            // PurchaseAmanities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 624);
            this.Controls.Add(this.lbPaid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTotalPayable);
            this.Controls.Add(this.lbItemsSelected);
            this.Controls.Add(this.lbDutiesAndTaxes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbAmenities);
            this.Controls.Add(this.lbCabinClass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbPassportNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbFullname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbFlightList);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbBookReference);
            this.Controls.Add(this.lbBookinReference);
            this.Name = "PurchaseAmanities";
            this.Text = "Purchase Aminities";
            this.gbFlightList.ResumeLayout(false);
            this.gbFlightList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbBookinReference;
        private System.Windows.Forms.TextBox tbBookReference;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbFlightList;
        private System.Windows.Forms.Button btnShowAnimities;
        private System.Windows.Forms.ComboBox cbFlights;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbFullname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPassportNumber;
        private System.Windows.Forms.Label lbCabinClass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbAmenities;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbDutiesAndTaxes;
        private System.Windows.Forms.Label lbItemsSelected;
        private System.Windows.Forms.Label lbTotalPayable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTest;
        private System.Windows.Forms.Label lbPaid;
        private System.Windows.Forms.Label label10;
    }
}

