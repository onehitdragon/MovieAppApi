using Npgsql;
using System;
using System.Data;
namespace MovieAppApi.DataBase{
    class DataProvider{
        public static bool CheckConnection(){
            try{
                NpgsqlConnection connection = new NpgsqlConnection(DataBaseConfig.connectionNoDBStr);
                connection.Open();
                connection.Close();
                return true;
            }
            catch(Exception e){
                Console.WriteLine(e.ToString());
                return false;
            }
        }
        public void ExcuteQueryNoDB(string query){
            NpgsqlConnection connection = new NpgsqlConnection(DataBaseConfig.connectionNoDBStr);
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void ExcuteQuery(string query){
            NpgsqlConnection connection = new NpgsqlConnection(DataBaseConfig.connectionStr);
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable GetDataTable(string query){
            NpgsqlConnection connection = new NpgsqlConnection(DataBaseConfig.connectionStr);
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            
            return table;
        }
    }
}