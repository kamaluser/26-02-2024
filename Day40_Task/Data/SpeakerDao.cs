using Day40_Task.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day40_Task.Data
{
    internal class SpeakerDao
    {
        private string connectionStr = "Server=LAPTOP-IGIN0GLR\\SQLEXPRESS;Database=Day40_Task;Trusted_Connection=true";
        public int InsertSpeaker(string fullname, string position, string company, string imageUrl)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "insert into Speakers(fullname, position, company, imageUrl) values (@fullname, @position, @company, @imageUrl)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@position", position);
                    cmd.Parameters.AddWithValue("@company", company);
                    cmd.Parameters.AddWithValue("@imageUrl", imageUrl);

                    result = cmd.ExecuteNonQuery();

                }
            }
            return result;


        }

        public int DeleteSpeaker(int id)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "delete from speakers where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public Speaker GetSpeakerById(int id)
        {
            Speaker speaker = null;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select TOP(1) * from speakers where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return null;
                        while (reader.Read())
                        {
                            speaker = new Speaker();
                            speaker.Id = reader.GetInt32(0);
                            speaker.Fullname = reader.GetString(1);
                            speaker.Position = reader.GetString(2);
                            speaker.Company = reader.GetString(3);
                            speaker.ImageURL = reader.GetString(4);
                        }
                    }
                }
            }
            return speaker;
        }


        public List<Speaker> GetAllSpeakers()
        {
            List<Speaker> speakers = new List<Speaker>();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select * from speakers";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return speakers;
                        while (reader.Read())
                        {
                            Speaker speaker = new Speaker()
                            {
                                Id = reader.GetInt32(0),
                                Fullname = reader.GetString(1),
                                Position = reader.GetString(2),
                                Company = reader.GetString(3),
                                ImageURL = reader.GetString(4)

                        };
                        speakers.Add(speaker);
                        }
                    }
                }
            }
            return speakers;
        }

        public void UpdateSpeaker(Speaker speaker)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "UPDATE Speakers SET fullname = @fullname, position = @position, company = @company, imageUrl = @imageUrl WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@fullname", speaker.Fullname);
                cmd.Parameters.AddWithValue("@position", speaker.Position);
                cmd.Parameters.AddWithValue("@company", speaker.Company);
                cmd.Parameters.AddWithValue("@imageUrl", speaker.ImageURL);
                cmd.Parameters.AddWithValue("@Id", speaker.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public bool IsExistSpeaker(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                string query = "select id from Speakers where id=@id";
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }
    }
}
