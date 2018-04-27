using System;

public class GMCommandAliasStruct : ViSealedData
{
	public struct ParamStruct
	{
		public string Value;
	}

	public string Func;
	public ViStaticArray<ParamStruct> Param = new ViStaticArray<ParamStruct>(3);
}
