using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TestCosta.Model;

namespace TestCosta.Views
{
    public partial class MainForm : Form, IMainView
    {
        private const string DepartmentsQuestionText = "Вы действительно хотите удалить отдел? " +
            "Также удалятся все зависимые отделы и сотрудники";
        private const string DepartmentsQuestionTitle = "Удаление отдела";
        private const string EmployeeQuestionText = "Вы действительно хотите удалить сотрудника?";
        private const string EmployeeQuestionTitle = "Удаление сотрудника";

        public event EventHandler<DepartmentChangedEventArgs> DepartmentSelectingChanged;
        public event EventHandler<Guid> ClickedInsertingEmployee;
        public event EventHandler<Guid> ClickedInsertingDepartment;
        public event EventHandler<int> ClickedEditingEmployee;
        public event EventHandler<Guid> ClickedEditingDepartment;        
        public event EventHandler<int> ClickedDeletingEmployee;
        public event EventHandler<Guid> ClickedDeletingDepartment;

        public MainForm()
        {
            InitializeComponent();
        }
        
        public void ShowForm() => Application.Run(this);

        public void SetTitle(string title)
        {
            Text = title;
        }

        public void ShowDepartments(IEnumerable<Department> departments)
        {
            Guid? selectedNode = null;
            if (departmentTreeView.SelectedNode != null)
                selectedNode = GetGuidFromTag(departmentTreeView.SelectedNode.Tag);

            departmentTreeView.Nodes.Clear();
            var parents = departments.Where(x => !x.ParentDepartmentID.HasValue);
            foreach (var department in parents)
            {
                var parent = new TreeNode(department.Name)
                {
                    Tag = department.ID
                };
                departmentTreeView.Nodes.Add(parent);
                parent.Expand();
                AddNodeToTreeView(department, parent, departments);
            }

            if (!selectedNode.HasValue)
                departmentTreeView.SelectedNode = departmentTreeView.Nodes[0];
            else
                ExpandDepartment(selectedNode.Value);
            UpdateEmployees();
        }

        public void ShowEmployees(IEnumerable<Empoyee> employees)
        {
            employeeGrid.Rows.Clear();
            foreach (var employee in employees)
            {
                var row = employeeGrid.Rows.Add();
                employeeGrid.Rows[row].Cells["Fio"].Value = employee.ToString();
                employeeGrid.Rows[row].Cells["Position"].Value = employee.Position;
                employeeGrid.Rows[row].Cells["Age"].Value = GetAge(employee.DateOfBirth);
                employeeGrid.Rows[row].Tag = employee.ID.ToString();
            }

            dummy.Visible = !employees.Any();
            employeeGrid.Visible = employees.Any();
            editEmployeeButton.Visible = employees.Any();
            deleteEmployeeButton.Visible = employees.Any();
        }

        public void UpdateEmployees() => LoadGuidsForUpdatingEmployees(departmentTreeView.SelectedNode);

        public void ExpandDepartment(Guid? id)
        {
            if (!id.HasValue)
            {
                if (departmentTreeView.Nodes.Count != 0)
                    departmentTreeView.SelectedNode = departmentTreeView.Nodes[0];

                return;
            }

            var node = GetNode(id.ToString(), null);
            if (node != null)
            {
                if (node.Parent != null)
                    node.Parent.Expand();

                departmentTreeView.SelectedNode = node;
                departmentTreeView.Focus();
            }
        }

        public void SelectEmployee(int id)
        {
            int index = GetRowIndexByTag(id);
            if (index != -1)
                employeeGrid.Rows[index].Selected = true;
        }

        public void SelectEmployeeByIndex(int index)
        {
            if (index < 0)
                index = 0;
            employeeGrid.Rows[index].Selected = true;
            employeeGrid.Select();
        }

        public int GetCurrentSelectedEmployeeIndex()
        {
            if (employeeGrid.SelectedRows.Count > 0)
                return employeeGrid.SelectedRows[0].Index;

            return -1;
        }

        public Guid? GetNextNode()
        {
            var node = departmentTreeView.SelectedNode.NextNode;
            if (node != null)
            {
                return GetGuidFromTag(node.Tag);
            } 

            var parent = departmentTreeView.SelectedNode.Parent;
            if (parent != null)
            {
                return GetGuidFromTag(parent.Tag);
            }  

            return null;
        }

        private void departmentTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown)
                return;

