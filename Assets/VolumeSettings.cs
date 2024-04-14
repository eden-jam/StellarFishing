using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
	[SerializeField] private AudioMixer myMixer;
	[SerializeField] private Slider musicSlider;
	[SerializeField] private AudioMixer _audioMixer = null;

	public void SetVolume(string chanel, float value)
	{
		float val = Mathf.Lerp(-80, 0, value / 100.0f);
		_audioMixer.SetFloat(chanel, val);
	}
}