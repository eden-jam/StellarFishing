using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
	#region Fields
	[SerializeField] private AudioSource _soundDesignSource = null;
	[SerializeField] private MultiAudioClip _fishingRodBad = null;
	[SerializeField] private MultiAudioClip _fishingRodGood = null;
	#endregion Fields

	private void Start()
	{
		DontDestroyOnLoad(this);
	}

	private void PlaySound(AudioClip clip)
	{
		_soundDesignSource.clip = clip;
		_soundDesignSource.Play();
	}
}
