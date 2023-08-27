using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FluentValidation.Results;
using FluentValidation;
using X.PagedList;
using DS.Domain.ClientControll;
using DS.ClientControllSystem.Core;
using DS.Service.ClientControll.Interface;

namespace DS.ClientControllSystem.Controllers
{
    [Route("api/[controller]")]
    public class ClientesPessoaFisicaController : ApiBase
    {
        private readonly IClientePessoaFisicaService _service;
        private readonly IValidator<ClientePessoaFisica> _validator;

        public ClientesPessoaFisicaController(NotificationContext notificationContext, IClientePessoaFisicaService service, IValidator<ClientePessoaFisica> validator)
        {
            _notificationContext = notificationContext;
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        [Authorize(Roles = "manager, employee")]
        public JsonReturn Get()
        {
            return ReturnJson(_service.Get());
        }

        [HttpGet("byPage")]
        [Authorize(Roles = "manager, employee")]
        public JsonReturn GetByPage(int pagina, int itensPorPagina)
        {
            return ReturnJson(_service.Get().ToPagedList(pagina, itensPorPagina));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "manager, employee")]
        public JsonReturn Get(int id)
        {
            return ReturnJson(_service.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public JsonReturn Post([FromBody] ClientePessoaFisica cliente)
        {
            if (cliente == null)
                return ReturnJson("Por favor, passe alguma informação.", HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(cliente, options => options.IncludeRuleSets("insert"));

            if (results.IsValid)
                return ReturnJson(_service.Insert(cliente));
            else
                return ReturnJson(results.Errors, HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        public JsonReturn Put([FromBody] ClientePessoaFisica cliente)
        {
            if (cliente == null)
                return ReturnJson("Por favor, passe alguma informação.", HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(cliente, options => options.IncludeRuleSets("update"));

            if (results.IsValid)
                return ReturnJson(_service.Update(cliente));
            else
                return ReturnJson(results.Errors, HttpStatusCode.BadRequest);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        public JsonReturn Delete(int id)
        {
            return ReturnJson(_service.Delete(id));
        }
    }
}
