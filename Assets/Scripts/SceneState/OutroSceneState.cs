using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OutroSceneState : ISceneState
{
	public override void OnEnterState()
	{
		base.OnEnterState();

		TimelineManager.Instance.PlayOutroTimeline(OnTimelineEnded);
	}

	private void OnTimelineEnded(PlayableDirector playableDirector)
	{
		SceneStateManager.Instance.RequestNextState();
	}
}

