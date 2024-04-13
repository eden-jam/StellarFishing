using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateManager : Singleton<SceneStateManager>
{
	public enum SceneState
	{
		Starting,
		ReadyToPress,
		StartFishing,
		Fishing,
		EndFishing,
		Ending
	}

	public void ChangeState(SceneState sceneState)
	{
		switch (sceneState)
		{
			case SceneState.Starting:
				{

				}
				break;
			case SceneState.ReadyToPress:
				{

				}
				break;
			case SceneState.StartFishing:
				{

				}
				break;
			case SceneState.Fishing:
				{

				}
				break;
			case SceneState.EndFishing:
				{

				}
				break;
			case SceneState.Ending:
				{

				}
				break;
			default:
				break;
		}
	}

}
