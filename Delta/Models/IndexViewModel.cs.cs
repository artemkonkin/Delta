namespace Delta.Models
{
    public record VueUser
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public record IndexViewModel
    {
        public VueUser User { get; set; }

        public List<VueUser> FriendList { get; set; }
    }
}