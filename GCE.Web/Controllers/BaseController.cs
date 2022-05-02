using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpCardapio.Domain;

namespace GCE.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private GceContext _db;

        protected GceContext db
        {
            get
            {
                if (_db == null)
                {
                    _db = new GceContext();
                }

                return _db;
            }
        }

        public virtual ActionResult _HeaderModal(int? id)
        {
            return PartialView(id);
        }

        protected override void Dispose(bool disposing)
        {
            db?.Dispose();

            base.Dispose(disposing);
        }

        internal void Notify(NotifyStatus status, string message, bool timeout = true)
        {
            TempData["notify-status"] = status.ToString();
            TempData["notify-message"] = message;

            if (!timeout)
            {
                TempData["notify-infinite"] = "infinite";
            }
        }
    }
}