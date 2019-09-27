using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordsAndSynonyms.Models;

namespace WordsAndSynonyms.Provider
{
	public static class Db
	{
		public static WordsEntities context = new WordsEntities();
	}
}