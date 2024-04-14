using UnityEngine;

public sealed class PropSoundAudioSource : MonoBehaviour
{
	[SerializeField] private AudioSource _audioSource = null;
	private bool _isActive = false;

	public void Play(AudioClip clip)
	{
		_audioSource.clip = clip;
		_audioSource.Play();

		_isActive = true;
	}

	public void Update()
	{
		if (_isActive && _audioSource.isPlaying == false)
		{
			_isActive = false;
			AudioManager.Instance.ReturnToPool(this);
		}
	}
}
