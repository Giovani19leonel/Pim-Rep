using Extension.Core.Models;
using Microsoft.AspNetCore.Mvc;
using PIM.Api.Services;

namespace PIM.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PIMController : ControllerBase
    {
        private readonly PIMServices _pim;

        public PIMController(PIMServices pim)
        {
            _pim = pim;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok("Ok");

        [HttpGet("user")]
        public async Task<IActionResult> SearchDataUser([FromQuery] long cpf) =>
            await _pim.SearchUserData(cpf);
        [HttpGet("user/all")]
        public async Task<IActionResult> SearchDataUser() =>
            await _pim.SearchLstUserDatas();

        [HttpPost("user/update")]
        public async Task<IActionResult> UpdateDataUser([FromBody] PessoaModel request) =>
            await _pim.UpdateUserData(request);

        [HttpPost("user")]
        public async Task<IActionResult> InsertDataUser([FromBody] PessoaModel request) =>
            await _pim.InsertUserData(request);

        [HttpDelete("user")]
        public async Task<IActionResult> DeleteUserData([FromQuery] int id) =>
            await _pim.DeleteUserData(id);
    }
}
