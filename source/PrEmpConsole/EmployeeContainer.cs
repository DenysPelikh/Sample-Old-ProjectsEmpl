using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using PrEmp.Domain.Employees;

namespace PrEmpConsole
{
    public class EmployeeContainer
    {
        private List<EmployeeBase> _masEmployee;

        public EmployeeContainer()
        {
            _masEmployee = new List<EmployeeBase>();
        }

        public void DeserialazeEmployeeContainer(string fullFileName)
        {
            var xmlserialazer = new XmlSerializer(typeof(List<EmployeeBase>));

            try
            {
                using (var r = new StreamReader(fullFileName))
                {
                    _masEmployee = (List<EmployeeBase>)xmlserialazer.Deserialize(r);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't read input file - Exit from Application");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void SerialazeEmployeeContainer(string fullFileName)
        {
            var xmlserialazer = new XmlSerializer(typeof(List<EmployeeBase>));

            using (TextWriter myStreamWriter = new StreamWriter(fullFileName))
            {
                xmlserialazer.Serialize(myStreamWriter, _masEmployee);
            }
        }

        public void GenerateEmployeeContainer(int count)
        {
            var rand = new Random();

            for (var i = 0; i < count; i++)
            {
                EmployeeBase empl;
                if (rand.Next(2) == 0)
                {
                    empl = new EmployeeHourlyPayment(i, GetEmplName(rand), rand.Next(10, 50));
                }
                else
                {
                    empl = new EmployeeFixedPayment(i, GetEmplName(rand), rand.Next(1000, 8500));
                }

                _masEmployee.Add(empl);
            }
        }

        public void SortEmployeeContainer(Sort s)
        {
            var sortConditions = new Dictionary<Sort, Comparison<EmployeeBase>>
            {
                { Sort.AscPayment, SortPayment },
                { Sort.DescPayment, (x, y) => SortPayment(x, y) * -1 },
                { Sort.Id, (x, y) => x.Id.CompareTo(y.Id) },
                { Sort.Name, (x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal) }
            };

            _masEmployee.Sort(sortConditions[s]);
        }

        public void ClearEmployeeContainer()
        {
            _masEmployee.Clear();
            Console.WriteLine("The container cleared \n");
        }

        public void RemoveEmployeeContainer(int id)
        {
            _masEmployee.Remove(_masEmployee.Find(x => x.Id == id));
        }

        public void AddEmployeeContainer()
        {
            EmployeeBase empl;
            var id = _masEmployee.Count == 0 ? 0 : _masEmployee.Max(x => x.Id);

            Console.Write("Input name the employee: ");
            var name = Console.ReadLine();

            Console.WriteLine("Choose the method of payment to the employee");
            Console.WriteLine("1 - Hourly payment");
            Console.WriteLine("2 - Fixed payment");
            Console.WriteLine("3 - Exit");

            int actionNumber;
            int.TryParse(Console.ReadLine(), out actionNumber);

            Console.Write("Input employee payment: ");

            switch (actionNumber)
            {
                case 1:
                    {
                        double hourlyPayment = Convert.ToInt32(Console.ReadLine());
                        empl = new EmployeeHourlyPayment(id + 1, name, hourlyPayment);
                        _masEmployee.Add(empl);
                        break;
                    }
                case 2:
                    {
                        double fixedPayment = Convert.ToInt32(Console.ReadLine());
                        empl = new EmployeeFixedPayment(id + 1, name, fixedPayment);
                        _masEmployee.Add(empl);
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Input incorrectly");
                        break;
                    }
            }
        }

        public void TakeFirstNEmployeeNames(int count)
        {
            var empl = _masEmployee.Take(count);

            foreach (var currEmp in empl)
            {
                Console.WriteLine(currEmp.Name);
            }
        }

        public void TakeLastNEmployeeIDs(int count)
        {
            var empl = _masEmployee.Skip(_masEmployee.Count - count);

            foreach (var currEmp in empl)
            {
                Console.WriteLine(currEmp.Id);
            }
        }

        public void ShowEmployeeContainer()
        {
            Console.WriteLine("{0} {1,10} {2,20} {3,30}", "Id", "Name", "Type Payment", "Monthly Average Salary");

            foreach (var empl in _masEmployee)
            {
                Console.WriteLine("{0,-5} {1,-14} {2,-30} {3,0}", empl.Id, empl.Name, empl, empl.GetAverageMonthlySalary());
            }

            Console.WriteLine("");
        }

        private string GetEmplName(Random random)
        {
            var gameName = new StringBuilder();
            gameName.Append(random.Next(100));

            for (var i = 0; i < 2; i++)
            {
                gameName.Append(" ");
                gameName.Append(random.Next(100));
            }

            return gameName.ToString();
        }

        private int SortPayment(EmployeeBase x, EmployeeBase y)
        {
            int def = y.GetAverageMonthlySalary().CompareTo(x.GetAverageMonthlySalary());
            if (def == 0)
                def = string.Compare(x.Name, y.Name, StringComparison.Ordinal);

            return def;
        }
    }
}
