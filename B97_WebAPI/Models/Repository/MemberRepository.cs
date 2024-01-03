namespace B97_WebAPI.Models.Repository
{
    public class MemberRepository : IMemberRepository
    {
        readonly List<Member> members = new List<Member>
        {
            new Member { Id = 101,Name="Swathi",Address="Hyderabad"},
            new Member { Id = 102,Name="Arun",Address="Guntur"},
            new Member { Id = 103,Name="Durga",Address="Vijayawada"},
            new Member { Id = 104,Name="Dinesh",Address="Eluru"},
            new Member { Id = 105,Name="Satya",Address="Warangal"}
        };

        public List<Member> GetAllMembers()
        {
            return members;
        }
        public Member GetMember(int id)
        {
            return members.FirstOrDefault(x => x.Id == id);
        }
    }
}
