﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class QuackTwitter
	{
		public enum Favorites
		{
			List,
			Destroy,
			Create
		};

		public dynamic REST(Favorites type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Favorites.List:
					return Get(Constants.FavoritesURL + "list.json", parameters);
				case Favorites.Destroy:
					if (parameters.ContainsKey("id"))
					{
						return Post(Constants.FavoritesURL + "destroy.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Favorites.Create:
					if (parameters.ContainsKey("id"))
					{
						return Post(Constants.FavoritesURL + "create.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				default:
					throw new Exception();
			}
		}
	}
}
