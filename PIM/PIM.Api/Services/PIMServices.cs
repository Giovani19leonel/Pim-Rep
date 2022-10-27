using Extension.Core.Models;
using Extension.Core.Services;
using Extension.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIM.Api.Constants;

namespace PIM.Api.Services
{
    public class PIMServices : PessoaDAO
    {
        public PIMServices(UserContext userContext) : base(userContext)
        {
        }

        public async Task<IActionResult> SearchUserData(long cpf)
        {
            var data = await GetPessoa(cpf);
            if (data == null)
                return ErrorResponse(PIMErrors.DataUserNotFound);
            return SuccessResponse(data);
        }

        public async Task<IActionResult> SearchLstUserDatas()
        {
            var data = await GetListaPessoas();
            if(data == null)
                return ErrorResponse(PIMErrors.DataUserNotFound);
            return SuccessResponse(data);
        }

        public async Task<IActionResult> InsertUserData(PessoaModel model)
        {
            var data = await InsertPessoa(model);
            if (!data.valid)
                return ErrorResponse(data.errorResp);
            return SuccessResponse("Usuário cadastrado com sucesso");
        }

        public async Task<IActionResult> UpdateUserData(PessoaModel model)
        {
            var data = await UpdatePessoa(model);
            if(data == string.Empty)
                return ErrorResponse(PIMErrors.DataUserNotFound);
            if (data != null)
                return ErrorResponse(data);
            return SuccessResponse("Usuário atualizado com sucesso");
        }

        public async Task<IActionResult> DeleteUserData(int id)
        {
            var data = await DeletePessoa(id);
            if (!data.valid)
            {
                if(data.errorResp == string.Empty)
                    return ErrorResponse(PIMErrors.DataUserNotFound);
                return ErrorResponse(data.errorResp);
            }
                
            return SuccessResponse("Usuário deletado com sucesso");
        }

        private IActionResult SuccessResponse<T>(T data)
        {
            return new OkObjectResult(data);
        }

        private IActionResult ErrorResponse(string message)
        {
            return new BadRequestObjectResult(new ErrorResponse(message));
        }
    }

    public class ErrorResponse
    {
        public ErrorResponse()
        {

        }

        public ErrorResponse(string msg)
        {
            this.message = msg;
        }

        public string message { get; set; }
    }
}
