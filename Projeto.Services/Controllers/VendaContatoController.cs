using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Entities;
using Projeto.Services.Models;
using Projeto.Business.Contracts;
using System.Web.Http.ModelBinding;

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
                    model.Contato = new ConsultaContatoViewModel();

                    model.VendaContatoID = p.VendaContatoID;
                    model.ContatoID = p.ContatoID;
                    model.DataVenda = p.DataVenda;
                    model.Valor = p.Valor;
                    model.Contato.ContatoID = p.Contato.ContatoID;
                    model.Contato.Nome = p.Contato.Nome;
                    model.Contato.CPF = p.Contato.CPF;
                    model.Contato.DataCadastro = p.Contato.DataCadastro;
                    model.Contato.DataNascimento = p.Contato.DataNascimento;
                    model.Contato.email = p.Contato.email;
                    model.Contato.Sexo = p.Contato.Sexo;


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

        [Route("cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(CadastroVendaContatoViewModel request)
        {
            var response = new ContatoResponse();

            if (ModelState.IsValid)
            {
                try
                {
                    VendaContato v = new VendaContato();
                    v.ContatoID = request.ContatoID;
                    v.DataVenda = DateTime.Now;
                    v.Valor = request.Valor;
                    
                    business.Cadastrar(v);


                    response.Mensagem = $"Venda {request.ContatoID}, cadastrado com sucesso.";
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                catch (Exception e)
                {
                    response.Mensagem = e.Message;

                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

            }
            else
            {
                response.Mensagem = ObterMensagensDeValidacao(ModelState);
                // response.Mensagem = "Ocorreram erros de validação.";
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

        }

      

        [Route("excluir")]
        [HttpDelete]
        public HttpResponseMessage Excluir(int id)
        {
            var response = new ContatoResponse();

            if (ModelState.IsValid)
            {
                try
                {
                    VendaContato v = business.ConsultaPorId(id);
                    business.Excluir(v);

                    response.Mensagem = $"Venda {v.VendaContatoID}, excluido com sucesso.";
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                catch (Exception e)
                {
                    response.Mensagem = e.Message;
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }
            }
            else
            {
                response.Mensagem = ObterMensagensDeValidacao(ModelState);
                //  response.Mensagem = "Ocorreram erros de validação.";
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        private string ObterMensagensDeValidacao(ModelStateDictionary model)
        {
            List<string> erros = new List<string>();
            foreach (var m in model)
            {
                if (m.Value.Errors.Count > 0)
                {
                    erros.Add(m.Value.Errors.Select

                    (s => s.ErrorMessage).FirstOrDefault());

                }
            }
            return string.Join(",", erros);
        }

    }
}