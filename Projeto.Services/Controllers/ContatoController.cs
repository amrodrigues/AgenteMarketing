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
using System.Web.Http.ModelBinding;

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

        [Route("consultarporid")]
        [HttpGet]
        public HttpResponseMessage ConsultarPorId(int id)
        {      //declarando uma lista..
            var response = new ContatoResponse();

            ConsultaContatoViewModel model = new ConsultaContatoViewModel();
            try
            {
                    Contato c = business.ConsultaPorId(id);
                    model.ContatoID = c.ContatoID;
                    model.Nome = c.Nome;
                    model.DataCadastro = c.DataCadastro;
                    model.DataNascimento = c.DataNascimento;
                    model.email = c.email;
                    model.Sexo = c.Sexo;
                    model.CPF = c.CPF;

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                response.Mensagem = e.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, model);
            }

            //return Request.CreateResponse(HttpStatusCode.BadRequest, lista);

        }
        [Route("cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(CadastroContatoViewModel request)
        {
            var response = new ContatoResponse();

            if (ModelState.IsValid)
            {
                try
                {
                    Contato c = new Contato();
                    c.Nome = request.Nome;
                    c.CPF = request.CPF;
                    c.DataCadastro = request.DataCadastro;
                    c.DataNascimento = request.DataNascimento;
                    c.email = request.email;
                    c.Sexo = request.Sexo;

                    business.Cadastrar(c);


                    response.Mensagem = $"Contato {request.Nome}, cadastrado com sucesso.";
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

        [Route("atualizar")]
        [HttpPut]

        public HttpResponseMessage Atualizar(EditarContatoViewModel request)
        {
            var response = new ContatoResponse();

            if (ModelState.IsValid)
            {
                try
                {
                    Contato c = new Contato();
                    c.ContatoID = request.ContatoID;
                    c.Nome = request.Nome;
                    c.CPF = request.CPF;
                    c.DataCadastro = request.DataCadastro;
                    c.DataNascimento = request.DataNascimento;
                    c.email = request.email;
                    c.Sexo = request.Sexo;

                    business.Atualizar(c);

                    response.Mensagem = $"Contato {request.Nome}, atualizado com sucesso.";
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


        [Route("excluir")]
        [HttpDelete]
        public HttpResponseMessage Excluir(int id)
        {
            var response = new ContatoResponse();

            if (ModelState.IsValid)
            {
                try
                {
                    Contato c = business.ConsultaPorId(id);
                    business.Excluir(c);

                    response.Mensagem = $"Contato {c.Nome}, excluido com sucesso.";
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