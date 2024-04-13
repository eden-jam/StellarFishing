using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneState : ISceneState
{
	public override void OnEnterState()
	{
		FishingManager.Instance.LaunchFishing();
	}

	public override void Update()
	{
	}
}

