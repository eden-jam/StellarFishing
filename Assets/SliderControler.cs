using TMPro;
using UnityEngine;

public class SliderControler : MonoBehaviour
{
	[SerializeField] private string _chanel = string.Empty;
	[SerializeField] private VolumeSettings _volumeSettings = null;
	[SerializeField] private TextMeshProUGUI valueText = null;

	public void OnSliderChanged(float value)
	{
		valueText.text = value.ToString();

		_volumeSettings.SetVolume(_chanel, value);
	}
}
