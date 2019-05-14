using System;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            MsSql taga = new MsSql();
            taga.ReadFormDatabase();
            Console.WriteLine("give the name of the file you want to save");
            string name = Console.ReadLine( );
            taga.SaveToJason(name);
            taga.LoadFromJason();
           // taga.WrightoDatabase();
            //taga.DeleteFromDatabase();
        }
    }
}
