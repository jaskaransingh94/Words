using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WordsAndSynonyms.Models;


namespace WordsAndSynonyms.Provider
{
	public class Crud :DbContext
	{
		public void updateWords(word w)
		{
			Db.context.words.Add(w);

			//if (w.wordId != -1)
			//{
			//	Db.context.Entry(w).State = EntityState.Modified;
			//}

			Db.context.SaveChanges();
		}

		public List<string> getWord(string word)
		{
			var words = Db.context.words.Where(a => a.word1.StartsWith(word));

			if (words.Count() > 0)
			{
				return words.Select(a=>a.word1).ToList();
			}

			return null;
		}
	}
}