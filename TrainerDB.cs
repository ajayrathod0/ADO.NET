using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace ADONET_intro
{
    public class TrainerDB
    {
        string connectionStr = null; //class feild jo ki private hai null rakha hai


        public TrainerDB()  // Constructor
        {//ConfigurationManager refer kiya hai reference me jakar or namespace me add kiya 
            connectionStr = ConfigurationManager.ConnectionStrings["B22"].ConnectionString; // Class feild ko Constructor me initialize karenge
                                                                                               // app.config me add hai
        }


        //1. Select All Trainer Record From DataBase


        #region single table selected

        /*public List<Trainer> AllTrainers()
        {

            List<Trainer> trainers = new List<Trainer>();

            string ConnectionString = "Server=.\\SQLEXPRESS;database=B22ADONETDB;integrated security = true;";

            SqlConnection con = new SqlConnection(ConnectionString); //step 1.Connecting SQL Server Database
            con.Open(); // open connection as late as possible

            string cmdText = "select id , name , city , experience from trainer";

            SqlCommand sqlCommand = new SqlCommand(cmdText, con);   //step 2. Prepare command

            SqlDataReader reader = sqlCommand.ExecuteReader();     // step 3. Execute command

            if (reader.HasRows) //reader me rows hongi to true 
            {                  //agar true to if ke under
                while (reader.Read())//ek ek query/record add kar
                {
                    Trainer t = new Trainer();

                    t.Id = (int)reader["ID"];
                    t.Name = reader["Name"].ToString();
                    t.City = reader["City"].ToString();
                    t.Experience = reader["Experience"].ToString();

                    trainers.Add(t);
                }

            }
            con.Close();

            return trainers;
        }*/

        #endregion single table selected


        #region two table selected


        /*   public void AllTrainers(out List<Trainer> trainers, out List<Student> students)
           {
               trainers = new List<Trainer>();
               students = new List<Student>();




               string ConnectionString = "Server=.\\SQLEXPRESS;database=B22ADONETDB;integrated security = true;";

               SqlConnection con = new SqlConnection(ConnectionString);

               string cmdText = "select Id ,Name,City,Experience from Trainer;select RollNumber , Name , TrainerId from Student;";
               SqlCommand cmd = new SqlCommand(cmdText, con);

               con.Open();
               SqlDataReader reader = cmd.ExecuteReader();

               while (reader.Read())
               {
                   Trainer t = new Trainer();

                   t.Id = (int)reader["ID"];
                   t.Name = reader["Name"].ToString();
                   t.City = reader["City"].ToString();
                   t.Experience =(int) reader["Experience"];

                   trainers.Add(t);

               }

               reader.NextResult(); // jump to student data 

               while (reader.Read())
               {
                   Student s = new Student();
                   s.RollNumber = (int)reader["RollNumber"];
                   s.Name = reader["Name"].ToString();
                   s.TrainerId = (int)reader["TrainerId"];
                   students.Add(s);
               }
               con.Close();
           }
   */

        #endregion two table selected


        #region SqlDataAdapter Example two table select

        /* public void AllTrainers(out List<Student> students, out List<Trainer> trainers)
         {
             students = new List<Student>();
             trainers = new List<Trainer>();

             string ConnectionString = "Server=.\\SQLEXPRESS;database=B22ADONETDB;integrated security = true;";
             SqlConnection con = new SqlConnection(ConnectionString);

             string cmdText = "select RollNumber , Name , TrainerId from Student;select Id ,Name,City,Experience from Trainer;";
             SqlCommand cmd = new SqlCommand(cmdText, con);

             SqlDataAdapter adapter = new SqlDataAdapter(cmd);

             DataSet ds = new DataSet();
             adapter.Fill(ds);

             if (ds != null && ds.Tables.Count > 0)
             {
                 if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                 {
                     for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                     {
                         var ans = ds.Tables[0].Rows[i];
                         Student s = new Student()
                         {
                             RollNumber = (int)ans["RollNumber"],
                             Name = ans["Name"].ToString(),
                             TrainerId = (int)ans["TrainerId"]
                         };
                         students.Add(s);
                     }
                 }
                 if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                 {
                     for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                     {
                         var row = ds.Tables[1].Rows[i];

                         Trainer t = new Trainer()
                         {
                             Id = (int)row["ID"],
                             Name = row["Name"].ToString(),
                             City = row["City"].ToString(),
                             Experience = (int)row["Experience"]
                         };
                         trainers.Add(t);
                     }
                 }

             }

         }
 */
        #endregion


        //2. Select A trainer By ID 

        #region 2. Select A trainer By ID 

        public Trainer GetTrainerById(int Id)
        {
            Trainer trainer = new Trainer();

            string ConnectionString = "Server=.\\SQLEXPRESS;database=B22ADONETDB;integrated security = true;";

            SqlConnection con = new SqlConnection(ConnectionString);

            string cmdText = $"select Id,Name,City,Experience from Trainer where Id = {Id};";
            SqlCommand cmd = new SqlCommand(cmdText, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                trainer.Id = (int)reader["Id"];
                trainer.Name = reader["Name"].ToString();
                trainer.City = reader["City"].ToString();
                trainer.Experience = (int)reader["Experience"];

                break;
            }
            con.Close();

            return trainer;
        }

        #endregion


        #region 3. Create Trainer
        public bool CreateTrainer(Trainer trainer, out int newRollNumber)
        {
            string ConnextionString =
             "server=.\\sqlexpress;database=B22ADONETDB;integrated security=true;";

            SqlConnection con = new SqlConnection(connectionStr);  //class feild se

            SqlCommand cmd = new SqlCommand(SqlSP.spCreateTrainer, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", trainer.Name);
            cmd.Parameters.AddWithValue("@City", trainer.City);
            cmd.Parameters.AddWithValue("@Experience", trainer.Experience);

            SqlParameter Id = new SqlParameter()
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(Id);

            SqlParameter status = new SqlParameter()
            {
                ParameterName = "@Status",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output,
            };

            cmd.Parameters.Add(status);

            con.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            newRollNumber = (int)Id.Value;

            con.Close();

            return (bool)status.Value;
        }



        #endregion 3. Create Trainer



        #region 4. Update Trainer

        public bool UpdateTrainer(Trainer trainer)
        {
            SqlConnection con = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand(SqlSP.spUpdateTrainer, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", trainer.Id);
            cmd.Parameters.AddWithValue("@Name", trainer.Name);
            cmd.Parameters.AddWithValue("@City", trainer.City);
            cmd.Parameters.AddWithValue("@Experience", trainer.Experience);

            SqlParameter status = new SqlParameter()
            {
                ParameterName = "@Status",
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Bit,
            };
            cmd.Parameters.Add(status);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return (bool)status.Value;
        }

        #endregion


        #region 5. Delete Trainer

        public bool DeleteTrainer(int Id)
        {
            SqlConnection con = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand(SqlSP.spDeleteTrainer, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlParameter status = new SqlParameter()
            {
                ParameterName = "@Status",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output,
            };
            cmd.Parameters.Add(status);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return (bool)status.Value;
        }

        #endregion 

        public bool BulkDataCopy()
        {
            try
            {
             //   string Connection = "Server=.\\SQLEXPRESS;database=B22ADONETDB;integrated security = true;";
                SqlConnection con = new SqlConnection(connectionStr);// 1DB ke connectionString constuctor me initialize kiya hai feild ko
                SqlDataAdapter adapter = new SqlDataAdapter("Select * From Trainer", con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);//ds me hold hai table trainer ka 

                //jitne Database utne connection string
                string destinatioCoString =
                    ConfigurationManager.ConnectionStrings["AchiveDB"].ConnectionString;

                SqlConnection destinationCon = new SqlConnection(destinatioCoString);
                SqlBulkCopy copy = new SqlBulkCopy(destinationCon);

                copy.DestinationTableName = "dbo.Trainer"; //konse table me copy karna data
                destinationCon.Open();//
                copy.WriteToServer(ds.Tables[0]);// copy all records from ds object to destinaiton table
                destinationCon.Close();

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
