using System;
using System.Windows.Forms;
using PrEmpWin.Models;
using PrEmpWin.ViewModel;

namespace PrEmpWin.Views
{
    public partial class CreateEmployee : Form
    {
        private readonly EmployeeModel _employeeModel;

        public CreateEmployee(EmployeeModel employeeModel)
        {
            InitializeComponent();

            _employeeModel = employeeModel;

            checkDatabase.Checked = false;
            checkFile.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var message = string.Empty;
            var createEmployeeView = CreateEmployeeView(ref message);

            if (message.Length != 0)
            {
                richTextBox1.Visible = true;
                richTextBox1.Text = message;
                return;
            }

            try
            {
                _employeeModel.AddEmployee(createEmployeeView);
                MessageBox.Show("Employee added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Close();

        }

        private CreateEmployeeView CreateEmployeeView(ref string message)
        {
            CreateEmployeeView employee = new CreateEmployeeView();

            if (txtName.Text.Length == 0)
            {
                message += "Field name must be filled\n";
            }
            else if (txtName.Text.Length > 50)
            {
                message += "The field name must contain no more than 50 characters\n";
            }

            employee.Name = txtName.Text;

            int payment = 0;

            if (txtPayment.Text.Length == 0)
            {
                message += "Field payment must be filled\n";
            }
            else if (!int.TryParse(txtPayment.Text, out payment))
            {
                message += "Incorrectly entered the field payment\n";
            }
            else if (payment < 0)
            {
                message += "Field Payment must be positive\n";
            }

            employee.Payment = payment;

            if (radioFixedPayment.Checked)
            {
                employee.PaymentType = PaymentType.FixedPayment;
            }
            else if (radioHourlyPayment.Checked)
            {
                employee.PaymentType = PaymentType.HourlyPayment;
            }
            else
            {
                message += "Type of payment must be selected\n";
            }

            if (!checkDatabase.Checked && !checkFile.Checked)
            {
                message += "Write source must be selected\n";
            }

            employee.WriteDatabase = checkDatabase.Checked;
            employee.WriteFile = checkFile.Checked;

            return employee;
        }
    }
}
