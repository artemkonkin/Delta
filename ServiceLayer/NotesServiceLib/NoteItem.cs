using FactoryServiceLib;

namespace NotesServiceLib
{
    public class NoteItem : IBaseItem
    {
        public NoteItem(){}

        public NoteItem(string title, string text, string userId)
        {
            Title = title;
            Text = text;
            UserId = userId;
        }

        public string Title { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }

        public bool CheckData()
        {
            throw new NotImplementedException();
        }
    }
}
