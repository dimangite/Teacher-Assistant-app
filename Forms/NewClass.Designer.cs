namespace StudentManagementSystem.Forms
{
    partial class NewClass
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
            this.btnNewClass = new System.Windows.Forms.Button();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCreateClass = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbSD = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNSession = new System.Windows.Forms.Label();
            this.lbAcademic = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbYear = new System.Windows.Forms.Label();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.lbSemester = new System.Windows.Forms.Label();
            this.comboBoxSemseter = new System.Windows.Forms.ComboBox();
            this.tbSession = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewClass
            // 
            this.btnNewClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewClass.Font = new System.Drawing.Font("Chaparral Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewClass.Location = new System.Drawing.Point(276, 322);
            this.btnNewClass.Name = "btnNewClass";
            this.btnNewClass.Size = new System.Drawing.Size(164, 40);
            this.btnNewClass.TabIndex = 76;
            this.btnNewClass.Text = "DONE";
            this.btnNewClass.UseVisualStyleBackColor = true;
            this.btnNewClass.Click += new System.EventHandler(this.btnNewClass_Click);
            // 
            // txtClassName
            // 
            this.txtClassName.BackColor = System.Drawing.Color.White;
            this.txtClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassName.Font = new System.Drawing.Font("Chaparral Pro", 15.75F);
            this.txtClassName.Location = new System.Drawing.Point(318, 77);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(236, 33);
            this.txtClassName.TabIndex = 68;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.lbCreateClass);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 44);
            this.panel1.TabIndex = 55;
            // 
            // lbCreateClass
            // 
            this.lbCreateClass.AutoSize = true;
            this.lbCreateClass.Font = new System.Drawing.Font("Chaparral Pro", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreateClass.Location = new System.Drawing.Point(233, 9);
            this.lbCreateClass.Name = "lbCreateClass";
            this.lbCreateClass.Size = new System.Drawing.Size(236, 29);
            this.lbCreateClass.TabIndex = 9;
            this.lbCreateClass.Text = "CREATE NEW CLASS";
            this.lbCreateClass.TextChanged += new System.EventHandler(this.lbCreateClass_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Chaparral Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(471, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(164, 40);
            this.btnCancel.TabIndex = 77;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbSD
            // 
            this.lbSD.AutoSize = true;
            this.lbSD.Font = new System.Drawing.Font("Chaparral Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSD.Location = new System.Drawing.Point(82, 132);
            this.lbSD.Name = "lbSD";
            this.lbSD.Size = new System.Drawing.Size(103, 25);
            this.lbSD.TabIndex = 53;
            this.lbSD.Text = "Start Date";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Chaparral Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(81, 78);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(130, 25);
            this.lbName.TabIndex = 51;
            this.lbName.Text = "Subject Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Chaparral Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(268, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 25);
            this.label9.TabIndex = 62;
            this.label9.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Chaparral Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(267, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 25);
            this.label7.TabIndex = 60;
            this.label7.Text = ":";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Font = new System.Drawing.Font("Chaparral Pro", 15.75F);
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(318, 129);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(236, 33);
            this.dateTimePickerStartDate.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Chaparral Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(267, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 25);
            this.label2.TabIndex = 79;
            this.label2.Text = ":";
            // 
            // lbNSession
            // 
            this.lbNSession.AutoSize = true;
            this.lbNSession.Font = new System.Drawing.Font("Chaparral Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNSession.Location = new System.Drawing.Point(81, 229);
            this.lbNSession.Name = "lbNSession";
            this.lbNSession.Size = new System.Drawing.Size(150, 25);
            this.lbNSession.TabIndex = 78;
            this.lbNSession.Text = "Number session";
            // 
            // lbAcademic
            // 
            this.lbAcademic.AutoSize = true;
            this.lbAcademic.Font = new System.Drawing.Font("Chaparral Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAcademic.Location = new System.Drawing.Point(81, 177);
            this.lbAcademic.Name = "lbAcademic";
            this.lbAcademic.Size = new System.Drawing.Size(94, 25);
            this.lbAcademic.TabIndex = 81;
            this.lbAcademic.Text = "Academic";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Chaparral Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(268, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 25);
            this.label10.TabIndex = 82;
            this.label10.Text = ":";
            // 
            // lbYear
            // 
            this.lbYear.AutoSize = true;
            this.lbYear.Font = new System.Drawing.Font("Chaparral Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYear.Location = new System.Drawing.Point(313, 178);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(50, 25);
            this.lbYear.TabIndex = 83;
            this.lbYear.Text = "Year";
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear.Font = new System.Drawing.Font("Chaparral Pro", 15.75F);
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxYear.Location = new System.Drawing.Point(369, 175);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(38, 33);
            this.comboBoxYear.TabIndex = 70;
            // 
            // lbSemester
            // 
            this.lbSemester.AutoSize = true;
            this.lbSemester.Font = new System.Drawing.Font("Chaparral Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSemester.Location = new System.Drawing.Point(430, 178);
            this.lbSemester.Name = "lbSemester";
            this.lbSemester.Size = new System.Drawing.Size(90, 25);
            this.lbSemester.TabIndex = 85;
            this.lbSemester.Text = "Semester";
            // 
            // comboBoxSemseter
            // 
            this.comboBoxSemseter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSemseter.Font = new System.Drawing.Font("Chaparral Pro", 15.75F);
            this.comboBoxSemseter.FormattingEnabled = true;
            this.comboBoxSemseter.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBoxSemseter.Location = new System.Drawing.Point(526, 175);
            this.comboBoxSemseter.Name = "comboBoxSemseter";
            this.comboBoxSemseter.Size = new System.Drawing.Size(37, 33);
            this.comboBoxSemseter.TabIndex = 71;
            // 
            // tbSession
            // 
            this.tbSession.Font = new System.Drawing.Font("Chaparral Pro", 15.75F);
            this.tbSession.Location = new System.Drawing.Point(318, 227);
            this.tbSession.Mask = "00";
            this.tbSession.Name = "tbSession";
            this.tbSession.Size = new System.Drawing.Size(118, 33);
            this.tbSession.TabIndex = 86;
            this.tbSession.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.tbSession_MaskInputRejected);
            // 
            // NewClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 409);
            this.Controls.Add(this.tbSession);
            this.Controls.Add(this.comboBoxSemseter);
            this.Controls.Add(this.lbSemester);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.lbYear);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbAcademic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNSession);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.btnNewClass);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbSD);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewClass";
            this.Load += new System.EventHandler(this.NewClass_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewClass;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbCreateClass;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbSD;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNSession;
        private System.Windows.Forms.Label lbAcademic;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Label lbSemester;
        private System.Windows.Forms.ComboBox comboBoxSemseter;
        private System.Windows.Forms.MaskedTextBox tbSession;
    }
}