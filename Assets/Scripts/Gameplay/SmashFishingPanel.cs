using UnityEngine;
using UnityEngine.UI;

public sealed class SmashFishingPanel : IFishingPanel
{
    [SerializeField] private float _addAmount = 0.01f;
    [SerializeField] private float _subRate = 0.1f;
	[SerializeField] private Image _image = null;

	public void OnEnable()
	{
		_image.fillAmount = 0.2f;
	}

	protected override void UpdateGame()
	{
		_image.fillAmount -= _subRate * Time.deltaTime;
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
