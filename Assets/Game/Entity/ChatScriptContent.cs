using System;
using System.Collections.Generic;

using UInt8 = System.Byte;
using System.Text;

interface ChatContentInterface
{
	string Print();
}

//class ChatContent_Item : ChatContentInterface
//{
//    public string Print()
//    {
//        return HtmlUtilSGTY.HtmlHref(FuncNameUtil.FUNC_ItemLink, new string[] { ChatChannel.ToString(), ID.ToString(), ItemTemplate.ToString() }, Color, ItemName, true).ToString();
//    }

//    public ChatChannelType Channel;
//    public UInt64 ID;
//    public string ItemName;
//    public UInt32 ItemTemplate;
//    public string Color;

//    public UInt8 ChatChannel { get { return (UInt8)Channel; } }
//}

public class ChatScriptContentList
{
	public PlayerIdentificationProperty Identification { get { return _identification; } }

	public void Begin(PlayerIdentificationProperty identification)
	{
		_identification = identification;
	}

	public void ShowItem(ChatChannelType channel, UInt32 item, UInt64 ID)
	{
		//ItemStruct itemStruct = ViSealedDB<ItemStruct>.GetData(item);
		//if (itemStruct != null)
		//{
		//    ChatContent_Item link = new ChatContent_Item();
		//    link.Channel = channel;
		//    link.ItemTemplate = item;
		//    link.ID = ID;
		//    link.ItemName = itemStruct.Name;
		//    link.Color = ItemQualityManager.GetItemColorString((int)itemStruct.InitQuality.Value);
		//    _contentList.Enqueue(link);
		//}
	}

	public string End(string script)
	{
		if (string.IsNullOrEmpty(script))
		{
			return string.Empty;
		}
		string[] splitedText = script.Split('&');
		StringBuilder builder = new StringBuilder();
		for (int iter = 0; iter < splitedText.Length; ++iter)
		{
			if (iter == 0)
			{
				builder.Append(splitedText[iter]);
				continue;
			}
			if (_contentList.Count > 0)
			{
				ChatContentInterface itemLink = _contentList.Dequeue();
				builder.Append(itemLink.Print());
			}
			builder.Append(splitedText[iter]);
		}
		_contentList.Clear();
		return builder.ToString();
	}

	PlayerIdentificationProperty _identification;
	Queue<ChatContentInterface> _contentList = new Queue<ChatContentInterface>();
}
