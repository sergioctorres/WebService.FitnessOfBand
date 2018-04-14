using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web.Services;

namespace WebService.FitnessOfBand
{
    [WebService(Namespace = "http://car-sales-co.umbler.net/FitnessOfBand.asmx")]
    public class FitnessOfBand : System.Web.Services.WebService
    {
        private StringBuilder query = new StringBuilder();

        #region User Wearable
        [WebMethod]
        public void InsertWearable(string identification)
        {
            query.Length = 0;
            query.AppendLine("insert into Wearable");
            query.AppendLine("       (Identification)");
            query.AppendLine("values");
            query.AppendLine("       (@Identification)");

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["WebService.FitnessOfBand"].ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query.ToString(), connection);
                command.Parameters.AddWithValue("@Identification", identification);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        [WebMethod]
        public void GetWearable(string Identification)
        {
            query.Length = 0;
            query.AppendLine("SELECT * FROM Wearable");
            query.AppendLine("      WHERE Identification = @Identification");

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["WebService.FitnessOfBand"].ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query.ToString(), connection);
                command.Parameters.AddWithValue("@Identification", Identification);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        #endregion

        #region Information
        [WebMethod]
        public void InsertInformation(int Wearable_Id, DateTime InitialDateTime, DateTime FinishedDateTime, int InitialHeartRate, int FinalHeartRate, long InitialDistance, long FinalDistance, long InitialSteps, long FinalSteps, long InitialCalories, long FinalCalories)
        {
            query.Length = 0;
            query.AppendLine("insert into Information");
            query.AppendLine("     (Wearable_Id, InitialDateTime, FinishedDateTime, InitialHeartRate, FinalHeartRate, InitialDistance, FinalDistance, InitialSteps, FinalSteps, InitialCalories, FinalCalories)");
            query.AppendLine("values");
            query.AppendLine("     (@Wearable_Id, @InitialDateTime, @FinishedDateTime, @InitialHeartRate, @FinalHeartRate, @InitialDistance, @FinalDistance, @InitialSteps, @FinalSteps, @InitialCalories, @FinalCalories)");

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["WebService.FitnessOfBand"].ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query.ToString(), connection);
                command.Parameters.AddWithValue("@Wearable_Id", Wearable_Id);
                command.Parameters.Add("@InitialDateTime", MySqlDbType.DateTime).Value = InitialDateTime;
                command.Parameters.Add("@FinishedDateTime", MySqlDbType.DateTime).Value = FinishedDateTime;
                command.Parameters.AddWithValue("@InitialHeartRate", InitialHeartRate);
                command.Parameters.AddWithValue("@FinalHeartRate", FinalHeartRate);
                command.Parameters.AddWithValue("@InitialDistance", InitialDistance);
                command.Parameters.AddWithValue("@FinalDistance", FinalDistance);
                command.Parameters.AddWithValue("@InitialSteps", InitialSteps);
                command.Parameters.AddWithValue("@FinalSteps", FinalSteps);
                command.Parameters.AddWithValue("@InitialCalories", InitialCalories);
                command.Parameters.AddWithValue("@FinalCalories", FinalCalories);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        [WebMethod]
        public string GetInformation(int Id)
        {

            query.Length = 0;
            query.AppendLine("SELECT * FROM Information");
            query.AppendLine("         WHERE Wearable_id = @Id");

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["WebService.FitnessOfBand"].ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query.ToString(), connection);
                command.Parameters.AddWithValue("@Id", Id);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

                return "teste";
            }
        }

        [WebMethod]
        public List<POCO.Information> GetLastInformations()
        {
            query.Length = 0;
            query.AppendLine("SELECT Id, Wearable_Id, InitialDateTime, FinishedDateTime, InitialHeartRate, FinalHeartRate, ");
            query.AppendLine("       InitialDistance, FinalDistance, InitialSteps, FinalSteps, InitialCalories, ");
            query.AppendLine("       FinalCalories FROM Information ORDER BY Id DESC LIMIT 5");

            List<POCO.Information> informations = new List<POCO.Information>();

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["WebService.FitnessOfBand"].ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query.ToString(), connection);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        POCO.Information information = new POCO.Information();
                        information.Id = reader.GetInt32("Id");
                        information.Wearable_Id = reader.GetInt32("Wearable_Id");
                        information.InitialDateTime = reader.GetDateTime("InitialDateTime");
                        information.FinishedDateTime = reader.GetDateTime("FinishedDateTime");
                        information.InitialHeartRate = reader.GetInt32("InitialHeartRate");
                        information.FinalHeartRate = reader.GetInt32("FinalHeartRate");
                        information.InitialDistance = reader.GetInt64("InitialDistance");
                        information.FinalDistance = reader.GetInt64("FinalDistance");
                        information.InitialSteps = reader.GetInt64("InitialSteps");
                        information.FinalSteps = reader.GetInt64("FinalSteps");
                        information.InitialCalories = reader.GetInt64("InitialCalories");
                        information.FinalCalories = reader.GetInt64("FinalCalories");
                        informations.Add(information);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

                return informations;
            }
        }

        #endregion

        #region RealTime
        [WebMethod]
        public void InsertRealTime(int Wearable_Id, DateTime CapturedDateTime, int HeartRate, double Speed, double Pace, long TotalDistance, long TotalSteps, long Calories)
        {
            query.Length = 0;
            query.AppendLine("insert into RealTime");
            query.AppendLine("     (Wearable_Id, CapturedDateTime, HeartRate, Speed, Pace, TotalDistance, TotalSteps, Calories)");
            query.AppendLine("values");
            query.AppendLine("     (@Wearable_Id, @CapturedDateTime, @HeartRate, @Speed, @Pace, @TotalDistance, @TotalSteps, @Calories)");

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["WebService.FitnessOfBand"].ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query.ToString(), connection);
                command.Parameters.AddWithValue("@Wearable_Id", Wearable_Id);
                command.Parameters.Add("@CapturedDateTime", MySqlDbType.DateTime).Value = CapturedDateTime;
                command.Parameters.AddWithValue("@HeartRate", HeartRate);
                command.Parameters.AddWithValue("@Speed", Speed);
                command.Parameters.AddWithValue("@Pace", Pace);
                command.Parameters.AddWithValue("@TotalDistance", TotalDistance);
                command.Parameters.AddWithValue("@TotalSteps", TotalSteps);
                command.Parameters.AddWithValue("@Calories", Calories);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        #endregion
    }
}