using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Services.Models;
using Projeto.Entities;
using Projeto.Repository;
using Projeto.Business;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/contato")]
    public class ContatoController : ApiController
    {
        private IContatoBusiness business;
      
        public ContatoController(IContatoBusiness business)
        {
            this.business = business;
        }
        

        [Route("consultar")]
        [HttpGet]
        public HttpResponseMessage ConsultarTodos()
        {      //declarando uma lista..
            var response = new ContatoResponse();

            List<ConsultaContatoViewModel> lista = new List<ConsultaContatoViewModel>();
            try
            {
                //varrendo a consulta de funcionarios..
                foreach (Contato c in business.ConsultarTodos())
                {
                    ConsultaContatoViewModel model = new ConsultaContatoViewModel();
                    model.ContatoID = c.ContatoID;
                    model.Nome = c.Nome;
                    model.DataCadastro = c.DataCadastro;
                    model.DataNascimento = c.DataNascimento;
                    model.email = c.email;
                    model.Sexo = c.Sexo;
                    model.CPF = c.CPF;

                    lista.Add(model); //adicionando..
               
                }
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                response.Mensagem = e.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

            //return Request.CreateResponse(HttpStatusCode.BadRequest, lista);

        }

    }
}