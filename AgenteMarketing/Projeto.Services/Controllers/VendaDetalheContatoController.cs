using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Entities;
using Projeto.Services.Models;
using Projeto.Business.Contracts;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/vendadetalhecontato")]
    public class VendaDetalheContatoController : ApiController
    {
        private IVendaDetalheContatoBusiness business;

        public VendaDetalheContatoController(IVendaDetalheContatoBusiness business)
        {
            this.business = business;
        }
        [Route("consultar")]
        [HttpGet]
        public HttpResponseMessage ConsultarTodos()
        {      //declarando uma lista..
            var response = new ContatoResponse();

            List<ConsultaVendaDetalheContatoViewModel> lista = new List<ConsultaVendaDetalheContatoViewModel>();
            try
            {
                //varrendo a consulta de funcionarios..
                foreach (VendaDetalheContato p in business.ConsultarTodos())
                {
                    ConsultaVendaDetalheContatoViewModel model = new ConsultaVendaDetalheContatoViewModel();
                    
                    model.VendaDetalheContatoid = p.VendaDetalheContatoid;
                    model.VendaContatoId = p.VendaContatoId;
                    model.ProdutoId = p.ProdutoId;
                    model.Valor = p.Valor;
                    model.Quantidade = p.Quantidade;
                    //model.Produto.ProdutoID = p.Produto.ProdutoID;
                    //model.Produto.NomeProduto = p.Produto.NomeProduto;


                    lista.Add(model); //adicionando..

                }
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                response.Mensagem = e.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

     
        }

    }
}