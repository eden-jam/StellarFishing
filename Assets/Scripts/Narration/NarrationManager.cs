using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class NarrationManager : MonoBehaviour
{
	[SerializeField] private int _startSceneIndex = -1;
	[SerializeField] private int _endSceneIndex = 8;

	[SerializeField] private VideoPlayer _videoPlayer = null;
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

		if (narration.AudioClip != null)
		{
			_audioSource.clip = narration.AudioClip;
			_audioSource.Play();
			StartCoroutine(HideAfterDelay(narration.AudioClip.length));
		}
		if (GameManager.Instance.LastMapSelected == _startSceneIndex)
		{
			_videoPlayer.clip = GameManager.Instance.NarrationCatalog.StartVideoClip;
			_videoPlayer.Play();
			//StartCoroutine(HideAfterDelay(GameManager.Instance.NarrationCatalog.StartVideoClip.length));
		}
		else if (GameManager.Instance.LastMapSelected == _endSceneIndex)
		{
			_videoPlayer.clip = GameManager.Instance.NarrationCatalog.EndVideoClip;
			_videoPlayer.Play();
		}
	}

	private IEnumerator HideAfterDelay(double delay)
	{
		yield return new WaitForSeconds((float)delay);

		GameManager.Instance.OnNarrationEnded();
		AudioManager.Instance.UnmuteMusic();
	}

}
