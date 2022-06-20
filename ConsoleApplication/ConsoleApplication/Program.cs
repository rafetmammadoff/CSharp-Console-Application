using ConsoleAppClassLibrary;
using ConsoleAppClassLibrary.Enums;
using ConsoleAppClassLibrary.Exceptions;
using System;

namespace ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Proqrama xos geldiniz.");
            int salaryLimit;
            string salaryLimitStr;
            do
            {
                Console.WriteLine("Universitet ucun max verilecek SalaryLimit daxil edin (minimum 250 ).");
                salaryLimitStr = Console.ReadLine();
            } while (!int.TryParse(salaryLimitStr,out salaryLimit)||salaryLimit<250);
            University university = new University(salaryLimit);
            string option;
            do
            {
                Selections();
                option = Console.ReadLine();
                switch (option)
                {
                    case "1.1":
                        ShowStudent(university);
                        break;
                    case "1.2":
                        AddStudent(university);
                        break;
                    case "1.3":
                        UpdateStudent(university);
                        break;
                    case "1.4":
                        ShowPointAverage(university);
                        break;
                    case "2.1":
                        ShowEmployees(university);
                        break;
                    case "2.2":
                        AddEmploye(university);
                        break;
                    case "2.3":
                        UpdateEmployee(university);
                        break;
                    case "2.4":
                        DeleteEmployee(university);
                        break;
                    case "2.5":
                        Search(university);
                        break;
                    default:
                        Console.WriteLine("Yanlis deyer daxil etdiniz;");
                        break;
                }
            } while (option != "3");
        }
        static void Selections()
        {
            Console.WriteLine("       -1.1 - Studentlerin siyahisini gostermek");
            Console.WriteLine("       -1.2 - Student  yaratmaq");
            Console.WriteLine("       -1.3 - Studentde deyisiklik etmek");
            Console.WriteLine("       -1.4 - Studentlerin ortalama qiymetini gostermek");
            Console.WriteLine("       -2.1 - Iscilerin siyahisini gostermek");
            Console.WriteLine("       -2.2 - Isci elave etmek");
            Console.WriteLine("       -2.3 - Isci uzerinde deyisiklik etmek");
            Console.WriteLine("       -2.4 - Universityden isci silinmesi");
            Console.WriteLine("       -2.5 - Axtaris et");
            Console.WriteLine("       -3 - Cixis et");
        }
        static void CheckShowStudents(string groupNo,University university)
        {
            if (String.IsNullOrWhiteSpace(groupNo))
            {
                if (university.Students.Length==0)
                {
                    throw new EmptyException("Hal haazirda telebe yodur. Elave edin");
                }
                foreach (var item in university.Students)
                {
                    item.ShowStudentInfo();
                }
            }
            else
            {
                if (!Student.CheckGroupNo(groupNo))
                {
                    throw new GroupNoNotCorrectException("Duzgun qrup nomresi daxil edin");
                }
                if (!Student.FindGroupNo(groupNo, university.Students))
                {
                    throw new GroupNoNotFoundException("Qrup nomresi tapilmadi");
                }

                foreach (var item in university.Students)
                {
                    if (item.GroupNo == groupNo)
                    {
                        item.ShowStudentInfo();
                    }
                }
            }
        }
        static void ShowStudent(University university)
        {
            Console.WriteLine("GroupNo yazsaniz qrupdaki telebeleri,bos buraxsaniz butun telebeler gorsenecek");
            try
            {
                string groupNo = Console.ReadLine();
                CheckShowStudents(groupNo, university);
            }
            catch (EmptyException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (GroupNoNotCorrectException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (GroupNoNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Bilinmedik bir xeta bas verdi");
            }

        }
        static void AddStudent(University university)
        {
            string name;
            do
            {
                Console.WriteLine("Student adini daxil edin");
                name = Console.ReadLine();
            } while (!Student.CheckNameSurname(name));
            string surname;
            do
            {
                Console.WriteLine("Student soyadini daxil edin");
                surname = Console.ReadLine();
            } while (!Student.CheckNameSurname(surname));
            string groupNo;
            do
            {
                Console.WriteLine("Student qrup nomresini daxil edin");
                groupNo = Console.ReadLine();
            } while (!Student.CheckGroupNo(groupNo));
            int point;
            string pointstr;
            do
            {
                Console.WriteLine("Student qiymetini daxil edin");
                pointstr = Console.ReadLine();
            } while (!int.TryParse(pointstr, out point) || point < 0 || point > 100);
            Student student = new Student
            {
                Name = name,
                Surname = surname,
                Point = point,
                GroupNo = groupNo
            };
            university.AddStudent(student);
        }
        static void UpdateStudent(University university)
        {
            try
            {
                Console.WriteLine("Qrup nomresin deyismek istediyiniz telebenin nomresini daxil edin");
                string no = Console.ReadLine();
                if (university.GetStudentIndex(no)==-1)
                {
                    throw new StudentNotFoundException("Qrup nomresi tapilmadi");
                }
                string newGroupNo;
                do
                {
                    Console.WriteLine("Yeni qrup nomresini daxil edin");
                    newGroupNo = Console.ReadLine();

                } while (!Student.CheckGroupNo(newGroupNo));
                university.UpdateStudent(no, newGroupNo);
            }
            catch(StudentNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (StudentNoNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        static void CheckPointAverage(University university)
        {
            Console.WriteLine("GroupNo yazsaniz qrupdaki telebelerin,bos buraxsaniz butun telebelerin ortalamasi gorsenecek");
            string groupNo = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(groupNo))
            {
                if (!Student.CheckGroupNo(groupNo))
                {
                    throw new GroupNoNotCorrectException("Qrup nomresi duzgun deyil");
                }
                else
                {
                    int ortalama=0;
                    try
                    {
                         ortalama = university.CalcStudentAverage(groupNo);
                    }
                    catch (StudentNotFoundException exp)
                    {
                        Console.WriteLine(exp.Message);
                        return;
                    }
                    Console.WriteLine($"{groupNo} qrupundaki telebelerin ortalamasi : {ortalama}");
                }
            }
            else
            {
                int ortalama = university.CalcStudentAverage();
                Console.WriteLine($"Butun telebelerin ortalamasi : {ortalama}");
            }
        }
        static void ShowPointAverage(University university)
        {
            try
            {
                CheckPointAverage(university);
            }
            catch (StudentNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch(GroupNoNotCorrectException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Bilinmedik bir xeta bas verdi.");
            }
        }
        static void CheckShowEmployes(University university)
        {
            string departament;
            do
            {
                Console.WriteLine("Departament adi yazsaniz departamentdeki iscileri,bos buraxsaniz butun isciler goruntulenecek.");
                departament = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(departament))
                {
                    break;
                }
            } while (!Employee.CheckNameSurnameDepartamentName(departament));

            if (!String.IsNullOrWhiteSpace(departament))
            {
                if (!University.HasDepartment(university.Employees, departament))
                {
                    throw new DepartamentNotFoundException($"{departament} adli departament yoxdur");
                }
            }
            if (!String.IsNullOrWhiteSpace(departament))
            {
                University.ShowEmployees(university.Employees, departament);
            }else
            {
                if (university.Employees.Length==0)
                {
                    throw new EmployeeNotFoundException("Isci yoxdur.Yeni isci elave edin");
                }
                University.ShowEmployees(university.Employees);
            }
        }
        static void ShowEmployees(University university)
        {
            try
            {
                CheckShowEmployes(university);
            }
            catch (DepartamentNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch(EmployeeNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        static void AddEmploye(University university)
        {
            string name;
            do
            {
                Console.WriteLine("Isci adini daxil edin");
                name = Console.ReadLine();
            } while (!Employee.CheckNameSurnameDepartamentName(name));
            string surname;
            do
            {
                Console.WriteLine("Isci soyadini daxil edin");
                surname = Console.ReadLine();
            } while (!Employee.CheckNameSurnameDepartamentName(surname));
            string position;
            do
            {
                Console.WriteLine("Isci vezifesini daxil edin");
                position = Console.ReadLine();
            } while (!Employee.CheckPosition(position));
            string departament;
            do
            {
                Console.WriteLine("Iscinin department adini daxil edin");
                departament = Console.ReadLine();
            } while (!Employee.CheckNameSurnameDepartamentName(departament));
            int salary;
            string salaryStr;
            do
            {
                Console.WriteLine("Isci maasini daxil edin");
                salaryStr = Console.ReadLine();
            } while (!int.TryParse(salaryStr, out salary) || salary < 250 || university.SalaryLimit < salary);
            string empTypeStr;
            byte empType;
            do
            {
                Console.WriteLine("Isci Tipini daxiledin");

                foreach (var item in Enum.GetValues(typeof(EmployeeType)))
                {
                    Console.WriteLine($"{(byte)item} - {item}");
                }
                empTypeStr = Console.ReadLine();
            } while (!byte.TryParse(empTypeStr,out empType) || !Enum.IsDefined(typeof(EmployeeType),empType));
            EmployeeType employeeType = (EmployeeType)Convert.ToInt32(empType);
            Employee employee = new Employee(departament)
            {
                Name = name,
                Surname = surname,
                Position = position,
                Salary = salary,
                EmployeeType = employeeType
            };
            university.AddEmployee(employee);
        }
        static void UpdateEmployee(University university)
        {
            string no;
            bool check = false;
            do
            {
                Console.WriteLine("Deyismek istediyiniz iscinin nomresini daxil edin.");
                no = Console.ReadLine();
                try
                {
                    check = university.HasEmployeeNo(no);
                }
                catch (EmployeeNotFoundException exp)
                {
                    Console.WriteLine(exp.Message);
                }
                catch (EmptyException exp)
                {
                    Console.WriteLine(exp.Message);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Bilinmedik bir xeta bas verdi");
                }
            } while (!check);

            if (check)
            {
                string newPosition;
                do
                {
                    Console.WriteLine("Iscinin yeni vesifesini daxil edin");
                    newPosition = Console.ReadLine();
                } while (!Employee.CheckPosition(newPosition));
                int newSalary;
                string newSalaryStr;
                do
                {
                    Console.WriteLine("Iscinin yeni maasini daxil edin");
                    newSalaryStr = Console.ReadLine();
                } while (!int.TryParse(newSalaryStr, out newSalary) || newSalary < 250);
                try
                {
                    university.UpdateEmployee(no, newPosition, newSalary);
                }
                catch (SalaryLimitException exp)
                {
                    Console.WriteLine(exp.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Bilinmedik xeta bas verdi");
                }
            }
        }
        static void DeleteEmployee(University university)
        {
            string no;
            bool check = false;
            do
            {
                Console.WriteLine("Silmek istediyiniz iscinin nomresini daxil edin");
                no = Console.ReadLine();
                try
                {
                    check = university.HasEmployeeNo(no);
                }
                catch (EmptyException exp)
                {
                    Console.WriteLine(exp.Message);
                    break;
                }
                catch (EmployeeNotFoundException exp)
                {
                    Console.WriteLine(exp.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Bilinmeyen xeta bas verdi");
                }
            } while (!check);
            university.DeleteEmployee(no);
        }
        static void Search(University university)
        {
            string opt;
            do
            {
                Console.WriteLine(" 1 - Isciler uzre axtaris");
                Console.WriteLine(" 2 - Telebeler uzre axtaris");
                opt = Console.ReadLine();
            } while (opt != "1" && opt != "2");
            switch (opt)
            {
                case "1":
                    Console.WriteLine("Axtaris deyerini daxil edin:");
                    string search = Console.ReadLine();
                    try
                    {
                        university.SearchEmployee(search);
                    }
                    catch (EmployeeNotFoundException exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Bilinmedik xeta bas verdi");
                    }
                    break;
                case "2":
                    Console.WriteLine("Axtaris deyerini daxil edin:");
                    search = Console.ReadLine();
                    try
                    {
                        university.SearchStudent(search);
                    }
                    catch (StudentNotFoundException exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Bilinmedik xeta bas verdi");
                    }
                    break;
            }
        }
    }
}
