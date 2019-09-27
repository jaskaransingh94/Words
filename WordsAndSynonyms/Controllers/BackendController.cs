using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordsAndSynonyms.Models;
using WordsAndSynonyms.Provider;

namespace WordsAndSynonyms.Controllers
{
	public class BackendController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public JsonResult loadDb()
		{
			String path = HttpContext.Server.MapPath("/Dependencies/files/words_dictionary.json");

			try
			{

				using (StreamReader r = new StreamReader(path))
				{
					string file = r.ReadToEnd().Replace("\n", "");
					string[] words = file.Split(',');
					using (var crud = new Crud())
					{
						word newWord;
						foreach (var text in words)
						{
							if (text.StartsWith("x"))
							{
								newWord = new word()
								{
									updatedTime = DateTime.Now,
									word1 = text
								};
								crud.updateWords(newWord);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				return Json( new
				{
					success = false,
				}, JsonRequestBehavior.AllowGet);
			}

			return Json(new
			{
				success = true,
			}, JsonRequestBehavior.AllowGet);

		}

	}
}