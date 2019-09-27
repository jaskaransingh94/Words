using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordsAndSynonyms.Provider;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace WordsAndSynonyms.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public JsonResult loadSuggestions(string word)
		{
			JObject jsonObject;
			List<object> bd = new List<object>();

			try
			{
				using (var crud = new Crud())
				{
					var suggestions = crud.getWord(word);
					jsonObject = new JObject();

					if (suggestions != null)
					{

						foreach (var item in suggestions)
						{

							jsonObject[item] = null;

						}
					}
				}
			}
			catch (Exception ex)
			{
				return Json(new
				{
					success = false,
				}, JsonRequestBehavior.AllowGet);
			}

			return Json(new
			{
				success = true,
				data = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject)
			}, JsonRequestBehavior.AllowGet);

		}
	}


}