using System;
using System.Collections.Generic;
//
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;

public static class PlayerMailboxPropertyAssisstant
{

	public static PlayerMailboxReceiveProperty DefaultProperty { get { return _property; } }
	public static void SetProperty(PlayerMailboxReceiveProperty property)
	{
		_property = property;
	}
	static PlayerMailboxReceiveProperty _property;

	//+---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	public static bool HasUnreadMail(PlayerMailboxReceiveProperty entityProperty)
	{
		for (int iter = 0; iter < entityProperty.MailList.Count; ++iter)
		{
			ReceiveDataMailProperty mailProperty = entityProperty.MailList[iter].Property;
			if (mailProperty.State.Value == (UInt8)MailState.UN_READED)
			{
				return true;
			}
		}
		return false;
	}

	public static bool HasAttachmentMail(PlayerMailboxReceiveProperty entityProperty)
	{
		for (int iter = 0; iter < entityProperty.MailList.Count; ++iter)
		{
			ReceiveDataMailProperty mailProperty = entityProperty.MailList[iter].Property;
			if (IsAttachmentMail(mailProperty) && mailProperty.AttachmentReceiveTime1970 == 0)
			{
				return true;
			}
		}
		return false;
	}


	public static bool IsAttachmentMail(MailProperty mail)
	{
		if (mail.AttachmentXP > 0)
		{
			return true;
		}
		if (mail.AttachmentYinPiao > 0)
		{
			return true;
		}
		if (mail.AttachmentJinPiao > 0)
		{
			return true;
		}
		if (mail.AttachmentJinZi > 0)
		{
			return true;
		}
		for (Int32 idx = 0; idx < mail.AttachmentScores.GetLength(); ++idx)
		{
			if (mail.AttachmentScores[idx].Info != 0)
			{
				return true;
			}
		}
		for (Int32 idx = 0; idx < mail.AttachmentItems.GetLength(); ++idx)
		{
			if (mail.AttachmentItems[idx].Info != 0)
			{
				return true;
			}
		}
		if (!mail.AttachmentItem.Empty)
		{
			return true;
		}
		return false;
	}

	public static Int64 GetReserveTime(MailProperty property)
	{
		if (property.Type == GameMailTypeInstance.GM.ID)
		{
			bool hasAttach = IsAttachmentMail(property);
			if ((property.State == (UInt8)MailState.READED && !hasAttach)
				|| (hasAttach && property.AttachmentReceiveTime1970 != 0))
			{
				return property.Time1970 + 3 * ViTickCount.DAY - ViTimerInstance.Time1970;
			}
		}
		//
		return property.Time1970 + 30 * ViTickCount.DAY - ViTimerInstance.Time1970;
	}

}