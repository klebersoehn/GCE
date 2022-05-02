using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GCE.Domain.Models;
using UpCardapio.Domain;

namespace GCE.Web.Controllers
{
    public class PessoaController : BaseController
    {

        public ActionResult Index()
        {
            return View(db.Pessoas.ToList());
        }

        public ActionResult _Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.Situacao = Situacao.Elaboracao;

                db.Pessoas.Add(pessoa);
                db.SaveChanges();

                Notify(NotifyStatus.Success, "Registro Criado com Sucesso!!!");

                return PartialView("_Mensagem");
            }

            return PartialView(pessoa);
        }

        public ActionResult _Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == 0)
            {
                Notify(NotifyStatus.Warning, "Nenhum registro selecionado!!!");

                return PartialView("_Mensagem");
            }

            Pessoa pessoa = db.Pessoas.Find(id);

            if (pessoa == null)
            {
                return HttpNotFound();
            }

            return PartialView(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Edit(Pessoa pessoa)
        {
            if (pessoa.Situacao != Situacao.Elaboracao)
            {
                Notify(NotifyStatus.Warning, "Não é possível Modificar pessoa com situação Ativada ou Desativada!!!");

                return PartialView("_Mensagem");
            }

            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();

                Notify(NotifyStatus.Success, "Registro Alterado com Sucesso!!!");

                return RedirectToAction("_Edit", pessoa.Id);
            }
            return PartialView(pessoa);
        }

        public ActionResult _Ativar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == 0)
            {
                Notify(NotifyStatus.Warning, "Nenhum registro selecionado!!!");
                return PartialView("_Mensagem");
            }

            Pessoa pessoa = db.Pessoas.Find(id);

            if (pessoa == null)
            {
                return HttpNotFound();
            }

            if (pessoa.Situacao == Situacao.Ativo)
            {
                Notify(NotifyStatus.Warning, "O Registro já se encontra Ativado!!!");
                return PartialView("_Mensagem");
            }

            return PartialView(pessoa);
        }

        public ActionResult _AtivarConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);

            db.Entry(pessoa).State = EntityState.Modified;
            pessoa.Situacao = Situacao.Ativo;

            db.SaveChanges();

            Notify(NotifyStatus.Success, "Registro Ativado com Sucesso!!!");

            return PartialView("_Mensagem");
        }

        public ActionResult _Desativar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == 0)
            {
                Notify(NotifyStatus.Warning, "Nenhum registro selecionado!!!");
                return PartialView("_Mensagem");
            }

            Pessoa pessoa = db.Pessoas.Find(id);

            if (pessoa == null)
            {
                return HttpNotFound();
            }

            if (pessoa.Situacao == Situacao.Desativado)
            {
                Notify(NotifyStatus.Warning, "O Registro já se encontra Desativado!!!");
                return PartialView("_Mensagem");
            }

            return PartialView(pessoa);
        }

        public ActionResult _DesativarConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);

            db.Entry(pessoa).State = EntityState.Modified;
            pessoa.Situacao = Situacao.Desativado;

            db.SaveChanges();

            Notify(NotifyStatus.Success, "Registro Desativado com Sucesso!!!");

            return PartialView("_Mensagem");
        }

        public ActionResult _Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == 0)
            {
                Notify(NotifyStatus.Warning, "Nenhum registro selecionado!!!");

                return PartialView("_Mensagem");
            }

            Pessoa pessoa = db.Pessoas.Find(id);

            if (pessoa == null)
            {
                return HttpNotFound();
            }

            if (pessoa.Situacao == Situacao.Ativo)
            {
                Notify(NotifyStatus.Warning, "Não é possível remover pessoa com situação Ativada!!!");

                return PartialView("_Mensagem");
            }
            
            return PartialView(pessoa);
        }

        public ActionResult _DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            
            db.Pessoas.Remove(pessoa);
            db.SaveChanges();

            Notify(NotifyStatus.Success, "Registro Removido com Sucesso!!!");

            return PartialView("_Mensagem");
        }
    }
}
