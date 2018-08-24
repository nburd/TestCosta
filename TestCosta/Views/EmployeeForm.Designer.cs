namespace TestCosta.Views
{
    partial class EmployeeForm
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
            this.patronymic = new System.Windows.Forms.TextBox();
            this.surname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.surnameWarning = new System.Windows.Forms.Label();
            this.nameWarning = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.departments = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.docNumber = new System.Windows.Forms.TextBox();
            this.docSeries = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.positionWarning = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // patronymic
            // 
            this.patronymic.Location = new System.Drawing.Point(96, 113);
            this.patronymic.MaxLength = 50;
            this.patronymic.Name = "patronymic";
            this.patronymic.Size = new System.Drawing.Size(224, 20);
            this.patronymic.TabIndex = 2;
            // 
            // surname
            // 
            this.surname.Location = new System.Drawing.Point(96, 19);
            this.surname.MaxLength = 50;
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(224, 20);
            this.surname.TabIndex = 0;
            this.surname.TextChanged += new System.EventHandler(this.surname_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Имя";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(96, 66);
            this.firstName.MaxLength = 50;
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(224, 20);
            this.firstName.TabIndex = 1;
            this.firstName.TextChanged += new System.EventHandler(this.firstName_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(273, 403);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 100;
            this.buttonSave.TabStop = false;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(382, 403);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 200;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // surnameWarning
            // 
            this.surnameWarning.AutoSize = true;
            this.surnameWarning.ForeColor = System.Drawing.Color.Red;
            this.surnameWarning.Location = new System.Drawing.Point(96, 42);
            this.surnameWarning.Name = "surnameWarning";
            this.surnameWarning.Size = new System.Drawing.Size(224, 13);
            this.surnameWarning.TabIndex = 13;
            this.surnameWarning.Text = "Поле \"Фамилия\" должно быть заполнено ";
            // 
            // nameWarning
            // 
            this.nameWarning.AutoSize = true;
            this.nameWarning.ForeColor = System.Drawing.Color.Red;
            this.nameWarning.Location = new System.Drawing.Point(96, 89);
            this.nameWarning.Name = "nameWarning";
            this.nameWarning.Size = new System.Drawing.Size(197, 13);
            this.nameWarning.TabIndex = 14;
            this.nameWarning.Text = "Поле \"Имя\" должно быть заполнено ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Отдел";
            // 
            // departments
            // 
            this.departments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departments.Location = new System.Drawing.Point(84, 27);
            this.departments.Name = "departments";
            this.departments.Size = new System.Drawing.Size(221, 21);
            this.departments.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Должность";
            // 
            // position
            // 
            this.position.Location = new System.Drawing.Point(84, 72);
            this.position.MaxLength = 50;
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(224, 20);
            this.position.TabIndex = 7;
            this.position.TextChanged += new System.EventHandler(this.position_TextChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.AllowDrop = true;
            this.dateTimePicker.CustomFormat = "dd MMM yyyy";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(96, 151);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(115, 20);
            this.dateTimePicker.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Дата рождения";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Серия";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.docNumber);
            this.groupBox1.Controls.Add(this.docSeries);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(7, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 90);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Документ";
            // 
            // docNumber
            // 
            this.docNumber.Location = new System.Drawing.Point(87, 44);
            this.docNumber.MaxLength = 6;
            this.docNumber.Name = "docNumber";
            this.docNumber.Size = new System.Drawing.Size(100, 20);
            this.docNumber.TabIndex = 5;
            this.docNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.docNumber_KeyPress);
            // 
            // docSeries
            // 
            this.docSeries.Location = new System.Drawing.Point(9, 44);
            this.docSeries.MaxLength = 4;
            this.docSeries.Name = "docSeries";
            this.docSeries.Size = new System.Drawing.Size(72, 20);
            this.docSeries.TabIndex = 4;
            this.docSeries.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.docSeries_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Номер";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.positionWarning);
            this.groupBox2.Controls.Add(this.position);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.departments);
            this.groupBox2.Location = new System.Drawing.Point(382, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 119);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // positionWarning
            // 
            this.positionWarning.AutoSize = true;
            this.positionWarning.ForeColor = System.Drawing.Color.Red;
            this.positionWarning.Location = new System.Drawing.Point(82, 95);
            this.positionWarning.Name = "positionWarning";
            this.positionWarning.Size = new System.Drawing.Size(233, 13);
            this.positionWarning.TabIndex = 17;
            this.positionWarning.Text = "Поле \"Должность\" должно быть заполнено ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateTimePicker);
            this.groupBox3.Controls.Add(this.firstName);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.nameWarning);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.surnameWarning);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.surname);
            this.groupBox3.Controls.Add(this.patronymic);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 323);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Личные данные";
            // 
            // EmployeeForm
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(740, 448);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Name = "EmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox patronymic;
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label surnameWarning;
        private System.Windows.Forms.Label nameWarning;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox departments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox position;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox docSeries;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox docNumber;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label positionWarning;
    }
}