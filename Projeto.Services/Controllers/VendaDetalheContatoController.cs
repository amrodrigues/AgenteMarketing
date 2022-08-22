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
                    model.Produto = new ConsultaProdutoViewModel();
                    model.VendaContato = new ConsultaVendaContatoViewModel();

                    model.VendaDetalheContatoid = p.VendaDetalheContatoid;
                    model.VendaContatoId = p.VendaContatoId;
                    model.ProdutoId = p.ProdutoId;
                    model.Valor = p.Valor;
                    model.Quantidade = p.Quantidade;
                    model.Produto.ProdutoID = p.Produto.ProdutoID;
                    model.Produto.NomeProduto = p.Produto.NomeProduto;
                    model.VendaContato.VendaContatoID = p.VendaContato.VendaContatoID;
                    model.VendaContato.Valor = p.VendaContato.Valor;
                    model.VendaContato.DataVenda = p.VendaContato.DataVenda;
                    model.VendaContato.ContatoID = p.VendaContato.ContatoID;
                    //model.VendaContato.Contato.ContatoID = p.VendaContato.Contato.ContatoID;
                    //model.VendaContato.Contato.Nome = p.VendaContato.Contato.Nome;
                    //model.VendaContato.Contato.CPF = p.VendaContato.Contato.CPF;
                    //model.VendaContato.Contato.DataCadastro = p.VendaContato.Contato.DataCadastro;
                    //model.VendaContato.Contato.DataNascimento = p.VendaContato.Contato.DataNascimento;
                    //model.VendaContato.Contato.email = p.VendaContato.Contato.email;
                    //model.VendaContato.Contato.Sexo = p.VendaContato.Contato.Sexo;

                    lista.Add(model); //adicionando..SS

                }
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                response.Mensagem = e.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

     
        }

        [Route("consultarporid")]
        [HttpGet]
        public HttpResponseMessage ConsultarTodos(int id)
        {      //declarando uma lista..
            var response = new ContatoResponse();

            List<ConsultaVendaDetalheContatoViewModel> lista = new List<ConsultaVendaDetalheContatoViewModel>();
            try
            {
                //varrendo a consulta de funcionarios..
                foreach (VendaDetalheContato p in business.ConsultarTodos(id))
                {
                    ConsultaVendaDetalheContatoViewModel model = new ConsultaVendaDetalheContatoViewModel();
                    model.Produto = new ConsultaProdutoViewModel();
                    model.VendaContato = new ConsultaVendaContatoViewModel();

                    model.VendaDetalheContatoid = p.VendaDetalheContatoid;
                    model.VendaContatoId = p.VendaContatoId;
                    model.ProdutoId = p.ProdutoId;
                    model.Valor = p.Valor;
                    model.Quantidade = p.Quantidade;
                    model.Produto.ProdutoID = p.Produto.ProdutoID;
                    model.Produto.NomeProduto = p.Produto.NomeProduto;
                    model.VendaContato.VendaContatoID = p.VendaContato.VendaContatoID;
                    model.VendaContato.Valor = p.VendaContato.Valor;
                    model.VendaContato.DataVenda = p.VendaContato.DataVenda;
                    model.VendaContato.ContatoID = p.VendaContato.ContatoID;

                    lista.Add(model); //adicionando..SS

                }
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                response.Mensagem = e.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }


        }
        public HttpResponseMessage Cadastrar(CadastroVendaContatoDetalheViewModel request)
        {
            var response = new ContatoResponse();

            if (ModelState.IsValid)
            {
                try
                {
                    VendaDetalheContato vd = new VendaDetalheContato();
                    vd.ProdutoId = request.ProdutoId;
                    vd.Quantidade = request.Quantidade;
                    vd.VendaContatoId = request.VendaContatoId;
                    vd.Valor = request.Valor;

                    business.Cadastrar(vd);


                    response.Mensagem = $"Venda {request.VendaContatoId}, cadastrado com sucesso.";
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
                    VendaDetalheContato v = business.ConsultaPorId(id);
                    business.Excluir(v);

                    response.Mensagem = $"Venda {v.VendaDetalheContatoid}, excluido com sucesso.";
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