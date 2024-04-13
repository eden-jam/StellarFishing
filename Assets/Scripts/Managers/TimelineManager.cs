using System;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : Singleton<TimelineManager>
{
	[SerializeField] private PlayableDirector _introTimeline = null;
	[SerializeField] private PlayableDirector _outroTimeline = null;
	[SerializeField] private PlayableDirector _gameTimeline = null;

	public void PlayIntroTimeline(Action<PlayableDirector> onDone)
	{
		if (_introTimeline == null)
		{
			onDone?.Invoke(null);
		}
		_introTimeline.played += onDone;
		_introTimeline.Play();
	}

	public void PlayOutroTimeline(Action<PlayableDirector> onDone)
	{
		if (_outroTimeline == null)
		{
			onDone?.Invoke(null);
		}
		_outroTimeline.played += onDone;
		_outroTimeline.Play();
	}

	public void PlayGameTimeline(Action<PlayableDirector> onDone)
	{
		if (_gameTimeline == null)
		{
			onDone?.Invoke(null);
		}
		_gameTimeline.played += onDone;
		_gameTimeline.Play();
	}
}
