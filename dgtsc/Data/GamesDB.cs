using Dapper;
using dgtsc.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace dgtsc.Data
{
	public class GamesDB
	{
		public static GameItem GetSingleGame(int id)
		{
			try
			{
				using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["dgtscsql"].ConnectionString))
				{
					cn.Open();

					var p = new DynamicParameters();
					p.Add("@gameId", id);

					var sql = @"SELECT Games.GameId, GameName, Games.LocationId, LocationName, LocationStreet1,
									LocationStreet2, LocationCity, LocationRegion, LocationCountry, LocationPostal,
									JoinCode, Games.OwnerAccountId, AccountFirst, AccountLast, GameDateTime,
									GameRound
								FROM Games
									INNER JOIN Locations ON Locations.LocationId=Games.GameId
									LEFT OUTER JOIN Accounts ON Accounts.AccountId=Games.OwnerAccountId
								WHERE Games.GameId=@GameId;";

					var res = cn.Query(sql, p);

					return res.Select(x => new GameItem
					{
						Id = x.GameId,
						Name = x.GameName,
						Round = x.GameRound,
						GameDateTime = x.GameDateTime,
						LocationId = x.LocationId,
						LocationName = x.LocationName,
						LocationStreet1 = x.LocationStreet1,
						LocationStreet2 = x.LocationStreet2,
						LocationCity = x.LocationCity,
						LocationRegion = x.LocationRegion,
						LocationCountry = x.LocationCountry,
						JoinCode = x.JoinCode,
						OwnerAccountId = x.OwnerAccountId,
						OwnerFirstName = x.AccountFirst,
						OwnerLastName = x.AccountLast
					}).FirstOrDefault();

				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static int AddPlayer(int gameId, string playerName)
		{
			try
			{
				using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["dgtscsql"].ConnectionString))
				{
					cn.Open();

					var p = new DynamicParameters();
					p.Add("@gameId", gameId);
					p.Add("@playerName", playerName);

					var sql = @"INSERT INTO Players(GameId, PlayerName) VALUES (@GameId, @PlayerName);";

					var res = cn.Execute(sql, p);

					return res;
				}
			}
			catch (Exception)
			{
				return 0;
			}
		}
	}
}