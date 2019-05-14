using System;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            var taga = new MsSql();
           // taga.ReadFormDatabase();
           // taga.SaveToJason();
            taga.LoadFromJason();
           // taga.WrightoDatabase();
            taga.DeleteFromDatabase();
        }
    }
}
