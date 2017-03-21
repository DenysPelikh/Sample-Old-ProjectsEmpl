using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using PrEmpWin.Models;
using PrEmpWin.ViewModel;

namespace PrEmpWin.Views
{
    public partial class EmployeeForm : Form
    {
        private readonly EmployeeModel _employeeModel;
        private List<EmployeeView> _employeesView;

        private CreateEmployee _createEmployee;

        public EmployeeForm()
        {
            InitializeComponent();

            _employeeModel = new EmployeeModel();
            _employeesView = new List<EmployeeView>();

            employeesGrid.AutoGenerateColumns = false;
            employeesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            employeesGrid.ClearSelection();

            FilterCheckDef();
        }

        private void UpdateEmployeeGrid()
        {
            try
            {
                employeesGrid.DataSource = null;
                _employeesView.Sort(SortPayment);
                employeesGrid.DataSource = _employeesView.Count > 0 ? _employeesView : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckFromDatabase_CheckedChanged(object sender, EventArgs e)
        {
            _employeesView.RemoveAll(x => x.From == SourceType.Database);

            if (CheckFromDatabase.Checked)
            {
                try
                {
                    var employees = _employeeModel.GetEmployeesFromBd()
                        .Select(Mapper.Map<EmployeeView>)
                        .Select(x => { x.From = SourceType.Database; return x; }).ToList();

                    _employeesView = _employeesView.Concat(employees).ToList();
                }
                catch (Exception ex)
                {
                    CheckFromDatabase.Checked = false;
                    MessageBox.Show(ex.Message);
                }
            }

            FilterCheckDef();
            UpdateEmployeeGrid();
        }

        private void CheckFromFile_CheckedChanged(object sender, EventArgs e)
        {
            _employeesView.RemoveAll(x => x.From == SourceType.File);

            if (CheckFromFile.Checked)
            {
                try
                {
                    var employees = _employeeModel.GetEmployeesFromFile()
                   .Select(Mapper.Map<EmployeeView>)
                   .Select(x => { x.From = SourceType.File; return x; }).ToList();

                    _employeesView = _employeesView.Concat(employees).ToList();
                }
                catch (FileNotFoundException ex)
                {
                    CheckFromFile.Checked = false;
                    MessageBox.Show(ex.Message + "\nCreate new employee and write to the file");
                }
                catch (Exception ex)
                {
                    CheckFromFile.Checked = false;
                    MessageBox.Show(ex.Message);
                }
            }

            FilterCheckDef();
            UpdateEmployeeGrid();
        }

        private void UpdateCheck(object sender, EventArgs e)
        {
            CheckFromDatabase_CheckedChanged(sender, e);
            CheckFromFile_CheckedChanged(sender, e);
        }

        private void FilterCheckDef()
        {
            checkLastThree.Checked = false;
            checkFirstFive.Checked = false;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            _createEmployee = new CreateEmployee(_employeeModel);
            _createEmployee.ShowDialog();
            UpdateCheck(sender, e);
        }

        private int SortPayment(EmployeeView x, EmployeeView y)
        {
            int src = y.MonthlyAverageSalary.CompareTo(x.MonthlyAverageSalary);
            if (src == 0)
                src = string.Compare(x.EmployeeName, y.EmployeeName, StringComparison.Ordinal);

            return src;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (employeesGrid.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Delete the selected item?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        int id = (int)employeesGrid.SelectedRows[0].Cells["Id"].Value;
                        var sourceTypeFrom = (SourceType)employeesGrid.SelectedRows[0].Cells["From"].Value;
                        _employeeModel.DeleteEmployee(id, sourceTypeFrom);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    UpdateCheck(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Item not selected");
            }
        }

        private void checkFirstFive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFirstFive.Checked)
            {
                _employeesView = _employeesView.Take(5).ToList();
                UpdateEmployeeGrid();
            }
            else
            {
                UpdateCheck(sender, e);
            }
        }

        private void checkLastThree_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLastThree.Checked)
            {
                _employeesView = _employeesView.Skip(_employeesView.Count - 3).ToList();
                UpdateEmployeeGrid();
            }
            else
            {
                UpdateCheck(sender, e);
            }
        }
    }
}
