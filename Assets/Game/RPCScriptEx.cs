using System;
using System.Collections.Generic;
using UnityEngine;

using UInt8 = System.Byte;

public static class RPCScriptEx
{
	public static void OnExec(string script, ViIStream stream)
	{
		ViDebuger.CritOK("RPCScriptEx.OnExec(" + script + ")");
		//
		switch (script)
		{
			case "OnSealedDataUpdate0":
				{
					string name;
					ViIStream IS;
					stream.Read(out name);
					stream.Read(out IS);
					//GameApplication.Instance.DataManager.UpdateSealedData(name, IS);
				}
				break;
			case "OnSealedDataUpdate1":
				{
					string name;
					ViIStream IS;
					stream.Read(out name);
					stream.Read(out IS);
					//GameApplication.Instance.DataManager.UpdateSealedData(name, IS);
				}
				break;
			case "PrintProperty.Account":
				{
					AccountProperty property = new AccountProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.Player":
				{
					PlayerProperty property = new PlayerProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.PlayerMailbox":
				{
					PlayerMailboxProperty property = new PlayerMailboxProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.PlayerGuild":
				{
					PlayerGuildProperty property = new PlayerGuildProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.PlayerOfflineBox":
				{
					PlayerOfflineBoxProperty property = new PlayerOfflineBoxProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.PlayerTrader":
				{
					PlayerTraderProperty property = new PlayerTraderProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.PlayerFriendList":
				{
					PlayerFriendListProperty property = new PlayerFriendListProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.Guild":
				{
					GuildProperty property = new GuildProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.GameRecord":
				{
					GameRecordProperty property = new GameRecordProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.TradeManager":
				{
					TradeManagerProperty property = new TradeManagerProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.PublicSpaceManager":
				{
					PublicSpaceManagerProperty property = new PublicSpaceManagerProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.PublicSpaceEnter":
				{
					PublicSpaceEnterProperty property = new PublicSpaceEnterProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.Party":
				{
					PartyProperty property = new PartyProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.SpaceMatchEnterGroup":
				{
					SpaceMatchEnterGroupProperty property = new SpaceMatchEnterGroupProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.SpaceMatchManager":
				{
					SpaceMatchManagerProperty property = new SpaceMatchManagerProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.CellRecord":
				{
					CellRecordProperty property = new CellRecordProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.CellPlayer":
				{
					CellPlayerProperty property = new CellPlayerProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.CellHero":
				{
					CellHeroProperty property = new CellHeroProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.CellNPC":
				{
					CellNPCProperty property = new CellNPCProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.GameSpaceRecord":
				{
					GameSpaceRecordProperty property = new GameSpaceRecordProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.GameSpaceFactionRecord":
				{
					GameSpaceFactionRecordProperty property = new GameSpaceFactionRecordProperty();
					property.Read(stream);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					property.Print(string.Empty, strStream);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.PlayerGMViewProperty":
				{
					PlayerGMViewProperty property = new PlayerGMViewProperty();
					PlayerGMViewPropertySerializer.Read(stream, out property);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					ViGameSerializer<PlayerGMViewProperty>.Append(strStream, string.Empty, property);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "PrintProperty.AccountWithPlayerProperty":
				{
					AccountWithPlayerProperty property = new AccountWithPlayerProperty();
					AccountWithPlayerPropertySerializer.Read(stream, out property);
					ViStringDictionaryStream strStream = new ViStringDictionaryStream();
					ViGameSerializer<AccountWithPlayerProperty>.Append(strStream, string.Empty, property);
					//ViewControllerManager.PrintMSGView.SetMessage(strStream.Print(": ", "\n"));
				}
				break;
			case "ReConnectTo":
				{
					string loginContent;
					stream.Read(out loginContent);
					Client.Current.CloseConnect();
					Client.Current.LoginEx(loginContent);
				}
				break;
			case "LoginProgress":
				{
					Int32 waitIdx;
					stream.Read(out waitIdx);
					string content = "排队中...还需等待" + waitIdx.ToString() + "人";
					ViDebuger.CritOK(content);
					////ViewControllerManager.QueueUpController.UpdateQueueUpMessage(content);
					//
					if (Client.Current.Net != null)
					{
						UInt8 emptyLicence = 0;
						UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
						UInt16 funcID = (UInt16)ViRPCMessage.PING;
						Client.Current.Net.ResetSendStream();
						Client.Current.Net.OS.Append(emptyLicence);
						Client.Current.Net.OS.Append(receiverSide);
						Client.Current.Net.OS.Append(funcID);
						Client.Current.Net.OS.Append((Int64)(Time.realtimeSinceStartup * 1000));
						Client.Current.Net.OS.Append((Int64)0);
						Client.Current.Net.SendStream();
					}
				}
				break;
		}
	}
}