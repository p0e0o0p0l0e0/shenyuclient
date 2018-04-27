using System;
using System.Collections.Generic;

public class SpaceFactionHeroWatcher : ViReceiveDataDictionaryNodeWatcher<UInt64, ReceiveDataSpaceFactionHeroMemberProperty>
{
	public ViVector3 Position
	{
		get
		{
			if (!ViEntityAssisstant.IsNullOrEmpty(_entity))
			{
				return _entity.Position;
			}
			else
			{
				return Property.Position;
			}
		}
	}

	public override void OnStart(UInt64 key, ReceiveDataSpaceFactionHeroMemberProperty property, ViEntity entity)
	{
		_entity = Client.Current.EntityManager.GetEntity<CellHero>(key);
		Client.Current.EntityManager.AttachEventNode(_entityEventNode, key, this.OnEntityEvent);
	}

	public override void OnUpdate(UInt64 key, ReceiveDataSpaceFactionHeroMemberProperty property, ViEntity entity)
	{
	}
	//
	public override void OnEnd(UInt64 key, ReceiveDataSpaceFactionHeroMemberProperty property, ViEntity entity)
	{
		_entity = null;
		_entityEventNode.End();
		////ViewControllerManager.FightSpaceEntityController.DestroyEntity(key);
	}

	CellHero _entity;
	ViEntityManager.EventNode _entityEventNode = new ViEntityManager.EventNode();
	void OnEntityEvent(ViEntityManager.Event eventID, ViEntity entity)
	{
		switch (eventID)
		{
			case ViEntityManager.Event.CREATE:
				_entity = entity as CellHero;
				break;
			case ViEntityManager.Event.DESTROY:
				_entity = null;
				break;
			default:
				break;
		}
	}
}
