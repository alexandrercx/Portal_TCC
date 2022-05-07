using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using ServicoAssociadoWeb.Enums;
using ServicoAssociadoWeb.Integrations.Api;
using ServicoAssociadoWeb.Integrations.Client;
using ServicoAssociadoWeb.Integrations.Models.APIServicosAssociado;
using ServicoAssociadoWeb.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServicoAssociadoWeb.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly IConfiguration _IConfiguration;
        private readonly IAgendamentoApi _AgendamentoApi;

        public AgendamentoController(IConfiguration IConfiguration, IAgendamentoApi IAgendamentoApi)
        {
            _IConfiguration = IConfiguration;
            _AgendamentoApi = IAgendamentoApi;

        }

        // GET: AgendamentoController
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var list = _AgendamentoApi.ApiAgendamentoGet(
                    token: _IConfiguration.GetSection("Settings:ApiAgendamento:ApiKey").Value,
                    idAssociado: int.Parse(User.Claims.First(x => x.Type.Equals(ClaimTypes.NameIdentifier.ToString(), StringComparison.OrdinalIgnoreCase))?.Value)
                ); ;
                return View(list);
            }
            else
                return RedirectToAction("Login", "Associado");
        }

        // GET: AgendamentoController/Details/5
        public ActionResult Details(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var item = _AgendamentoApi.ApiAgendamentoIdGet(
                   token: _IConfiguration.GetSection("Settings:ApiAgendamento:ApiKey").Value,
                   id: id);
                return View(item);
            }
            else
                return RedirectToAction("Login", "Associado");
        }

        // GET: AgendamentoController/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.ListTipoAtendimento = GetTiposAtendimento().Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();
                return View();
            }
            else
                return RedirectToAction("Login", "Associado");
        }

        // POST: AgendamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ViewBag.ListTipoAtendimento = GetTiposAtendimento().Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();

                if (ModelState.IsValid)
                {
                    var body = new RequestAgendamentoViewModel()
                    {
                        TipoAtendimentoId = int.Parse(collection["TipoAtendimentoId"]),
                        AssociadoId = long.Parse(User.Claims.First(x => x.Type.Equals(ClaimTypes.NameIdentifier.ToString(), StringComparison.OrdinalIgnoreCase))?.Value),
                        ConveniadoId = int.Parse(collection["ConveniadoId"]),
                        EnderecoId = int.Parse(collection["EnderecoId"]),
                        DataAtendimento = DateTime.Parse(collection["DataAtendimento"])
                    };

                    var response = _AgendamentoApi.ApiAgendamentoPost(
                        token: _IConfiguration.GetSection("Settings:ApiAgendamento:ApiKey").Value,
                        body: body
                    );

                    //return RedirectToAction(nameof(Index));
                    if (response.Id > 0)
                        ViewBag.Alert = CommonServices.ShowAlert(Alerts.Success, $"Agendamento {response.Id} realizado com sucesso.");
                    else if (response.Relatorio.CodigoHttp == 207)
                    {
                        string mensagem = null;
                        foreach (var item in response.Relatorio.Detalhes)
                        { 
                            mensagem = $"<li>{item.Mensagem}</li>";
                        }
                        ViewBag.Alert = CommonServices.ShowAlert(Alerts.Warning, $"Erro na criação do agendamento: <br><ul>{mensagem}</ul>");
                    }
                    else
                        ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Erro na criação do agendamento.");
                }
                return PartialView("Create");
            }
            catch (ApiException ex)
            {
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Erro na criação do agendamento.");
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Erro na criação do agendamento.");
                return View();
            }
        }

        private List<ResponseTipoAtendimentoViewModel> GetTiposAtendimento()
        {
            return new List<ResponseTipoAtendimentoViewModel>()
            {
                new ResponseTipoAtendimentoViewModel(){ Id = 1, Nome ="Consulta Presencial"},
                new ResponseTipoAtendimentoViewModel(){ Id = 2, Nome ="Telemedicina"},
                new ResponseTipoAtendimentoViewModel(){ Id = 3, Nome ="Exame"}
            };
        }

        // GET: AgendamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
                return RedirectToAction("Login", "Associado");
        }

        // POST: AgendamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgendamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
                return RedirectToAction("Login", "Associado");
        }

        // POST: AgendamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
;