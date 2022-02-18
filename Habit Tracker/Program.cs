﻿using System;
using System.IO;
using System.Text;
using System.Data.SQLite;
class HabitProgram
{
    public static string connectionString = "Data Source = database.db; Version = 3; New = True; Compress = True; ";
    public static void Main()
    {
        CreateTable();
        SwitchCommand();
    }
    static void CreateTable()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                connection.Open();
                string Createsql = @"CREATE TABLE IF NOT EXISTS HabitTable (ID INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT NOT NULL, NumOfPushups INT NOT NULL)";
                command.CommandText = Createsql;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
    public static void SwitchCommand()
    {
        Console.WriteLine("\n       MAIN MENU       \n\n" +
            "What would you like to do?\n" +
            "Type 0 to Close Application.\n" +
            "Type 1 to View All Records.\n" +
            "Type 2 to Insert Record.\n" +
            "Type 3 to Delete Record.\n" +
            "Type 4 to Update Record.\n");

        string userInput = Console.ReadLine();
        int commandNumber;

        if (int.TryParse(userInput, out commandNumber))
        {
            switch (commandNumber)
            {
                case 0:
                    Environment.Exit(1);
                    break;
                case 1:
                    ViewRecords();
                    break;
                case 2:
                    InsertRecord();
                    break;
                case 3:
                    DeleteRecord();
                    break;
                case 4:
                    UpdateRecord();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    SwitchCommand();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
            SwitchCommand();
        }
    }
    static void ViewRecords()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM HabitTable";
                using (SQLiteDataReader sqlDataReader = command.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader.GetInt32(0)} - {sqlDataReader.GetString(1)} - {sqlDataReader.GetInt32(2)}");
                    }
                }
                connection.Close();
            }
        }
        SwitchCommand();
    }
    public static void InsertRecord()
    {
        string userInputDate;
        do {
            Console.WriteLine("Inserd date");
            userInputDate = Console.ReadLine();
        } while (IsNullOrEmpty(userInputDate));
        int userInputQuantity = UserNumberInput("Insert number of pushups");
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = $"INSERT INTO HabitTable (Date, NumOfPushups) VALUES('{userInputDate}','{userInputQuantity}');";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        SwitchCommand();
    }
    public static void DeleteRecord()
    {
        int idNum;
        idNum = UserNumberInput("Which entry would you like to remove?");
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = $"DELETE FROM HabitTable WHERE ID = '{idNum}';";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        SwitchCommand();
    }
    public static void UpdateRecord()
    {
        string userInputDate;
        int userInputQuantity;
        int idNum = UserNumberInput("Which entry would you like to update?");
        do
        {
            Console.WriteLine("Insert date");
            userInputDate = Console.ReadLine();
        } while (IsNullOrEmpty(userInputDate));
        userInputQuantity = UserNumberInput("Insert number of pushups");
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = $"UPDATE HabitTable SET Date ='{userInputDate}', NumOfPushups = '{userInputQuantity}' WHERE ID = '{idNum}'";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        SwitchCommand();
    }
    public static bool IsNullOrEmpty<T>(T value)
    {
        string convertedString = Convert.ToString(value);
        bool result;
        result = convertedString == null || convertedString == string.Empty;
        if (result == false)
        { }
        Console.WriteLine();
        return result;
    }
    internal static int UserNumberInput(string message)
    {
        Console.WriteLine(message);
        string userInupt = Console.ReadLine();

        while (!Int32.TryParse(userInupt, out _) || Convert.ToInt32(userInupt) < 0)
        {
            Console.Write("The value must be of positive integer type, try again: ");
            userInupt = Console.ReadLine();
        }

        return Convert.ToInt32(userInupt);
    }
}

