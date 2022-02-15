﻿using System;
using System.IO;
using System.Text;
using System.Data.SQLite;
class HabitProgram
{
    public static void Main()
    {
        SQLiteConnection sqlite_conn;
        sqlite_conn = CreateConnection();
        try
        {
            CreateTable(sqlite_conn);
        }
        catch (Exception ex)
        { }
        SwitchCommand(sqlite_conn);
    }

    static SQLiteConnection CreateConnection()
    {

        SQLiteConnection sqlite_conn;
        sqlite_conn = new SQLiteConnection("Data Source = database.db; Version = 3; New = True; Compress = True; ");
        try
        {
            sqlite_conn.Open();
        }
        catch (Exception ex)
        {

        }
        return sqlite_conn;
    }

    static void CreateTable(SQLiteConnection conn)
    {
        SQLiteCommand sqlite_cmd;
        string Createsql = "CREATE TABLE HabitTable (ID INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT NOT NULL, NumOfPushups INT NOT NULL)";
         sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = Createsql;
        sqlite_cmd.ExecuteNonQuery();
    }
    public static void SwitchCommand(SQLiteConnection conn)
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
                    ViewRecords(conn);
                    break;
                case 2:
                    InsertRecord(conn);
                    break;
                case 3:
                    DeleteRecord(conn);
                    break;
                case 4:
                    UpdateRecord(conn);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    SwitchCommand(conn);
                    break;
            }
        }
        else 
        {
            Console.WriteLine("invalid input");
            SwitchCommand(conn);
        }
       
    }

    static void ViewRecords(SQLiteConnection conn)
    {
        SQLiteDataReader sqlite_datareader;
        SQLiteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "SELECT * FROM HabitTable";

        sqlite_datareader = sqlite_cmd.ExecuteReader();
        while (sqlite_datareader.Read())
        {
            string myreader = sqlite_datareader.GetString(0);
            Console.WriteLine(myreader);
        }
        conn.Close();
    }
    public static void InsertRecord(SQLiteConnection conn) 
    {
        string[] querryText = { "Inserd date", "Insert number of pushups" };
        string[] userInput = {"",""};
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine(querryText[i]);
            userInput[i] = Console.ReadLine();
        }
        SQLiteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "INSERT INTO HabitTable (Date, NumOfPushups) VALUES('" + userInput[0]+"','"+userInput[1]+"'); ";
        sqlite_cmd.ExecuteNonQuery();
        SwitchCommand(conn);
    }
    public static void DeleteRecord(SQLiteConnection conn) 
    {
        int idNum = Convert.ToInt32(Console.ReadLine());
        SQLiteCommand sqlite_cmd;
        sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = "DELETE FROM HabitTable WHERE ID = "+idNum+";";
        sqlite_cmd.ExecuteNonQuery();
        SwitchCommand(conn);
    }
    public static void UpdateRecord(SQLiteConnection conn) 
    {
        //Update by ID
        SwitchCommand(conn);
    }
}

