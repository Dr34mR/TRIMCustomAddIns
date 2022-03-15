using System.Diagnostics;
using TRIM.SDK;

namespace TrimNetDll
{
    public class Class1 : ITrimAddIn
    {
        public override void Setup(TrimMainObject newObject)
        {
            if (newObject is not Record trimRec) return;

            trimRec.TypedTitle = "GenericAddinTesting15";
        }

        public override void PostSave(TrimMainObject savedObject, bool itemWasJustCreated)
        {
            Debugger.Launch();
            if (!itemWasJustCreated) return;
            if (savedObject is not Record trimRec) return;

            trimRec.SetNotes("GenericSuccess", NotesUpdateType.PrependWithUserStamp);
            trimRec.Save();
        }

        public override void Initialise(Database db)
        {
            return;
        }

        public override TrimMenuLink[] GetMenuLinks()
        {
            return new TrimMenuLink[0];
        }

        public override bool IsMenuItemEnabled(int cmdId, TrimMainObject forObject)
        {
            return false;
        }

        public override void ExecuteLink(int cmdId, TrimMainObject forObject, ref bool itemWasChanged)
        {
            
        }

        public override void ExecuteLink(int cmdId, TrimMainObjectSearch forTaggedObjects)
        {
            
        }

        

        public override bool PreSave(TrimMainObject modifiedObject)
        {
            return true;
        }

        

        public override bool PreDelete(TrimMainObject modifiedObject)
        {
            return true;
        }

        public override void PostDelete(TrimMainObject deletedObject)
        {
        }

        public override bool SupportsField(FieldDefinition field)
        {
            return false;
        }

        public override bool SelectFieldValue(FieldDefinition field, TrimMainObject trimObject, string previousValue)
        {
            return true;
        }

        public override bool VerifyFieldValue(FieldDefinition field, TrimMainObject trimObject, string newValue)
        {
            return true;
        }

        public override string ErrorMessage { get; } = string.Empty;
    }
}
