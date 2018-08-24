using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestCosta.Views
{
    public partial class DepartmentForm : Form, IDepartmentView
    {
        public event EventHandler SaveDepartment;
        public event EventHandler CloseForm;

        public string DepartmentName
        {
            get => name.Text;
            set => name.Text = value;
        }

        public string Code
        {
            get => code.Text;
            set => code.Text = value;
        }

        public bool HasParentDepartment
        {
            get => checkBox.Checked;
            set
            {
                checkBox.Checked = value;
                ChangeCheckBoxEnable();
            }
        }

        public Guid? ParentDepartment => (departments.SelectedItem as DepartmentItem)?.Id;

        public DepartmentForm()
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

        public void FillDepartments(Dictionary<Guid, string> values, Guid? selectedId)
        {
            departments.Items.Clear();
            foreach (var department in values)
            {
                var item = new DepartmentItem(department.Value, department.Key);
                departments.Items.Add(item);
                if (department.Key == selectedId)
                    departments.SelectedItem = item;
            }

            if (!selectedId.HasValue)
                departments.SelectedIndex = -1;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            CloseForm(null, null);
            base.OnFormClosed(e);
        }

        private void ChangeCheckBoxEnable()
        {
            departments.Enabled = checkBox.Checked;
            if (!checkBox.Checked)
                departments.SelectedIndex = -1;
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            nameWarning.Visible = name.Text == string.Empty;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (name.Text != string.Empty)
            {
                SaveDepartment(null, null);
                Close();
            }
            else
                name.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => ChangeCheckBoxEnable();

        private void cancelButton_Click(object sender, EventArgs e) => Close();
    }
}
