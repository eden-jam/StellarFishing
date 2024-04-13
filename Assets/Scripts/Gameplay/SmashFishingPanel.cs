using UnityEngine;
using UnityEngine.UI;

public class SmashFishingPanel : IFishingPanel
{
    [SerializeField] private float _addAmount = 0.01f;
    [SerializeField] private float _subRate = 0.1f;
	[SerializeField] private float _maxTime = 30.0f;
	[SerializeField] private Image _image = null;

	private float _timer = 0.0f;

	void OnEnable()
    {
		_image.fillAmount = 0.2f;
		_timer = _maxTime;
	}

	protected override void UpdateGame()
	{
		_image.fillAmount -= _subRate * Time.deltaTime;
		_timer -= Time.deltaTime;
		if (_timer <= 0.0f)
		{
			Failed();
		}
	}

    protected override void OnPressed()
	{
		_image.fillAmount += _addAmount;
		if (_image.fillAmount >= 1.0f)
		{
			Succeed();
		}
	}
}
