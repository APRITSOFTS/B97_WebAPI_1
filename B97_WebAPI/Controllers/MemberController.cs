using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using B97_WebAPI.Models.Repository;
using B97_WebAPI.Models;


namespace B97_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository = new MemberRepository();

        [HttpGet]
        public ActionResult<List<Member>> GetAllMembers()
        {
            return _memberRepository.GetAllMembers();
        }
        [HttpGet(Name = "GetMember")]
        public IActionResult GetMember(int id)
        {
            var member = _memberRepository.GetMember(id);
            return member == null ? NotFound() :Ok(member);
        }
        [HttpGet(Name = "GetMemberd")]
        public ActionResult<Member> GetMemberd(int id)
        {
            return _memberRepository.GetMember(id);
           
        }
        [HttpGet]
        public string GetMessage()
        {
            return "Web API String method";
        }
        [HttpGet]
        public Member GetMemberDetails(int id)
        {
            return _memberRepository.GetMember(id);
        }
    }
}
