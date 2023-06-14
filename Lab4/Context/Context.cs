using Lab_4.Models;
using Npgsql;
using System.Collections.Generic;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Lab_4.Context
{
    public class Context
    {
        private string Host = "localhost";
        private string User = "postgres";
        private string DBname = "postgres";
        private string Password = "postgres";
        private string Port = "5432";

        public void MakeDb()
        {
            string connString =
            String.Format(
                "Server={0}; Username={1}; Database={2}; Port={3}; Password={4}",
                Host,
                User,
                DBname,
                Port,
                Password);
            using var con = new NpgsqlConnection(connString);
            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"DROP TABLE IF EXISTS \"Exams\"  CASCADE";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "CREATE TABLE \"Exams\" (id SERIAL PRIMARY KEY,\n trial_name text, \n year int,\n day int,\n mounth int,\n firstname text,\n middlename text,\n lastname text,\n speciality text, \n number_group int, grade int);"; 
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"DROP TABLE IF EXISTS \"Questions\"  CASCADE";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"CREATE TABLE \"Questions\" (" +
                $"id_questions SERIAL PRIMARY KEY," +
                $"id_of_list int," +
                $"question text);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"ALTER TABLE \"Questions\" ADD FOREIGN KEY (id_of_list) REFERENCES \"Exams\" (id) ON DELETE CASCADE;\r\n";
            cmd.ExecuteNonQuery();
        }

        public void Add(Exam exam)
        {
            string connString =
            String.Format(
               "Server={0}; Username={1}; Database={2}; Port={3}; Password={4}",
               Host,
               User,
               DBname,
               Port,
               Password);
            using var con = new NpgsqlConnection(connString);
            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            using (var command = new NpgsqlCommand($"insert into \"Exams\" (\"trial_name\", \"year\", \"day\"," +
                $" \"mounth\", \"firstname\", \"middlename\", \"lastname\", \"speciality\", \"number_group\", \"grade\") " +
                @"values (@TrialName,@Year,@Day,@Mounth,@FirstName,@MiddleName,@LastName,@Speciality,@NumberGroup,@Grade) ", con))
            {
                command.Parameters.AddWithValue("TrialName", exam.Trial_name);
                command.Parameters.AddWithValue("Year", exam.Year);
                command.Parameters.AddWithValue("Day", exam.Day);
                command.Parameters.AddWithValue("Mounth", exam.Mounth);
                command.Parameters.AddWithValue("FirstName", exam.Firstname);
                command.Parameters.AddWithValue("MiddleName", exam.Middlename);
                command.Parameters.AddWithValue("LastName", exam.Lastname);
                command.Parameters.AddWithValue("Speciality", exam.Speciality);
                command.Parameters.AddWithValue("NumberGroup", exam.Number);
                command.Parameters.AddWithValue("Grade", exam.Grade);
                command.ExecuteNonQuery();
            }

            string sql = "Select id from \"Exams\"";
            int id = 0;
            using (var command = new NpgsqlCommand(sql, con))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Int32.Parse(reader["id"].ToString());
                }
                con.Close();
            }
            con.Open();
            foreach (string question in exam.Questions)
            {
                using (var command = new NpgsqlCommand($"insert into \"Questions\" (\"id_of_list\",\"question\" ) values(@IdOfList,@Question)", con))
                {
                    command.Parameters.AddWithValue("IdOfList",id);
                    command.Parameters.AddWithValue("Question",question);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Change(Exam exam)
        {
            string connString =
            String.Format(
              "Server={0}; Username={1}; Database={2}; Port={3}; Password={4}",
              Host,
              User,
              DBname,
              Port,
              Password);
            using var con = new NpgsqlConnection(connString);
            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"UPDATE \"Exams\"" +
                                    $"SET day = {exam.Day}"+
                                    $"SET mounth = {exam.Mounth}"+
                                    $" SET grade = {exam.Grade} " +
                                    $"SET speciality = {exam.Speciality}"+
                                    $"SET number_group = {exam.Number}" +
                                    $" WHERE id = {exam.Id}";
        }


        public List<Exam> Show()
        {
            List<Exam> result = new List<Exam>();
            List<string> question = new List<string>();
            Exam exam = new Exam();
            string sql = $"select * from \"Exams\"\r\nJoin \"Questions\" ON \"Questions\".id_of_list = \"Exams\".id";
            string connString =
            String.Format(
             "Server={0}; Username={1}; Database={2}; Port={3}; Password={4}",
             Host,
             User,
             DBname,
             Port,
             Password);
            using var con = new NpgsqlConnection(connString);
            con.Open();
            int id = 0;
            using (var command = new NpgsqlCommand(sql, con))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int i = 0;
                    id = Int32.Parse(reader["id"].ToString());
                    exam.Id = Int32.Parse(reader["id"].ToString());
                    exam.Trial_name = reader["trial_name"].ToString();
                    exam.Year = Int32.Parse(reader["year"].ToString());
                    exam.Day = Int32.Parse(reader["day"].ToString());
                    exam.Mounth = Int32.Parse(reader["mounth"].ToString());
                    exam.Firstname = reader["firstname"].ToString();
                    exam.Middlename = reader["middlename"].ToString();
                    exam.Lastname = reader["lastname"].ToString();
                    exam.Speciality = reader["speciality"].ToString();
                    exam.Number = Int32.Parse(reader["number_group"].ToString());
                    exam.Grade = short.Parse(reader["grade"].ToString());
                    question.Add(reader["question"].ToString());
                    exam.Questions = question;
                    result.Add(exam);
                    question = new List<string>();
                    exam = new Exam();
                }
                con.Close();
            }
            return result;
        }

        public string Delete(Delete delete)
        {
            string sql = $"select * from \"Exams\" where id = {delete.Id}";
            string connString = String.Format(
             "Server={0}; Username={1}; Database={2}; Port={3}; Password={4}",
             Host,
             User,
             DBname,
             Port,
             Password);
            using var con = new NpgsqlConnection(connString);
            con.Open();
            int id = 0;
            using (var command = new NpgsqlCommand(sql, con))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                { 
                    id = Int32.Parse(reader["id"].ToString());
                    Console.WriteLine($"id = {id}");
                }
                con.Close();

            }
            if (id != 0)
            {
                con.Open();
                sql = $"delete from \"Exams\" where id = {delete.Id}";
                using var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                sql = $"delete from \"Questions\" where id_of_list = {delete.Id}";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                return "delete";
            }
            return "invalid id";
        }

        public List<Exam> Find(Delete delete)
        {
            List<Exam> result = new List<Exam>();
            Exam exam = new Exam();
            List<string> question = new List<string>();
            string sql = $"select * from \"Exams\"\r\nJoin \"Questions\" ON \"Questions\".id_of_list = \"Exams\".id where id = {delete.Id}";
            string connString = String.Format(
             "Server={0}; Username={1}; Database={2}; Port={3}; Password={4}",
             Host,
             User,
             DBname,
             Port,
             Password);
            using var con = new NpgsqlConnection(connString);
            con.Open();
            int id = 0;
            using (var command = new NpgsqlCommand(sql, con))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Int32.Parse(reader["id"].ToString());
                }
                con.Close();
            }
            if (id != 0)
            {
                con.Open();
                using (var command = new NpgsqlCommand(sql, con))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        id = Int32.Parse(reader["id"].ToString());
                        exam.Id = Int32.Parse(reader["id"].ToString());
                        exam.Trial_name = reader["trial_name"].ToString();
                        exam.Year = Int32.Parse(reader["year"].ToString());
                        exam.Day = Int32.Parse(reader["day"].ToString());
                        exam.Mounth = Int32.Parse(reader["mounth"].ToString());
                        exam.Firstname = reader["firstname"].ToString();
                        exam.Middlename = reader["middlename"].ToString();
                        exam.Lastname = reader["lastname"].ToString();
                        exam.Speciality = reader["speciality"].ToString();
                        exam.Number = Int32.Parse(reader["number_group"].ToString());
                        exam.Grade = short.Parse(reader["grade"].ToString());
                        question.Add(reader["question"].ToString());
                        exam.Questions = question;
                        result.Add(exam);
                        question = new List<string>();
                        exam = new Exam();
                    }
                    con.Close();
                    return result;
                }
            }
            return result;
        }
    }
}








