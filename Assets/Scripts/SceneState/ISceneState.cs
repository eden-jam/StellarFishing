using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISceneState
{
	public virtual void OnEnterState()
	{
	}

	public virtual void OnExitState()
	{
	}

	public virtual void Update()
	{
		if (InputManager.Instance.WasPressedThisFrame())
		{
			SceneStateManager.Instance.RequestNextState();
		}
	}
}
