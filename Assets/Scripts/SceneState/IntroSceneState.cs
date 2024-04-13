using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class IntroSceneState : ISceneState
{
	public override void OnEnterState()
	{
		base.OnEnterState();

		TimelineManager.Instance.PlayIntroTimeline(OnTimelineEnded);
	}

	private void OnTimelineEnded(PlayableDirector playableDirector)
	{
		SceneStateManager.Instance.RequestNextState();
	}
}
