using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace Ado_Task_2;

public static class DataBase
{

    public static List<Car> cars = new List<Car>();
    static SqlConnection connection = null!;
    static SqlCommand command = null!;
    static SqlDataReader reader = null!;
    public static string connectionString = null!;
    public static void WriteUsersToDatabase()
    {

        using (connection = new(connectionString))
        {
            connection.Open();
            foreach (var car in cars)
            {
                command = new(@$"INSERT INTO Users(Id,Marka,Model)
                               VALUES('{car.Id}','{car.Marka}','{car.Model}')", connection);
                command.ExecuteNonQuery();
            }
        }
    }
    public static void ReadUsersToDatabase()
    {
        using (connection = new(connectionString))
        {
            connection.Open();
            command = new("SELECT * FROM [Cars]", connection);
            reader = command.ExecuteReader();
            if (reader == null) return;

            while (reader.Read())
            {
                Car car = new Car();
                car.Id = int.Parse(reader["Id"].ToString()!);
                car.Marka = reader["Marka"].ToString()!;
                car.Model = reader["Model"].ToString()!;

                cars.Add(car);
            }
        }
    }
    public static void com()
    {
        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("connectionstring.json", optional: false, reloadOnChange: true);
        var configuration = builder.Build();
        connectionString = configuration["ConnectionString"]!;
    }

    public static List<Car> FindMarka(string marka)
    {
        using (connection = new(connectionString))
        {

            connection.Open();
            command = new($@"SELECT * FROM [Cars] 
                          WHERE Marka = @C", connection);
            command.Parameters.Add("@C", System.Data.SqlDbType.NVarChar).Value = marka;
            reader = command.ExecuteReader();
            List<Car> markaC = new();
            while (reader.Read())
            {
                Car car = new Car();
                car.Id = int.Parse(reader["Id"].ToString()!);
                car.Marka = reader["Marka"].ToString()!;
                car.Model = reader["Model"].ToString()!;
                markaC.Add(car);
            }

            return markaC;
        }
    }

    public static List<Car> FindModel(string model)
    {
        using (connection = new(connectionString))
        {

            connection.Open();
            command = new($@"SELECT * FROM [Cars] 
                             WHERE Model = @C", connection);
            command.Parameters.Add("@C", System.Data.SqlDbType.NVarChar).Value = model;
            reader = command.ExecuteReader();
            List<Car> modelC = new();
            while (reader.Read())
            {
                Car car = new Car();
                car.Id = int.Parse(reader["Id"].ToString()!);
                car.Marka = reader["Marka"].ToString()!;
                car.Model = reader["Model"].ToString()!;
                modelC.Add(car);
            }

            return modelC;
        }
    }











}
