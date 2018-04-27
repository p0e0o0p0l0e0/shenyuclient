using System;


public class ViOffSetVector3Provider : ViProvider<ViVector3>
{
	public override ViVector3 Value
	{
		get
		{
			if (_targetProvider != null)
			{
				return _targetProvider.Value + _offset;
			}
			else
			{
				return _offset;
			}
		}
	}
	public ViOffSetVector3Provider()
	{

	}
	public ViOffSetVector3Provider(ViProvider<ViVector3> provider, ViVector3 offset)
	{
		_targetProvider = provider;
		_offset = offset;
	}
	public void SetValue(ViProvider<ViVector3> provider, ViVector3 offset)
	{
		_targetProvider = provider;
		_offset = offset;
	}
	public void SetOffset(ViVector3 value)
	{
		_offset = value;
	}
	ViVector3 _offset;
	ViProvider<ViVector3> _targetProvider;
}