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
    [RoutePrefix("api/vendacontato")]
    public class VendaContatoController : ApiController
    {
        private IVendaContatoBusiness business;

        public VendaContatoController(IVendaContatoBusiness business)
        {
            this.business = business;
        }
        [Route("consultar")]
        [HttpGet]
        public HttpResponseMessage ConsultarTodos()
        {      //declarando uma lista..
            var response = new ContatoResponse();

            List<ConsultaVendaContatoViewModel> lista = new List<ConsultaVendaContatoViewModel>();
            try
            {
                //varrendo a consulta de funcionarios..
                foreach (VendaContato p in business.ConsultarTodos())
                {
                    ConsultaVendaContatoViewModel model = new ConsultaVendaContatoViewModel();

                    model.VendaContatoID = p.VendaContatoID;
                    model.ContatoID = p.ContatoID;
                    model.DataVenda = p.DataVenda;
                    model.Valor = p.Valor;
                   

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


        [Route("consultarporcontato")]
        [HttpGet]
        public HttpResponseMessage ConsultarPorContato(int id)
        {      //declarando uma lista..
            var response = new ContatoResponse();

            List<ConsultaVendaContatoViewModel> lista = new List<ConsultaVendaContatoViewModel>();
            try
            {
                //varrendo a consulta de funcionarios..
                foreach (VendaContato p in business.ConsultarTodos(id))
                {
                    ConsultaVendaContatoViewModel model = new ConsultaVendaContatoViewModel();

                    model.VendaContatoID = p.VendaContatoID;
                    model.ContatoID = p.ContatoID;
                    model.DataVenda = p.DataVenda;
                    model.Valor = p.Valor;
                    //model.Contato.ContatoID = p.Contato.ContatoID;
                    //model.Contato.Nome = p.Contato.Nome;
                    //model.Contato.CPF = p.Contato.CPF;
                    //model.Contato.DataCadastro = p.Contato.DataCadastro;
                    //model.Contato.DataNascimento = p.Contato.DataNascimento;
                    //model.Contato.email = p.Contato.email;
                    //model.Contato.Sexo = p.Contato.Sexo;


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