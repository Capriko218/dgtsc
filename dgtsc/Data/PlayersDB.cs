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
	public class PlayersDB
	{

		public static PlayerItem GetSingleById(int playerId)
		{
			try
			{
				using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString))
				{
					cn.Open();

					var p = new DynamicParameters();
					p.Add("@playerId", playerId);

					var sql = @"SELECT Players.PlayerId, Players.GameId, PlayerName, Players.PartnerPlayerId, p2.PlayerName AS PartnerName
								FROM Players
									LEFT OUTER JOIN Players p2 ON p2.PlayerId = Players.PartnerPlayerId
								WHERE Players.PlayerId=@playerId;";


					var res = cn.Query(sql, p);

					return res.Select(x => new PlayerItem
					{
						Id = x.PlayerId,
						GameId = x.GameId,
						Name = x.PlayerName,
						PartnerId = x.PartnerPlayerId,
						PartnerName = x.PartnerName
					}).FirstOrDefault();

				}
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public static List<PlayerItem> GetPlayersByGame(int gameId)
		{
			try
			{
				using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString))
				{
					cn.Open();

					var p = new DynamicParameters();
					p.Add("@gameId", gameId);

					var sql = @"SELECT Players.PlayerId, Players.GameId, PlayerName, Players.PartnerPlayerId, p2.PlayerName AS PartnerName
								FROM Players
									LEFT OUTER JOIN Players p2 ON p2.PlayerId = Players.PartnerPlayerId
								WHERE Players.GameId=@gameId
								ORDER BY PlayerName;";


					var res = cn.Query(sql, p);

					return res.Select(x => new PlayerItem
					{
						Id = x.PlayerId,
						GameId = x.GameId,
						Name = x.PlayerName,
						PartnerId = x.PartnerPlayerId,
						PartnerName = x.PartnerName
					}).ToList();

				}
			}
			catch (Exception ex)
			{
				return new List<PlayerItem>();
			}
		}
	}
}