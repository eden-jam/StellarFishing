using System;
using UnityEngine;
using UnityEngine.Pool;

public class AudioManager : Singleton<AudioManager>
{
	#region Fields
	[SerializeField] private PropSoundAudioSource _soundSourcePrefab = null;
	[SerializeField] private AudioSource _fishingRodSoundSource = null;
	[SerializeField] private AudioSource _music = null;

	[SerializeField] private AudioClip _transitionClip = null;
	[SerializeField] private AudioClip _clicClip = null;

	private ObjectPool<PropSoundAudioSource> _soundPool = null;
	#endregion Fields

	#region Methods
	private void Start()
	{
		_soundPool = new ObjectPool<PropSoundAudioSource>(OnCreate);
		DontDestroyOnLoad(this);
	}

	public void PlaySound(AudioClip clip)
	{
		PropSoundAudioSource source = _soundPool.Get();
		source.Play(clip);
	}

	public void PlaySoundFishingRodSound(AudioClip clip)
	{
		_fishingRodSoundSource.clip = clip;
		_fishingRodSoundSource.Play();
	}

	public void PlayTransitionSound()
	{
		PlaySound(_transitionClip);
	}

	public void PlayClicSound()
	{
		PlaySound(_clicClip);
	}

	public void MuteMusic()
	{
		_music.volume = 0.0f;
	}

	public void UnmuteMusic()
	{
		_music.volume = 1.0f;
	}
	#region Internals
	private PropSoundAudioSource OnCreate()
	{
		return PropSoundAudioSource.Instantiate(_soundSourcePrefab, transform);
	}

	internal void ReturnToPool(PropSoundAudioSource propSoundAudioSource)
	{
		_soundPool.Release(propSoundAudioSource);
	}
	#endregion Internals
	#endregion Methods
}
