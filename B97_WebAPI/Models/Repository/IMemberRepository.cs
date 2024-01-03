namespace B97_WebAPI.Models.Repository
{
    public interface IMemberRepository
    {
        List<Member> GetAllMembers();
        Member GetMember(int id);
    }
}