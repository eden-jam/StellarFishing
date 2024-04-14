using UnityEngine;
using UnityEngine.UI;

public sealed class PrecisionFishingPanel : IFishingPanel
{
	[SerializeField] private float _speed = 90.0f;
	[SerializeField] private Transform _cursor = null;
	[SerializeField] private float _degreeRatio = 0.1f;

	[SerializeField] private GameObject[] _area;

	[Header("Audio")]
	[SerializeField] private MultiAudioClip _fishingRodBad = null;
	[SerializeField] private MultiAudioClip _fishingRodGood = null;

	private bool _clockwise = true;

	private float _currentRotation = 0.0f;

	public override void Show()
	{
		base.Show();

		_currentRotation = 0.0f;
        foreach (var area in _area)
        {
			area.SetActive(true);
		}
    }

	protected override void UpdateGame()
	{
		float rotationDelta = Time.deltaTime * _speed;

		rotationDelta *= _clockwise ? 1.0f : -1.0f;

		_currentRotation += rotationDelta;
		_currentRotation = Module(_currentRotation);

		_cursor.transform.eulerAngles = Vector3.forward * _currentRotation;
	}

	protected override void OnPressed()
	{
		_clockwise = !_clockwise;
		int zone = GetZone(_currentRotation);
		if (zone >= 0)
		{
			AudioManager.Instance.PlaySoundFishingRodSound(_fishingRodGood.GetRandomClip());
			_area[zone].SetActive(false);
		}
		else
		{
			AudioManager.Instance.PlaySoundFishingRodSound(_fishingRodBad.GetRandomClip());
		}

		if (AreZoneDone())
		{
			Succeed();
		}
	}

	private bool AreZoneDone()
	{
		foreach (var area in _area)
		{
			if (area.activeSelf)
			{
				return false;
			}
		}
		return true;
	}

	private int GetZone(float rotation)
	{
		float zoneSize = 360.0f * _degreeRatio;

		if (rotation > 0 && rotation < zoneSize && _area[0].activeSelf)
		{
			return 0;
		}
		else if (rotation > 120.0f && rotation < 120.0f + zoneSize && _area[1].activeSelf)
		{
			return 1;
		}
		else if (rotation > 240.0f && rotation < 240.0f + zoneSize && _area[2].activeSelf)
		{
			return 2;
		}

		return -1;
	}

	private float Module(float rotation)
	{
		if (rotation < 0.0f)
		{
			return 360.0f - rotation;
		}
		return rotation % 360;
	}
}
