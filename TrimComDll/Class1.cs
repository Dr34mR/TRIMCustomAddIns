using System.Runtime.InteropServices;
using TRIMSDK;

namespace TrimComDll
{
    // REGISTER THE .NET DLL (which makes it COM DISCOVERABLE)

    // To Register the COM DLL:

    // cd "C:\Windows\Microsoft.NET\Framework64\v4.0.30319"         for 64bit COM DLL (match TRIM bit version)
    // cd "C:\Windows\Microsoft.NET\Framework\v4.0.30319"           for 32bit COM DLL (match TRIM bit version)

    // To Register DLL:
    // regasm "C:\Program Files\Micro Focus\Content Manager\TrimComDll.dll" /codebase /tlb

    // To UnRegister DLL:
    // regasm "C:\Program Files\Micro Focus\Content Manager\TrimComDll.dll" /unregister


    [Guid("02810C22-3FF2-4fc2-A7FD-5E103446DEB0"), ComVisible(true)]
    public class Class1 : ITRIMRecordAddIn
    {
        public void Setup(Record NewRecord)
        {
            ErrorMessage = string.Empty;

            NewRecord.TypedTitle = "TESTING";
        }

        public void PostSave(Record NewRecord, bool RecordWasJustCreated)
        {
            if (!RecordWasJustCreated) return;

            ErrorMessage = string.Empty;

            var db = NewRecord.Database;
            var rec = db.GetRecord((long)NewRecord.Uri);

            rec.AppendNotes("Fired", true);
            rec.Save();

            // FYI calling SAVE on this record will fire the POST SAVE event again
        }

        public bool PreSave(Record NewRecord)
        {
            ErrorMessage = string.Empty;
            return true;
        }

        public bool PreDelete(Record NewRecord)
        {
            ErrorMessage = string.Empty;

            return true;
        }

        public void PostDelete(Record NewRecord)
        {
            ErrorMessage = string.Empty;
        }

        public string LinkCmdName(int LinkNumber)
        {
            ErrorMessage = string.Empty;
            return string.Empty;
        }

        public string LinkCmdDescription(int LinkNumber)
        {
            ErrorMessage = string.Empty;
            return string.Empty;
        }

        public bool LinkExecute(int ParentHWND, int LinkNumber, Record ForRecord)
        {
            ErrorMessage = string.Empty;
            return true;
        }

        public bool AddPropertyPage(int ParentSheetHWND, Record ForRecord)
        {
            ErrorMessage = string.Empty;
            return false;
        }

        public string ErrorMessage { get; private set; } = string.Empty;
        public ppPluginPageType PropertyPageStyle { get; } = ppPluginPageType.ppNoPage;
    }
}
