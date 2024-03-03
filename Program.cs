using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;

namespace ADONET_intro
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region single table  call
            /*TrainerDB tb = new TrainerDB();
            List<Trainer> ajay = tb.AllTrainers();
            foreach (var tt in ajay)
            {
                Console.WriteLine($"ID : {tt.Id} Name : {tt.Name} City : {tt.City} Expeirnce {tt.Experience}");
            }*/
            #endregion single table  call


            #region two table call && Two table call useing SQLDataAdapter class
            /*
                        TrainerDB db = new TrainerDB();

                        List<Student> students;
                        List<Trainer> trainers;

                        db.AllTrainers(out students, out trainers);
                        Console.WriteLine("*** ALL Trainer ***");
                        foreach (var t in trainers)
                        {
                            Console.WriteLine($"Id : {t.Id} Name : {t.Name} City : {t.City} Experience : {t.Experience}");
                        }

                        Console.WriteLine("*** ALL  Students***");
                        foreach (var s in students)
                        {
                            Console.WriteLine($"Id : {s.RollNumber} Name : {s.Name}  Trainer Id : {s.TrainerId}");
                        }

            */

            #endregion two table call 


            #region GetTrainerById
            /*TrainerDB db = new TrainerDB();
            Console.WriteLine("Please Enter a Id by Search");
            int trainerId = int.Parse(Console.ReadLine());

            Trainer result = db.GetTrainerById(trainerId);
            if (result != null)
            {
                Console.WriteLine($"TrainerId : {result.Id}   TrainerName: {result.Name}  Trainer Expe : {result.Experience} ");
            }
            else {
                Console.WriteLine($"Trainer Not Found By Id {trainerId}");
            }*/
            #endregion GetTrainerById


            #region SQL Injection Attack 


            //delete all record SQL injection attack
            /* Console.WriteLine("Enter a Roll Number By Search Student"); //1; delete student : enter kiya or 1 rn ka data return kiya console ne uske bad table delete kar diya is samsya hal sql injection hai
             string rollNumber = Console.ReadLine();


             string Connection = "Server=.\\SQLEXPRESS;database=B22ADONETDB;integrated security = true;";

             SqlConnection con = new SqlConnection(Connection);

             string query = $"Select RollNumber,Name,TrainerId from Student where RollNumber = {rollNumber}";
             SqlCommand cmd = new SqlCommand(query, con);

             con.Open();
             SqlDataReader readar = cmd.ExecuteReader();
             if (readar.HasRows)
             {
                 while (readar.Read())
                 {
                     Student s = new Student()
                     {
                         RollNumber = (int)readar["RollNumber"],
                         Name = readar["Name"].ToString(),
                         TrainerId = (int)readar["TrainerId"]
                     };
                     Console.WriteLine($"Id : {s.RollNumber} Name : {s.Name}  Trainer Id : {s.TrainerId}");
                     break;
                 }
             }
             else
             {
                 Console.WriteLine($"Student not found for roll number {rollNumber}");
             }
             con.Close();*/





            //1. ab delete nahi honge Student parameterized query use kiya hai

            /*Console.WriteLine("Enter a Roll Number By Search Student"); //5; delete student : else me aa gaya  (Student not found for roll number 6;delete student)
            string rollNumber = Console.ReadLine();


            string Connection = "Server=.\\SQLEXPRESS;database=B22ADONETDB;integrated security = true;";

            SqlConnection con = new SqlConnection(Connection);

            string query = $"Select RollNumber,Name,TrainerId from Student where RollNumber = @RollNumber";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@RollNumber", rollNumber); //AddWithValue method varible ko daclare bhi karta hai or batata bhi hai

            con.Open();
            SqlDataReader readar = cmd.ExecuteReader();
            if (readar.HasRows)
            {
                while (readar.Read())
                {
                    Student s = new Student()
                    {
                        RollNumber = (int)readar["RollNumber"],
                        Name = readar["Name"].ToString(),
                        TrainerId = (int)readar["TrainerId"]
                    };
                    Console.WriteLine($"Id : {s.RollNumber} Name : {s.Name}  Trainer Id : {s.TrainerId}");
                    break;
                }
            }
            else
            {
                Console.WriteLine($"Student not found for roll number {rollNumber}");
            }
            con.Close();*/






            //2. using Store Procedure

            /*          Console.WriteLine("Enter a Roll Number By Search Student"); //5; delete student : else me aa gaya  (Student not found for roll number 6;delete student)
                      string rollNumber = Console.ReadLine();


                      string Connection = "Server=.\\SQLEXPRESS;database=B22ADONETDB;integrated security = true;";

                      SqlConnection con = new SqlConnection(Connection);

                      string query = "uspGetStudentByRollNumber"; //ek esa sp banaya hai jo select karta hai student ko rollnumber se

                      SqlCommand cmd = new SqlCommand(query, con);
                      cmd.CommandType = CommandType.StoredProcedure; 
                      cmd.Parameters.AddWithValue("@RollNumber", rollNumber); //AddWithValue method varible ko daclare bhi karta hai or batata bhi hai

                      con.Open();
                      SqlDataReader readar = cmd.ExecuteReader();
                      if (readar.HasRows)
                      {
                          while (readar.Read())
                          {
                              Student s = new Student()
                              {
                                  RollNumber = (int)readar["RollNumber"],
                                  Name = readar["Name"].ToString(),
                                  TrainerId = (int)readar["TrainerId"]
                              };
                              Console.WriteLine($"Id : {s.RollNumber} Name : {s.Name}  Trainer Id : {s.TrainerId}");
                              break;
                          }
                      }
                      else
                      {
                          Console.WriteLine($"Student not found for roll number {rollNumber}");
                      }
                      con.Close();


          */

            #endregion SQL Injection Attack



            #region Create Trainer method calling

            /* Console.WriteLine("Create new Trainer");

             Console.WriteLine("Please Enter Trainer Name");
             string name = Console.ReadLine();

             Console.WriteLine("Please Enter Trainer City");
             string city = Console.ReadLine();

             Console.WriteLine("Please Enter Trainer Experience");
             int experience = int.Parse(Console.ReadLine());

             Trainer t = new Trainer()
             {
                 Name = name,
                 City = city,
                 Experience = experience
             };
             TrainerDB db = new TrainerDB();
             int id = 0;
             bool status = db.CreateTrainer(t, out id);
             if (status)
             {
                 Console.WriteLine($" Trainer Create Success {id} ");
             }
             else
             {
                 Console.WriteLine(" Trainer Create Failed ");
             }*/

            #endregion Create Trainer calling


            #region Update Trainer called....

            /*  Console.WriteLine("Please Enter Trainer Id");
              int id = int.Parse(Console.ReadLine());

              TrainerDB dB = new TrainerDB();
              Trainer trainer = dB.GetTrainerById(id);

              Console.WriteLine($"Trainer_ID : {trainer.Id}  Trainer_Name: {trainer.Name} Trainer_City: {trainer.City}" +
                  $"Trainer_Experience : {trainer.Experience}");
              string choice = " ";
              do
              {
                  Console.WriteLine("Please Enter Property Name to Update");
                  string name = Console.ReadLine();

                  Console.WriteLine($"Please Enter New Value For {name}");
                  string newValue = Console.ReadLine();

                  switch (name.ToUpper())
                  {
                      case "NAME":
                          trainer.Name = newValue;
                          break;
                      case "CITY":
                          trainer.City = newValue;
                          break;
                      case "EXPERINECE":
                          trainer.Experience = int.Parse(newValue);
                          break;
                      default:
                          Console.WriteLine("Invalid Property Name");
                          break;
                  }
                  Console.WriteLine("Do You Want to continue?");
                  choice = Console.ReadLine().ToUpper();
              } while (choice == "Y" || choice == "YES");

              bool status = dB.UpdateTrainer(trainer);
              if (status)
              {
                  Console.WriteLine($"Trainer Datail Update successfully");
              }
              else {
                  Console.WriteLine("Trainer Datail Update Faild");
              }*/

            #endregion

            #region Delete Trainer 

            /* Console.WriteLine("Please Enter Trainer Id To Delete");
             int id = int.Parse(Console.ReadLine());
             TrainerDB db = new TrainerDB();
             bool status = db.DeleteTrainer(id);
             if (status)
             {
                 Console.WriteLine($"Trainer Id {id} is Delete Successfully");
             }
             else
             {
                 Console.WriteLine($"Trainer Id : {id} Not Found");
             }
 */
            #endregion


            Console.WriteLine($"Data copy started now : {DateTime.Now}");
            TrainerDB db = new TrainerDB();
            bool status = db.BulkDataCopy();
            if (status)
            {
                Console.WriteLine($"Data Copy Complated Successfully {DateTime.Now}");
            }
            else
            {
                Console.WriteLine("Data Copy Failed !!!");
            }



            Console.ReadLine();
        }
    }
}
