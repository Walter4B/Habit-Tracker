using System;
using System.IO;
using System.Text;
class HabitProgram
{
    public static void Main()
    {
        string dataPath = @"D:\Projects\Habit Tracker\HabitData.sqlite";
        FileStream fs = CreateDataFile(dataPath);
        SwitchCommand(fs);
    }
    public static void SwitchCommand(FileStream fs)
    {
        Console.WriteLine("\nMAIN MENU\n\n" +
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

                    ViewRecords(fs);
                    break;
                case 2:
                    InsertRecord(fs);
                    break;
                case 3:
                    DeleteRecord(fs);
                    break;
                case 4:
                    UpdateRecord(fs);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    SwitchCommand(fs);
                    break;
            }
        }
        SwitchCommand(fs);
    }

    public static FileStream CreateDataFile(string path)
    {
        FileStream fs = File.Open(path, FileMode.OpenOrCreate);
        return fs;
    }

    public static void ViewRecords(FileStream fs)
    { 

    }
    public static void InsertRecord(FileStream fs) 
    { 
    
    }
    public static void DeleteRecord(FileStream fs) 
    { 
    
    }
    public static void UpdateRecord(FileStream fs) 
    { 
    
    }

}

