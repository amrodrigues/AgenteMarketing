using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Entities;
using Projeto.Services.Models;
using Projeto.Business.Contracts;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        private IProdutoBusiness business;

        public ProdutoController(IProdutoBusiness business)
        {
            this.business = business;
        }


        [Route("consultar")]
        [HttpGet]
        public HttpResponseMessage ConsultarTodos()
        {      //declarando uma lista..
            var response = new ContatoResponse();

            List<ConsultaProdutoViewModel> lista = new List<ConsultaProdutoViewModel>();
            try
            {
                //varrendo a consulta de funcionarios..
                foreach (Produto p in business.ConsultarTodos())
                {
                    ConsultaProdutoViewModel model = new ConsultaProdutoViewModel();
                    model.ProdutoID = p.ProdutoID;
                    model.NomeProduto = p.NomeProduto;
           

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