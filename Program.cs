using ConsoleApp11.Helpers;
using System;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            Course cr = new Course();
            while (true)
            {
            ChooseMenu:
                Helper.PrintLine("1-Add Group   2-Print groups   3-Add students to the groups   4-Print students   5-Search student", ConsoleColor.DarkYellow);
                //Console.WriteLine();
                Helper.PrintLine("6-Remove student from group   7-Edit student in the group", ConsoleColor.DarkYellow);
                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int menu);
                if (isInt && menu >= 1 && menu <= 7)
                {
                    Group gr = new Group();
                    switch (menu)
                    {
                        case 1:

                        #region AddGroup
                        Group:
                            Console.WriteLine("Enter group name : ");
                            string groupName = Console.ReadLine();
                            foreach (var item in cr.groups)
                            {
                                if (item.Name.ToLower() == groupName.ToLower())
                                {
                                    Helper.PrintLine($"{groupName} already exist!!", ConsoleColor.Red);
                                    goto Group;
                                }
                            }
                            gr.Name = groupName;
                            cr.groups.Add(gr);
                            Helper.PrintLine($"{gr.Name} succesfully added", ConsoleColor.Green);
                            #endregion

                            break;

                        case 2:

                            #region PrintGroups
                            Console.WriteLine("Groups in the course : ");
                            foreach (var item in cr.groups)
                            {
                                Console.WriteLine(item.Name);
                            }
                            #endregion


                            break;

                        case 3:

                            #region AddStudents

                            Console.WriteLine("Groups in the course : ");
                            foreach (var item in cr.groups)
                            {
                                Console.WriteLine(item.Name);
                            }

                            //    Student st = new Student();

                            //Stud: Console.Write("Enter student name : ");
                            //    string name = Console.ReadLine();

                            //    if (string.IsNullOrWhiteSpace(name))
                            //    {
                            //        Helper.PrintLine("Enter correctly", ConsoleColor.Red);
                            //        goto Stud;
                            //    }
                            //    st.Name = name;
                            //Stud2: Console.Write("Enter student surname : ");
                            //    string surname = Console.ReadLine();
                            //    st.Surname = surname;
                            //    if (string.IsNullOrWhiteSpace(surname))
                            //    {
                            //        Helper.PrintLine("Enter correctly", ConsoleColor.Red);
                            //        goto Stud2;
                            //    }
                            //AGE: Console.Write("Enter student age : ");
                            //    string ageStr = Console.ReadLine();
                            //    bool isAge = int.TryParse(ageStr, out int age);
                            //    if (!isAge)
                            //    {
                            //        Helper.PrintLine("Enter correctly", ConsoleColor.Red);
                            //        goto AGE;
                            //    }
                            //    st.Age = age;
                            //GRADE: Console.Write("Enter student grade : ");
                            //    string gradeStr = Console.ReadLine();
                            //    bool isGrade = int.TryParse(gradeStr, out int grade);
                            //    if (!isGrade || grade < 0 || grade > 100)
                            //    {
                            //        Helper.PrintLine("Enter correctly", ConsoleColor.Red);
                            //        goto GRADE;
                            //    }
                            //    st.Grade = grade;


                            Console.Write("Which group do you want to add a student? :  ");

                        inputgr:
                            string groupName2 = Console.ReadLine();
                            foreach (var item in cr.groups)
                            {
                                if (item.Name.ToLower() == groupName2.ToLower())
                                {
                                    Student st = new Student();

                                Stud: Console.Write("Enter student name : ");
                                    string name = Console.ReadLine();

                                    if (string.IsNullOrWhiteSpace(name))
                                    {
                                        Helper.PrintLine("Enter correctly", ConsoleColor.Red);
                                        goto Stud;
                                    }
                                    st.Name = name;
                                Stud2: Console.Write("Enter student surname : ");
                                    string surname = Console.ReadLine();
                                    st.Surname = surname;
                                    if (string.IsNullOrWhiteSpace(surname))
                                    {
                                        Helper.PrintLine("Enter correctly", ConsoleColor.Red);
                                        goto Stud2;
                                    }
                                AGE: Console.Write("Enter student age : ");
                                    string ageStr = Console.ReadLine();
                                    bool isAge = int.TryParse(ageStr, out int age);
                                    if (!isAge)
                                    {
                                        Helper.PrintLine("Enter correctly", ConsoleColor.Red);
                                        goto AGE;
                                    }
                                    st.Age = age;
                                GRADE: Console.Write("Enter student grade : ");
                                    string gradeStr = Console.ReadLine();
                                    bool isGrade = int.TryParse(gradeStr, out int grade);
                                    if (!isGrade || grade < 0 || grade > 100)
                                    {
                                        Helper.PrintLine("Enter correctly", ConsoleColor.Red);
                                        goto GRADE;
                                    }
                                    st.Grade = grade;
                                    item.students.Add(st);
                                    Helper.PrintLine($"Student succesfully added to {groupName2} group", ConsoleColor.Green);
                                    goto ChooseMenu;

                                }


                            }
                            Helper.Print($"{groupName2} doesn't exist in list. Enter groupname again :  ", ConsoleColor.Red);
                            goto inputgr;
                        #endregion



                        case 4:

                            #region PrintStudents

                            Console.Write("Enter group name which you want to print it's students : ");
                        gr:
                            groupName = Console.ReadLine();
                            foreach (var item in cr.groups)
                            {
                                if (item.students.Count == 0)
                                {
                                    Console.WriteLine("There is no student in this group");
                                    goto case 4;
                                }
                                else if (item.Name.ToLower() == groupName.ToLower())
                                {
                                    foreach (var item2 in item.students)
                                    {
                                        Console.WriteLine(item2.Name + " " + item2.Surname);

                                    }
                                    goto ChooseMenu;
                                }
                                Helper.Print($"{groupName} doesn't exist in list. Enter groupname again :  ", ConsoleColor.Red);
                                goto gr;
                            }
                            break;

                        #endregion



                        case 5:

                        #region SearchStudents
                            Console.WriteLine("Enter fullname");
                            string fname = Console.ReadLine();
                            foreach (var item in cr.groups)
                            {
                                if (item.students.Count == 0)
                                {
                                    Console.WriteLine("There is no student in this group");
                                }
                                else
                                {
                                    foreach (var item2 in item.students)
                                    {
                                        if (item2.Name.ToLower().Contains(fname))
                                        {
                                            Console.WriteLine($"{fname} is exist in {item2.Name}  {item2.Surname}");
                                        }
                                    }
                                }
                            }
                            #endregion

                            break;

                        case 6:

                            #region RemoveStudent

                            Console.WriteLine("Groups in the course : ");
                            foreach (var item in cr.groups)
                            {
                                Console.WriteLine(item.Name);
                            }
                            Console.Write("Enter group name which you want to remove from :  ");
                            groupName = Console.ReadLine();
                            foreach (var item in cr.groups)
                            {
                                if (item.Name.ToLower() == groupName.ToLower())
                                {
                                    foreach (var item2 in item.students)
                                    {
                                        Console.WriteLine(item2.ID + " " + item2.Name);
                                    }
                                }
                            }
                            Console.Write("Enter ID of students which you want to remove :  ");
                        ID:
                            string idStr = Console.ReadLine();
                            bool isId = int.TryParse(idStr, out int stId);
                            if (!isId)
                            {
                                Helper.PrintLine("Enter Id correctly!!", ConsoleColor.Red);
                                goto ID;
                            }
                            foreach (var item in cr.groups)
                            {
                                foreach (var item2 in item.students)
                                {
                                    if (stId == item2.ID)
                                    {
                                        item.students.Remove(item2);
                                        Console.WriteLine($"{item2.Name} {item2.Surname} is removed from student list.");
                                        break;
                                    }
                                }
                            }
                            #endregion

                            break;

                        case 7:

                            #region EditStudent

                            Console.WriteLine("Groups in the course : ");
                            foreach (var item in cr.groups)
                            {
                                Console.WriteLine(item.Name);
                            }
                            Console.Write("Enter group name which you want to edit students from :  ");
                            groupName = Console.ReadLine();
                            foreach (var item in cr.groups)
                            {
                                if (item.Name.ToLower() == groupName.ToLower())
                                {
                                    foreach (var item2 in item.students)
                                    {
                                        Console.WriteLine(item2.ID + " " + item2.Name);
                                    }
                                }
                            }
                            Console.Write("Enter ID of students which you want to remove :  ");
                        ID2:
                            idStr = Console.ReadLine();
                            bool isId2 = int.TryParse(idStr, out int st2Id);
                            if (!isId2)
                            {
                                Helper.PrintLine("Enter Id correctly!!", ConsoleColor.Red);
                                goto ID2;
                            }
                            foreach (var item in cr.groups)
                            {
                                foreach (var item2 in item.students)
                                {
                                    if (st2Id == item2.ID)
                                    {
                                        Console.WriteLine($"Enter new name of {item2.Name}");
                                    name: string name = Console.ReadLine();

                                        if (string.IsNullOrWhiteSpace(name))
                                        {
                                            Helper.PrintLine("Enter correctly", ConsoleColor.Red);
                                            goto name;
                                        }
                                        item2.Name = name;
                                    Stud3: Console.Write("Enter student surname : ");
                                        string surname = Console.ReadLine();
                                        item2.Surname = surname;
                                        if (string.IsNullOrWhiteSpace(surname))
                                        {
                                            Helper.PrintLine("Enter correctly", ConsoleColor.Red);
                                            goto Stud3;
                                        }
                                    AGE2: Console.Write("Enter student age : ");
                                        string ageStr = Console.ReadLine();
                                        bool isAge = int.TryParse(ageStr, out int age2);
                                        if (!isAge)
                                        {
                                            Helper.PrintLine("Enter correctly", ConsoleColor.Red);
                                            goto AGE2;
                                        }
                                        item2.Age = age2;
                                    GRADE2: Console.Write("Enter student grade : ");
                                        string gradeStr = Console.ReadLine();
                                        bool isGrade = int.TryParse(gradeStr, out int grade2);
                                        if (!isGrade)
                                        {
                                            Helper.PrintLine("Enter correctly", ConsoleColor.Red);
                                            goto GRADE2;
                                        }
                                        item2.Grade = grade2;

                                    }
                                }
                            }
                            #endregion

                            break;

                        default:
                            break;
                    }
                }
            }
        }

        // 1. Qrup elave et - nelumatlari alib kursa yeni qrup elave etsin, eyni adli iki qrup yaranmasin
        // 2. Qruplari gor - kursun butun qruplarini cap etsin
        // 3. Qrupa student elave et - (butun qruplar cap olunsun,
        //                              istifadeci student elave etmek istediyi qrupun name-ini daxil etsin
        //                              daha sonra studentin melumatlarini daxil etdikden sonra
        //                              student qrupa elave olunsun). Studentin id-si mutleq unique olmalidir
        //                              eyni id-li student elave oluna bilmez.
        //                              (Note: id ucun static prop saxlayib her defe obyekt yarananda artira bilersiniz)
        // 4. Studentleri gor - butun qruplar cap olunsun, istifadeci
        //                      adini daxil etdiyi qrupun butun studentleri ekranda cap olunsun
        // 5. Studentler uzre axtaris - istifadeciden bir string deyer alin.
        //                              butun qruplardaki butun studentler uzre axtaris edib
        //                              hansi studentlerin adinda bu deyer varsa cap edin
        // 6. Qrupdan student sil - (butun qruplar cap olunsun,
        //                              istifadeci hansi qrupdan telebe silmek isteyirse hemin
        //                              qrupun name-ini daxil etsin. ve hemin qrupdaki studentler
        //                              ekrana cap olunsun. (id-si ve name-i), daha sonra silmek istediyi
        //                              studentin id-sini daxil etsin. ve student qrupdan silinsin
        // 7. Qrupdaki studenti editle - (butun qruplar cap olunsun,
        //                              istifadeci hansi qrupda telebe editlemek isteyirse hemin
        //                              qrupun name-ini daxil etsin. ve hemin qrupdaki studentler
        //                              ekrana cap olunsun. (id-si ve name-i). daha sonra editlemek istediyi
        //                              studentin id-sini daxil etsin. Ve istifadeciden studentin yeni melumatlari
        //                              sorusulsun. istifadeci yeni melumatlari daxil etdikden sonra
        //                              studentin melumatlari editlensin
    }
}
