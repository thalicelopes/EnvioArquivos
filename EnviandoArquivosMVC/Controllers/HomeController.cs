using EnviandoArquivosMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnviandoArquivosMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Remessa arq)
        {
            try
            {
                string nomeArquivo = "";
                if(arq.Arquivo.ContentLength > 0)
                {
                    nomeArquivo = Path.GetFileName(arq.Arquivo.FileName);
                    var caminho = Path.Combine(Server.MapPath("~/Imagens"), nomeArquivo);
                    arq.Arquivo.SaveAs(caminho);
                }
                ViewBag.Mensagem = "Arquivo :" + nomeArquivo + " , enviado com sucesso.";

            }catch(Exception ex)
            {
                ViewBag.Mensagem = "Erro: " + ex.Message;
            }
            return View();
        }
    }
}