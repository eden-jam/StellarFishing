using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[Serializable]
public class Narration
{
	public List<int> AfterIndexes;
	public AudioClip AudioClip;
	public float SubtitlesSpeed;
	public List<string> Subtitles;
}

[CreateAssetMenu(fileName = "NarrationCatalog", menuName = "Scriptable Objects/Narration Catalog", order = 1)]
public class NarrationCatalog : ScriptableObject
{
	[SerializeField] private AnimationClip _startVideoClip = null;
	[SerializeField] private AnimationClip _endVideoClip = null;

	[SerializeField] private List<Narration> _narration = null;

    public AnimationClip StartVideoClip { get => _startVideoClip; }
    public AnimationClip EndVideoClip { get => _endVideoClip; }

    public Narration FindNarration(int lastIndex)
	{
        foreach (Narration narration in _narration)
		{
			foreach (int index in narration.AfterIndexes)
			{
				if (index == lastIndex)
				{
					return narration;
				}
			}
		}

		return null;
	}
}
