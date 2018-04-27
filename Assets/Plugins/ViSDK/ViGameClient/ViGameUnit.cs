using System;

using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;

public interface ViGameUnit : ViEntity, ViRPCEntity
{
	new ViEntityID ID { get; }
	new ViEntityTypeID Type { get; }
	new string Name { get; }
	new bool Active { get; }

	new void Enable(ViEntityID ID, UInt32 PackID, bool asLocal);
	new void PreStart();
	new void Start();
	new void AftStart();
	new void ClearCallback();
	new void PreEnd();
	new void End();
	new void AftEnd();
	new void Tick(float fDeltaTime);

	bool IsMatch(ViStateConditionStruct condition);
}