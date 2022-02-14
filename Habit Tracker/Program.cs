using System;
using System.IO;
using System.Text;
class HabitProgram
{

    public static void Main()
    {
        try
        {
            CreateDataFile();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
      
        SwitchCommand();


    }
    public static void SwitchCommand()
    {
        Console.WriteLine("\nMAIN MENU\n\n" +
            "What would you like to do?\n" +
            "Type 0 to Close Application.\n" +
            "Type 1 to View All Records.\n" +
            "Type 2 to Insert Record.\n" +
            "Type 3 to Delete Record.\n" +
            "Type 4 to Update Record.\n");

        int commandNumber = Convert.ToInt32(Console.ReadLine());

        switch (commandNumber)
        {
            case 0:
                Environment.Exit(1);
                break;
            case 1:
                WorkInProgress();
                break;
            case 2:
                WorkInProgress();
                break;
            case 3:
                WorkInProgress();
                break;
            case 4:
                WorkInProgress();
                break;
            default:
                WorkInProgress();
                break;
        }
    }

    public static void CreateDataFile()
    {
        string path = @"D:\Projects\Habit Tracker\HabitData.sqlite";
        if (File.Exists(path))
            return;
        FileStream fs = File.Create(path);
    }

    public static void WorkInProgress()
    {
        Console.WriteLine("working.. not yet");
        Console.ReadLine();
    }
}

