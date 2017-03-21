using System;

namespace PrEmpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const string dataXmlFileName = @"..\..\EmployeeContainerXmlData.xml";
            var employeeContainer = new EmployeeContainer();

            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1 - Show container of employees");
                Console.WriteLine("2 - Reading from a file");
                Console.WriteLine("3 - Generate employee container");
                Console.WriteLine("4 - Sort container");
                Console.WriteLine("5 - Add employee");
                Console.WriteLine("6 - Remove employee");
                Console.WriteLine("7 - Clear container");
                Console.WriteLine("8 - Writing to a file");
                Console.WriteLine("9 - Exit");

                int actionNumber;
                int.TryParse(Console.ReadLine(), out actionNumber);
                Console.Clear();

                switch (actionNumber)
                {
                    case 1:
                        {
                            employeeContainer.ShowEmployeeContainer();
                            break;
                        }
                    case 2:
                        {
                            employeeContainer.DeserialazeEmployeeContainer(dataXmlFileName);
                            Console.WriteLine("Read from   " + dataXmlFileName + "\n");
                            employeeContainer.ShowEmployeeContainer();
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Amount to generate: ");
                            int count = Convert.ToInt32(Console.ReadLine());
                            employeeContainer.GenerateEmployeeContainer(count);
                            employeeContainer.ShowEmployeeContainer();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Sort:");
                            Console.WriteLine("1 - Ascending payment");
                            Console.WriteLine("2 - Descending payment");
                            Console.WriteLine("3 - By name");
                            Console.WriteLine("4 - By id");

                            int sortNumber;
                            int.TryParse(Console.ReadLine(), out sortNumber);

                            switch (sortNumber)
                            {
                                case 1:
                                    {
                                        employeeContainer.SortEmployeeContainer(Sort.AscPayment);
                                        break;
                                    }
                                case 2:
                                    {
                                        employeeContainer.SortEmployeeContainer(Sort.DescPayment);
                                        break;
                                    }
                                case 3:
                                    {
                                        employeeContainer.SortEmployeeContainer(Sort.Name);
                                        break;
                                    }
                                case 4:
                                    {
                                        employeeContainer.SortEmployeeContainer(Sort.Id);
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Input incorrectly");
                                        break;
                                    }
                            }

                            Console.Clear();
                            break;
                        }
                    case 5:
                        {
                            employeeContainer.AddEmployeeContainer();
                            Console.Clear();
                            employeeContainer.ShowEmployeeContainer();
                            break;
                        }
                    case 6:
                        {
                            Console.Write("Input employee id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            employeeContainer.RemoveEmployeeContainer(id);
                            Console.Clear();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("The container will be cleaned");
                            Console.WriteLine("1 - Confirm");
                            Console.WriteLine("2 - Cancel");
                            int k = Convert.ToInt32(Console.ReadLine());
                            switch (k)
                            {
                                case 1:
                                    {
                                        employeeContainer.ClearEmployeeContainer();
                                        break;
                                    }
                                default:
                                    {
                                        Console.Clear();
                                        break;
                                    }
                            }

                            break;
                        }
                    case 8:
                        {
                            employeeContainer.SerialazeEmployeeContainer(dataXmlFileName);
                            Console.WriteLine("Write to file " + dataXmlFileName + "\n");
                            break;
                        }
                    case 9:
                        {
                            Environment.Exit(Environment.ExitCode);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Input incorrectly");
                            break;
                        }
                }
            }
        }
    }
}
