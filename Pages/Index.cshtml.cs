using System;
using System.Net;
using System.IO;

using System.Collections.Generic;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using VitrineApp_R.Data;
using Newtonsoft.Json.Linq;
using ConsoleApp2.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace VitrineApp_R.Pages
{
    public class IndexModel : PageModel
    {
        private const int tamanhoPagina = 12;

        private readonly ILogger<IndexModel> _logger;

        private VitrineApp_RContext _context;

        public int PaginaAtual { get; set; }

        public int QuantidadePaginas { get; set; }

        public IndexModel(ILogger<IndexModel> logger, VitrineApp_RContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Item> itens;

       
        public void OnGet([FromQuery] string termoBusca, 
                          [FromQuery] int? filtroPesquisa, 
                          [FromQuery] int? o,
                          [FromQuery(Name="p")] int? pagina = 1)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString("http://makeup-api.herokuapp.com/api/v1/products.json");
            var js = new DataContractJsonSerializer(typeof(List<Item>));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            itens = (List<Item>)js.ReadObject(ms);

            this.PaginaAtual = pagina.Value;

            var query = itens.AsQueryable();
           

            if (!string.IsNullOrEmpty(termoBusca))
            {
                if (filtroPesquisa.HasValue){
                    switch (filtroPesquisa.Value)
                    {
                        case 0:
                            for (int i = 0; i < itens.Count; i++)
                            {
                                //se o campo name no item for nulo, remover da lista
                                if (itens[i].name == null)
                                {
                                    itens.Remove(itens[i]);
                                }
                            }
                            //caso o usuário digite minúsculas, o sistema converte para letras maiusculas tanto a pesquisa, como o resultado
                            //pois é case sensitive
                            query = query.Where(p => p.name.ToUpper().Contains(termoBusca.ToUpper()));

                            break;
                        case 1:
                            for (int i = 0; i < itens.Count; i++)
                            {
                               
                                if (itens[i].brand == null)
                                {
                                    itens.Remove(itens[i]);
                                }
                            }
                            query = query.Where(p => p.brand.Contains(termoBusca));
                           
                            break;

                        case 2:
                            for (int i = 0; i < itens.Count; i++)
                            {
                                //se todos os itens de busca forem nulos -> remover da lista
                                if (itens[i].category == null || itens[i].category == "")
                                {
                                    itens.Remove(itens[i]);
                                }
                            }
                            query = query.Where(p => p.category.Contains(termoBusca));
                           
                            break;

                        case 3:
                            for (int i = 0; i < itens.Count; i++)
                            {                               
                                if (itens[i].price == null || itens[i].price == "") {
                                    itens.Remove(itens[i]);
                                }
                            }
                            query = query.Where(p => p.price.Contains(termoBusca));
                            break;

                        case 4:
                            for (int i = 0; i < itens.Count; i++)
                            {
                                
                                if (itens[i].tag_list.Count == 0)
                                {
                                    itens.Remove(itens[i]);
                                }
                            }
                            query = query.Where(p => p.tag_list.Contains(termoBusca));
                           
                            break;
                    }
                   
                }
               
               

            }//
            //se o campo para ordenação foi selecionado
            if (o.HasValue)
            {
                switch (o.Value)
                {
                    case 1:
                        
                        query = query.OrderBy(p => p.name.ToUpper());

                        break;

                    case 2:
                        query = query.OrderBy(p => p.price);

                        break;

                    case 3:
                        query = query.OrderByDescending(p => p.price);

                        break;
                }
            }
            /*
             
             PAGINAÇÃO
             
             */

            //criação de outra query para ñão interferir na query da consulta
            var queryCount = query;
            //quantidade de registros que irá servir para o número de páginas paginadas
            int qntdProdutos = queryCount.Count();
            this.QuantidadePaginas = Convert.ToInt32(Math.Ceiling(qntdProdutos * 1M / tamanhoPagina));
            //se a página atual for a 3ª, tem que SKIP (pular) 2
            query = query.Skip(tamanhoPagina * (this.PaginaAtual - 1)).Take(tamanhoPagina);
            
            itens = query.ToList();


        }

    }

}
