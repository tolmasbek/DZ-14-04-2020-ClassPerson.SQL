using System;
using System.Data.SqlClient;
using System.Data;
using DZ_13_04SQL;

namespace DZ13_04SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            const string constring = @"Data source = TOLMASBEK-ПК; initial catalog = db_tolmasbek; integrated Security = True";
            SqlConnection connect = new SqlConnection(constring);
                connect.Open();
            if(connect.State == ConnectionState.Open)
            {
                System.Console.WriteLine("connected ...");
            }
            else
            {
                System.Console.WriteLine("not connected ...");
            }
            System.Console.Write("Выберите какую то функцию:\n1 Добавление в таблицу\n2 Выбрать все\n3 Выбрать один по Id\n4 Обновить столбец кроме Id\n5 Удалить по Id");
            System.Console.WriteLine();
            string commandCode = "";
            int n = 0;
            n = int.Parse(Console.ReadLine());
            switch(n)
            {
                case 1:
                {
                    commandCode = "SELECT * FROM Person";
                    SqlCommand command = new SqlCommand(commandCode, connect);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        System.Console.WriteLine($"id: {reader.GetValue(0)},\nlastname: {reader.GetValue(1)},\nfirstname: {reader.GetValue(2)},\nmiddlename: {reader.GetValue(3)},\ndatebirth: {reader.GetValue(4)}");
                    }
                    reader.Close();

                    string insertDataToTable = string.Format($"INSERT INTO Person ([LastName],[FirstName],[MiddleName],[BirthDate]) VALUES('{"Farmonov"}', '{"Suhrob"}', '{"Turgolibovich"}', '{"09-05-2004"}') ");
                    command = new SqlCommand(insertDataToTable, connect);
                
                    var result = command.ExecuteNonQuery();
                    if(result > 0)
                    {
                        System.Console.WriteLine("Yes, Inserted!!!");
                    }
                    else
                    {
                        System.Console.WriteLine("Not");
                    }
                    
                    break;
                }
                case 2:
                {
                    commandCode = "SELECT * FROM Person";
                    SqlCommand command = new SqlCommand(commandCode, connect);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        System.Console.WriteLine($"id: {reader.GetValue(0)},\nlastname: {reader.GetValue(1)},\nfirstname: {reader.GetValue(2)},\nmiddlename: {reader.GetValue(3)},\ndatebirth: {reader.GetValue(4)}");
                    }
                    reader.Close();

                    break;
                }
                case 3:
                {
                    commandCode = "SELECT * FROM Person WHERE Id = 3;";
                    SqlCommand command = new SqlCommand(commandCode, connect);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        System.Console.WriteLine($"id: {reader.GetValue(0)},\nlastname: {reader.GetValue(1)},\nfirstname: {reader.GetValue(2)},\nmiddlename: {reader.GetValue(3)},\ndatebirth: {reader.GetValue(4)}");
                    }
                    reader.Close();
                    break;
                }
                case 4:
                {
                    commandCode = "UPDATE Person SET [LastName] = 'TTTTTT', [FirstName] = 'S', [MiddleName] = 'FDSF', [BirthDate] = '12-03-2032' WHERE Id = 1;";
                    SqlCommand command = new SqlCommand(commandCode, connect);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        System.Console.WriteLine($"id: {reader.GetValue(0)},\nlastname: {reader.GetValue(1)},\nfirstname: {reader.GetValue(2)},\nmiddlename: {reader.GetValue(3)},\ndatebirth: {reader.GetValue(4)}");
                    }
                    reader.Close();
                    var result = command.ExecuteNonQuery();
                    if(result > 0)
                    {
                        System.Console.WriteLine("Yes, UPDATED!!!");
                    }
                    break;
                }
            }


            connect.Close();    
            Console.ReadKey();
        }
    }
}
