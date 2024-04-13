using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MultiSound", menuName = "Sound/MultiSound", order = 1)]
public class MultiAudioClip : ScriptableObject
{
	[SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

	public AudioClip GetRandomClip()
	{
		return audioClips[Random.Range(0, audioClips.Count)];
	}
}
