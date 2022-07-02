using FactoryServiceLib;

namespace NotesServiceLib
{
    public class NotesFactory : BaseFactory
    {
        public override IBaseItem Create()
        {
            return new NoteItem("", "", "");
        }
    }
}