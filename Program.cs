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
                // Insert (Добавление)
                case 1:
                {
                    string lname, fname, mname, bdate;
                    System.Console.Write($"LastName: ");
                        lname = Console.ReadLine();
                    System.Console.Write($"FirstName: ");
                        fname = Console.ReadLine();
                    System.Console.Write($"MiddleName: ");
                        mname = Console.ReadLine();
                    System.Console.Write($"BirthDate: ");
                        bdate = Console.ReadLine();

                    commandCode = "SELECT * FROM Person";
                    SqlCommand command = new SqlCommand(commandCode, connect);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        System.Console.WriteLine($"id: {reader.GetValue(0)},\nlastname: {reader.GetValue(1)},\nfirstname: {reader.GetValue(2)},\nmiddlename: {reader.GetValue(3)},\ndatebirth: {reader.GetValue(4)}");
                    }
                    reader.Close();

                    string insertDataToTable = string.Format($"INSERT INTO Person ([LastName],[FirstName],[MiddleName],[BirthDate]) VALUES('{lname}', '{fname}', '{mname}', '{bdate}') ");
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
                // Select All (Выбрать всё)
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
                // Select by Id (Выбрать один по Id)
                case 3:
                {
                    int num;
                    System.Console.Write("Введите Id строки которую хотите вывести: ");
                    num = int.Parse(Console.ReadLine());
                    commandCode = $"SELECT * FROM Person WHERE Id = '{num}';";
                    SqlCommand command = new SqlCommand(commandCode, connect);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        System.Console.WriteLine($"id: {reader.GetValue(0)},\nlastname: {reader.GetValue(1)},\nfirstname: {reader.GetValue(2)},\nmiddlename: {reader.GetValue(3)},\ndatebirth: {reader.GetValue(4)}");
                    }
                    reader.Close();
                    break;
                }
                // Update (Обновить каждый столбец кроме Id)
                case 4:
                {
                    int num;
                    System.Console.Write("Введите Id строки которую хотите Изменить: ");
                    num = int.Parse(Console.ReadLine());
                    string lname, fname, mname, bdate;
                    System.Console.Write($"LastName: ");
                        lname = Console.ReadLine();
                    System.Console.Write($"FirstName: ");
                        fname = Console.ReadLine();
                    System.Console.Write($"MiddleName: ");
                        mname = Console.ReadLine();
                    System.Console.Write($"BirthDate: ");
                        bdate = Console.ReadLine();

                    commandCode = $"UPDATE Person SET [LastName] = '{lname}', [FirstName] = '{fname}', [MiddleName] = '{mname}', [BirthDate] = '{bdate}' WHERE Id = '{num}';";
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
                // Delete (Удалить один по Id)
                case 5:
                {
                    int num;
                    System.Console.Write("Введите Id строки которую хотите Удалить: ");
                    num = int.Parse(Console.ReadLine());

                    commandCode = $"DELETE Person WHERE Id = '{num}';";
                    SqlCommand command = new SqlCommand(commandCode, connect);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        System.Console.WriteLine($"id: {reader.GetValue(0)},\nlastname: {reader.GetValue(1)},\nfirstname: {reader.GetValue(2)},\nmiddlename: {reader.GetValue(3)},\ndatebirth: {reader.GetValue(4)}");
                    }
                    reader.Close();                    
                    break;
                }
            }
            connect.Close();    
            Console.ReadKey();
        }
    }
}
