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
            University university = new University();
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
                        Console.WriteLine("GroupNo yazsaniz qrupdaki telebelerin,bos buraxsaniz butun telebelerin ortalamasi gorsenecek");
                        string groupNo= Console.ReadLine();
                        if (!String.IsNullOrWhiteSpace(groupNo))
                        {
                            if (!Student.CheckGroupNo(groupNo))
                            {
                                throw new GroupNoNotCorrectException("Qrup nomresi duzgun deyil");
                            }
                            else
                            {
                                int totalPoint=0;
                                int count=0;
                                foreach (var item in university.Students)
                                {
                                    if (item.GroupNo==groupNo)
                                    {
                                        totalPoint += item.Point;
                                        count++;
                                    }
                                }
                                if (count>0)
                                {
                                    Console.WriteLine($"{groupNo} qrupundaki telebelerin ortalamasi : {totalPoint/count}");
                                }
                                else
                                {
                                    
                                }
                            }
                        }

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
            Console.WriteLine("       -2.2 - Universitydeki iscilerin siyahisini gostermrek");
            Console.WriteLine("       -2.3 - Isci elave etmek");
            Console.WriteLine("       -2.4 - Isci uzerinde deyisiklik etmek");
            Console.WriteLine("       -2.5 - Universityden isci silinmesi");
            Console.WriteLine("       -2.6 - Axtaris et");
            Console.WriteLine("       -3 - Cixis et");
        }
        static void CheckShowStudents(string groupNo,University university)
        {
            if (String.IsNullOrWhiteSpace(groupNo))
            {
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
                string newGroupNo;
                do
                {
                    Console.WriteLine("Yeni qrup nomresini daxil edin");
                    newGroupNo = Console.ReadLine();
                } while (!Student.CheckGroupNo(newGroupNo));
                university.UpdateStudent(no, newGroupNo);
            }
            catch (StudentNoNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
