using UnityEngine;
using UnityEngine.Playables;

public class EndScene : MonoBehaviour
{
	[SerializeField] private PlayableDirector _playableDirector = null;

	private void Start()
	{
		_playableDirector.stopped += OnStopped;
	}

	private void OnStopped(PlayableDirector director)
	{
		GameManager.Instance.Restart();
	}
}
