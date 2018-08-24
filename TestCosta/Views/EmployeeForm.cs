using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestCosta.Views
{
    public partial class EmployeeForm : Form, IEmployeeView
    {
        private const string DateWarning = "Нельзя задать дату больше или равной текущей";
        private const string NoDepartmentWarning = "Нельзя создать сотрудника без отдела";
        private const string Warning = "Внимание";

        public event EventHandler SaveEmployee;
        public event EventHandler CloseForm;

        public string FirstName
        {
            get => firstName.Text;
            set => firstName.Text = value;
        }

        public string Surname
        {
            get => surname.Text;
            set => surname.Text = value;
        }

        public string Patronymic
        {
            get => patronymic.Text;
            set => patronymic.Text = value;
        }

        public DateTime Birthday
        {
            get => dateTimePicker.Value;
            set => dateTimePicker.Value = value;
        }

        public string Position
        {
            get => position.Text;
            set => position.Text = value;
        }

        public string DocSeries
        {
            get => docSeries.Text;
            set => docSeries.Text = value;
        }

        public string DocNumber
        {
            get => docNumber.Text;
            set => docNumber.Text = value;
        }

        public Guid? SelectedDepartment => ((DepartmentItem)departments.SelectedItem)?.Id; 

        public EmployeeForm()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            ShowDialog();
        }

        public void SetTitle(string title)
        {
            Text = title;
        }

        public void FillDepartments(Dictionary<Guid, string> values, Guid selectedId)
        {
            departments.Items.Clear();
            foreach (var department in values)
            {
                var item = new DepartmentItem(department.Value, department.Key);                
                departments.Items.Add(item);
                if (department.Key == selectedId)
                    departments.SelectedItem = item;
            }
        }

        public void SetAutoCompleteSource(string[] source)
        {
            var autoCompleteSource = new AutoCompleteStringCollection();
            autoCompleteSource.AddRange(source);
            position.AutoCompleteCustomSource = autoCompleteSource;
            position.AutoCompleteSource = AutoCompleteSource.CustomSource;
            position.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            CloseForm(null, null);
            base.OnFormClosed(e);
        }

        private bool ValidateItems()
        {

            if (surname.Text == String.Empty)
            {
                surname.Focus();
                return false;
            }
            else if (firstName.Text == String.Empty)
            {
                firstName.Focus();
                return false;
            }
            else if (position.Text == String.Empty)
            {
                position.Focus();
                return false;
            }
            else if (departments.SelectedIndex < 0)
            {
                MessageBox.Show(NoDepartmentWarning, Warning);
                return false;
            }
            else if (dateTimePicker.Value >= DateTime.Now.Date)
            {
                MessageBox.Show(DateWarning, Warning);
                return false;
            }

            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateItems())
            {
                SaveEmployee(sender, e);
                Close();                
            }               
        }

        private void buttonCancel_Click(object sender, EventArgs e) => Close();

        private void surname_TextChanged(object sender, EventArgs e)
        {
            surnameWarning.Visible = surname.Text == String.Empty;
        }

        private void firstName_TextChanged(object sender, EventArgs e)
        {
            nameWarning.Visible = firstName.Text == String.Empty;
        }

        private void position_TextChanged(object sender, EventArgs e)
        {
            positionWarning.Visible = position.Text == String.Empty;
        }

        private void docSeries_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void docNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
