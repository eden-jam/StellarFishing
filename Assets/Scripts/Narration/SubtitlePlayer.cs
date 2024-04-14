using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitlePlayer : MonoBehaviour
{
	private float _waitTime = 4.0f;
	[SerializeField] private TextMeshProUGUI _subtitle = null;

	public void Play(List<string> subtitle, float waitTime)
	{
		_waitTime = waitTime;
		StartCoroutine(Loop(subtitle));
	}

	public IEnumerator Loop(List<string> subtitle)
	{
        for (int i = 0; i < subtitle.Count; i++)
		{
			_subtitle.text = subtitle[i];

			yield return new WaitForSeconds(_waitTime);
		}
	}
}