            LoadGuidsForUpdatingEmployees(e.Node);
        }

        private void departmentTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ClickedEditingDepartment(null, GetGuidFromTag(e.Node.Tag));
        }

        private void departmentTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                departmentTreeView.SelectedNode = e.Node;
                contextMenu.Show(departmentTreeView, departmentTreeView.PointToClient(Cursor.Position));
            }
        }

        private void employeeGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SelectClickedCell(e);
                var relativeMousePosition = employeeGrid.PointToClient(Cursor.Position);
                contextMenu.Show(employeeGrid, relativeMousePosition);
            }
        }

        private void employeeGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectClickedCell(e);
            EditEmployee();
        }

        private void employeeGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!DeleteEmployee(e.Row.Index))
                e.Cancel = true;
        }

        private void departmentTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                DeleteDepartment();
        }

        private void AddMenuItemClick(object sender, EventArgs e)
        {
            var sourceControl = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl;
            if (sourceControl is DataGridView)
                AddEmployee();
            else
                AddDepartment();
        }

        private void EditMenuItemClick(object sender, EventArgs e)
        {
            var sourceControl = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl;
            if (sourceControl is DataGridView)
                EditEmployee();
            else
                EditDepartment();

        }

        private void DeleteMenuItemClick(object sender, EventArgs e)
        {
            var sourceControl = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl;
            if (sourceControl is DataGridView)
                DeleteEmployee(null);
            else
                DeleteDepartment();
        }

        private void addDepartmentButton_Click(object sender, EventArgs e) => AddDepartment();

        private void editDepartmentButton_Click(object sender, EventArgs e) => EditDepartment();

        private void deleteDepartmentButton_Click(object sender, EventArgs e) => DeleteDepartment(); 

        private void addEmployeeButton_Click(object sender, EventArgs e) => AddEmployee();

        private void editEmployeeButton_Click(object sender, EventArgs e) => EditEmployee();

        private void deleteEmployeeButton_Click(object sender, EventArgs e) => DeleteEmployee(null);
        
        private TreeNode GetNode(string tag, TreeNode rootNode)
        {
            TreeNode itemNode = null;
            var nodes = rootNode == null ? departmentTreeView.Nodes : rootNode.Nodes;
            foreach (TreeNode node in nodes)
            {
                if (node.Tag.ToString().Equals(tag))
                    return node;

                itemNode = GetNode(tag, node);
                if (itemNode != null)
                    break;
            }
            return itemNode;
        }

        private void AddNodeToTreeView(Department department, TreeNode parent, IEnumerable<Department> departments)
        {
            var childrens = departments.Where(x => x.ParentDepartmentID == department.ID);
            foreach (var children in childrens)
            {
                var node = new TreeNode(children.Name)
                {
                    Tag = children.ID
                };
                parent.Nodes.Add(node);
                AddNodeToTreeView(children, node, departments);
            }
        }

        private void LoadGuidsForUpdatingEmployees(TreeNode node)
        {
            var guids = new List<Guid>();
            GetChildrenNodesGuid(node, guids);
            DepartmentSelectingChanged(null, new DepartmentChangedEventArgs(guids));
        }

        private void GetChildrenNodesGuid(TreeNode parentNode, List<Guid> guids)
        {
            if (parentNode == null)
                return;

            guids.Add(GetGuidFromTag(parentNode.Tag));
            foreach (TreeNode subNode in parentNode.Nodes)
            {
                GetChildrenNodesGuid(subNode, guids);
            }
        }

        private bool ShowDeleteDepartmentQuestionDialog()
        {
            var result = MessageBox.Show(DepartmentsQuestionText, DepartmentsQuestionTitle,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                return true;

            return false;
        }

        private bool ShowDeleteEmployeeQuestionDialog()
        {
            var result = MessageBox.Show(EmployeeQuestionText, EmployeeQuestionTitle,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                return true;

            return false;
        }

        private int GetAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (birthday > now.AddYears(-age)) age--;
            return age;
        }

        private Guid GetGuidFromTag(object tag) => Guid.Parse(tag.ToString());

        private int? GetSelectedEmployeeId()
        {
            var selectedCells = employeeGrid.SelectedCells;
            if (selectedCells.Count == 0)
                return null;

            var id = selectedCells[0].OwningRow.Tag;
            if (id == null)
                return null;

            return int.Parse(id.ToString());
        }        

        private void SelectClickedCell(DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell clickedCell = employeeGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            employeeGrid.CurrentCell = clickedCell;
        }

        private void AddEmployee()
        {
            ClickedInsertingEmployee(null, GetGuidFromTag(departmentTreeView.SelectedNode.Tag));
        }

        private void AddDepartment()
        {
            ClickedInsertingDepartment(null, GetGuidFromTag(departmentTreeView.SelectedNode.Tag));
        }

        private void EditEmployee()
        {
            int? id = GetSelectedEmployeeId();
            if (!id.HasValue)
                return;

            ClickedEditingEmployee(null, id.Value);
        }

        private void EditDepartment()
        {
            ClickedEditingDepartment(null, GetGuidFromTag(departmentTreeView.SelectedNode.Tag));
        }       

        private bool DeleteEmployee(int? rowIndex)
        {
            if (ShowDeleteEmployeeQuestionDialog())
            {
                ClickedDeletingEmployee(rowIndex, GetSelectedEmployeeId().Value);
                return true;
            }

            return false;            
        }

        private void DeleteDepartment()
        {
            if (ShowDeleteDepartmentQuestionDialog())
                ClickedDeletingDepartment(null, GetGuidFromTag(departmentTreeView.SelectedNode.Tag));
        }

        private int GetRowIndexByTag(int tag)
        {
            for (int i = 0; i < employeeGrid.Rows.Count; i += 1)
            {
                if (int.Parse(employeeGrid.Rows[i].Tag.ToString()) == tag)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
