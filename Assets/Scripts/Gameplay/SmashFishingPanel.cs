using UnityEngine;
using UnityEngine.UI;

public sealed class SmashFishingPanel : IFishingPanel
{
    [SerializeField] private float _addAmount = 0.01f;
    [SerializeField] private float _subRate = 0.1f;
    [SerializeField] private float _minHeight = 0.1f;
    [SerializeField] private float _maxHeight = 0.1f;
	[SerializeField] private Image _image = null;

	private float _fillAmount = 1.0f;

	public override void Show()
	{
		base.Show();
		_fillAmount = 0.2f;
	}

	protected override void UpdateGame()
	{
		_fillAmount -= _subRate * Time.deltaTime;
		_fillAmount = Mathf.Clamp01(_fillAmount);
		_image.rectTransform.sizeDelta = new Vector2(_image.rectTransform.sizeDelta.x, Mathf.Lerp(_minHeight, _maxHeight, _fillAmount));
	}

    protected override void OnPressed()
	{
		_fillAmount += _addAmount;
		if (_fillAmount >= 1.0f)
		{
			Succeed();
			_image.rectTransform.sizeDelta = new Vector2(_image.rectTransform.sizeDelta.x, Mathf.Lerp(_minHeight, _maxHeight, 1.0f));
		}
	}
}
