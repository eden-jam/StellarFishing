using UnityEngine;
using UnityEngine.UI;

public class WinPanel : IEndPanel
{
	[SerializeField] private Image _image = null;

	public void Display(Sprite sprite)
	{
		_image.sprite = sprite;
	}
}
