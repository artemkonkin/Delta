namespace NoteDomain
{
    public partial class NoteEntity
    {
        public NoteEntity(string title, string text, string userId)
        {
            Title = title;
            Text = text;
            UserId = userId;
        }

        public bool ValidOnAdd()
        {
            return
                !string.IsNullOrEmpty(Title)
                && !string.IsNullOrEmpty(Text)
                && !string.IsNullOrEmpty(UserId);
        }
    }
}