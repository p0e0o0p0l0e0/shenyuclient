using System;

public class ViSpaceExpress : ViExpressInterface
{
	public ViProvider<ViVector3> PosProvider { get { return _posProvider; } }

	protected ViProvider<ViVector3> _posProvider;
}