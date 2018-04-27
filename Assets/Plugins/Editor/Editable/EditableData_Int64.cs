using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class EditableDataInt64 : EditableDataElement
{
	public Int64 Value { get { return _value; } set { _value = value; } }
	public override bool SetValue(string data)
	{
		Int64 value;
		if (Int64.TryParse(data, out value))
		{
			_value = value;
			return true;
		}
		else
		{
			return false;
		}
	}

	public override void Read(ViStringIStream IS, object obj)
	{
		string value;
		if (IS.Read(out value))
		{
			SetValue(value);
			if (Field != null)
            {
                //Field.SetValue(obj, _value);
            }
		}
	}
	public override void AppendTo(ViOStream OS)
	{
		Save();
		OS.Append(_value);
	}
	public override void AppendTo(TextWriter OS)
	{
		Save();
		if (DataEditor.IS_START)
		{
            DataEditor.IS_START = false;
			OS.Write(_value);
		}
		else
		{
			OS.Write("\t" + _value);
		}
	}
	Int64 _value;
}
