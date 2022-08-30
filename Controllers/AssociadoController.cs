using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ServicoAssociadoWeb.Enums;
using ServicoAssociadoWeb.Integrations.Api;
using ServicoAssociadoWeb.Integrations.Models.APIServicosAssociado;
using ServicoAssociadoWeb.Models;
using ServicoAssociadoWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServicoAssociadoWeb.Controllers
{
   public class AssociadoController : Controller
   {
      private readonly IConfiguration _IConfiguration;
      //private readonly IAssociadoApi _IAssociadoApi;
      private readonly IGatewayApi _IGatewayApi;

      public AssociadoController(IConfiguration configuration, IAssociadoApi associadoApi, IGatewayApi gatewayApi)
      {
         _IConfiguration = configuration;
         //_IAssociadoApi = associadoApi;
         _IGatewayApi = gatewayApi;
      }

      private List<ResponsePlanoViewModel> GetPlanos()
      {
         return new List<ResponsePlanoViewModel>()
            {
                new ResponsePlanoViewModel(){ Id = 1, Nome ="Saúde - Básico", ValorBase = 50},
                new ResponsePlanoViewModel(){ Id = 2, Nome ="Saúde - Intermediário", ValorBase = 100},
                new ResponsePlanoViewModel(){ Id = 2, Nome ="Saúde - VIP", ValorBase = 200}
            };
      }


      private List<IdNome2ViewModel> GetTiposConta()
      {
         return new List<IdNome2ViewModel>()
            {
                new IdNome2ViewModel(){ Id = "CC", Nome ="Corrente"},
                new IdNome2ViewModel(){ Id = "PG", Nome ="Pagamento"},
                new IdNome2ViewModel(){ Id = "PP", Nome ="Poupança"}
            };
      }

      private List<IdNomeViewModel> GetTiposEndereco()
      {
         return new List<IdNomeViewModel>()
            {
                new IdNomeViewModel(){ Id = 1, Nome ="Comercial"},
                new IdNomeViewModel(){ Id = 2, Nome ="Residencial"}
            };
      }

      private List<IdNomeViewModel> GetTiposTelefone()
      {
         return new List<IdNomeViewModel>()
            {
                new IdNomeViewModel(){ Id = 1, Nome ="Celular"},
                new IdNomeViewModel(){ Id = 2, Nome ="Comercial"},
                new IdNomeViewModel(){ Id = 3, Nome ="Residencial"}
            };
      }

      public IActionResult Register()
      {
         if (User.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Agendamento");
         else
         {
            ViewBag.ListPlanos = GetPlanos().Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();
            ViewBag.ListTipoConta = GetTiposConta().Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();
            ViewBag.ListTipoEndereco = GetTiposEndereco().Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();
            ViewBag.ListTipoTelefone = GetTiposTelefone().Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();
            return View();
         }
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public IActionResult Register(AssociadoViewModel model)
      {
         try
         {
            ViewBag.ListPlanos = GetPlanos().Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();
            ViewBag.ListTipoConta = GetTiposConta().Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();
            ViewBag.ListTipoEndereco = GetTiposEndereco().Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();
            ViewBag.ListTipoTelefone = GetTiposTelefone().Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();

            var associado = _IGatewayApi.ApiAssociadoGet(model.Email);

            if ((associado?.Id ?? 0) > 0)
            {
               ViewBag.Alert = CommonServices.ShowAlert(Alerts.Warning, "E-mail já cadastrado.");
               return PartialView("Register", model);
            }
            else
            {
               var request = new Integrations.Models.APIAssociado.PostAssociadoViewModel()
               {
                  Cns = model.CNS,

                  Cpf = model.CPF,
                  DataNascimento = model.DataNascimento,
                  Email = model.Email,
                  Nome = model.Nome,
                  NomeMae = model.NomeMae,
                  PisPasep = model.PisPasep,
                  Senha = model.Senha,
                  PlanoId = model.PlanoId,
                  Ativo = "S"
               };

               request.Enderecos.Add(
                   new Integrations.Models.APIAssociado.PostEnderecoViewModel()
                   {
                      Bairro = model.Bairro,
                      Cep = model.CEP,
                      Cidade = model.Cidade,
                      Complemento = model.Complemento,
                      Logradouro = model.Logradouro,
                      Numero = model.Numero,
                      Pais = model.Pais,
                      TipoEndereco = model.TipoEndereco,
                      Uf = model.UF
                   });

               request.Telefones.Add(
                   new Integrations.Models.APIAssociado.PostTelefoneViewModel()
                   {
                      Ddd = model.DDD,
                      Ddi = "+55",
                      Numero = model.NumeroTelefone,
                      TipoTelefone = model.TipoTelefone
                   });

               request.ContaBanco =
                   new Integrations.Models.APIAssociado.PostContaBancoViewModel()
                   {
                      Agencia = model.Agencia,
                      BancoId = model.BancoId,
                      Conta = model.Conta,
                      DigitoAgencia = model.DigitoAgencia,
                      DigitoConta = model.DigitoConta,
                      TipoConta = model.TipoConta
                   };

               var response = _IGatewayApi.ApiAssociadoPost(request);

               if (response.Id > 0)
               {
                  ViewBag.Alert = CommonServices.ShowAlert(Alerts.Success, $"Associado {response.Id} cadastrado com sucesso.");
                  return View("Register", new AssociadoViewModel());
               }
               else
               {
                  ViewBag.Alert = CommonServices.ShowAlert(Alerts.Warning, "Erro no cadastro de associado.");
                  return PartialView("Register", model);
               }


            }
         }
         catch (Exception ex)
         {
            ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Erro no cadastro de associado.");
            return View();
         }
      }

      public IActionResult Login()
      {
         if (User.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Agendamento");

         return View();
      }

      [HttpPost]
      public IActionResult Login(LoginViewModel model)
      {
         try
         {
            var associado = _IGatewayApi.ApiAssociadoGet(model.Email);

            if ((associado?.Id ?? 0) > 0 && associado.Senha == model.Password)
            {
               //HttpContext.Session.SetString("User", JsonConvert.SerializeObject(associado));
               List<Claim> direitoAcessos = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, associado.Id.ToString()),
                    new Claim(ClaimTypes.Name, associado.Nome),
                    new Claim(ClaimTypes.Email, associado.Email)
                };
               var identidade = new ClaimsIdentity(direitoAcessos, "Identity.Login");
               var usuarioPrincipal = new ClaimsPrincipal(new[] { identidade });
               HttpContext.SignInAsync(usuarioPrincipal, new AuthenticationProperties { IsPersistent = false, ExpiresUtc = DateTime.Now.AddMinutes(15) });

               return RedirectToAction("Index", "Agendamento");
            }

            return PartialView("Login", model);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message + ex.StackTrace);
            ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, ex.Message);
            return View();
         }

      }

      [HttpPost]
      public IActionResult Logout()
      {
         if (User.Identity.IsAuthenticated)
         {
            HttpContext.SignOutAsync();
         }

         return RedirectToAction("Login", "Associado");
      }
   }
}
