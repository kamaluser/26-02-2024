using Day40_Task.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day40_Task.Data
{
    internal class EventDao
    {
        private string connectionStr = "Server=LAPTOP-IGIN0GLR\\SQLEXPRESS;Database=Day40_Task;Trusted_Connection=true";
        public int InsertEvent(string name, string desc, string address, DateOnly startdate, TimeOnly starttime, TimeOnly endtime)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "insert into Events(name, desc, address, startdate, starttime, endtime) values (@name, @desc, @address, @startdate, @starttime, @endtime)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@desc", desc);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@startdate", startdate);
                    cmd.Parameters.AddWithValue("@starttime", starttime);
                    cmd.Parameters.AddWithValue("@endtime", endtime);

                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int DeleteEvent(int id)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "delete from events where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public Event GetEventById(int id)
        {
            Event e = null;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select TOP(1) * from events where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return null;
                        while (reader.Read())
                        {
                            e = new Event();
                            e.Id = reader.GetInt32(0);
                            e.Name = reader.GetString(1);
                            e.Desc = reader.GetString(2);
                            e.Address = reader.GetString(3);
                            var d = DateOnly.FromDateTime(reader.GetDateTime(4));
                            e.StartDate = d;
                            var c = TimeOnly.FromTimeSpan(reader.GetTimeSpan(5));
                            e.StartTime = c;
                            var f = TimeOnly.FromTimeSpan(reader.GetTimeSpan(6));
                            e.StartTime = f;
                        }
                    }
                }
            }
            return e;
        }

        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select * from events";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return events;
                        while (reader.Read())
                        {
                            Event e = new Event();
                            e.Id = reader.GetInt32(0);
                            e.Name = reader.GetString(1);
                            e.Desc = reader.GetString(2);
                            e.Address = reader.GetString(3);
                            var d = DateOnly.FromDateTime(reader.GetDateTime(4));
                            e.StartDate = d;
                            var c = TimeOnly.FromTimeSpan(reader.GetTimeSpan(5));
                            e.StartTime = c;
                            var f = TimeOnly.FromTimeSpan(reader.GetTimeSpan(6));
                            e.StartTime = f;
                            events.Add(e);
                        }
                    }
                }
            }
            return events;
        }

        public void AddSpeaker(int eventId, int speakerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string query = "INSERT INTO EventSpeakers (EventId, SpeakerId) VALUES (@EventId, @SpeakerId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EventId", eventId);
                command.Parameters.AddWithValue("@SpeakerId", speakerId);

                command.ExecuteNonQuery();
            }
        }

        public int RemoveSpeaker(int eventId, int speakerId)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string query = "DELETE FROM EventSpeakers WHERE EventId = @EventId AND SpeakerId = @SpeakerId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EventId", eventId);
                command.Parameters.AddWithValue("@SpeakerId", speakerId);

                result = command.ExecuteNonQuery();
            }
            if (result != 0)
            {
                return result;
            }
            else
            {
                return -1;
            }
            
        }

        public bool IsExistEvent(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                string query = "select id from Events where id = @id";
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
