using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class NarrationManager : MonoBehaviour
{
	[SerializeField] private int _startSceneIndex = -1;
	[SerializeField] private int _endSceneIndex = 8;

	[SerializeField] private GameObject _animationPbject = null;
	[SerializeField] private Animator _animation = null;
	[SerializeField] private AudioSource _audioSource = null;
	[SerializeField] private SubtitlePlayer _subtitlePlayer = null;
	private void Start()
	{
		AudioManager.Instance.MuteMusic();
		Narration narration = GameManager.Instance.NarrationCatalog.FindNarration(GameManager.Instance.LastMapSelected);
		if (narration == null)
		{
			GameManager.Instance.OnSceneEnd();
			return;
		}

		_subtitlePlayer.Play(narration.Subtitles, narration.SubtitlesSpeed);

		_audioSource.clip = narration.AudioClip;
		_audioSource.Play();
		_animationPbject.SetActive(false);
		StartCoroutine(HideAfterDelay(narration.AudioClip.length));
		//if (GameManager.Instance.LastMapSelected == _startSceneIndex)
		//{
		//	_animationPbject.SetActive(true);
		//	_animation.Play("Start");
		//}
		//else if (GameManager.Instance.LastMapSelected == _endSceneIndex)
		//{
		//	_animationPbject.SetActive(true);
		//	_animation.Play("End");
		//}
	}

	private IEnumerator HideAfterDelay(double delay)
	{
		yield return new WaitForSeconds((float)delay);

		GameManager.Instance.OnNarrationEnded();
		AudioManager.Instance.UnmuteMusic();
	}

}
