using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ReadySceneState : ISceneState
{
	public override void Update()
	{
		if (InputManager.Instance.WasPressedThisFrame())
		{
			SceneStateManager.Instance.RequestNextState();
		}
	}

	public override void OnExitState()
	{
		base.OnExitState();
		PlayerBoatAnimation.Instance.PlayLaunch();
	}
}