using System;
using TRIM.SDK;


namespace TrimScratch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var trimDb = new Database();
            trimDb.Id = "45";
            trimDb.Connect();

            var rType = new RecordType(trimDb, "TOP FOLDER");
            var newRec = new Record(rType);

            newRec.TypedTitle += "64bit";
            newRec.Save();

            Console.WriteLine(newRec.Number);
            Console.ReadLine();
        }

    }
}
