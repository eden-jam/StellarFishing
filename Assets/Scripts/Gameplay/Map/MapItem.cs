using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapItem : MonoBehaviour
{
	[SerializeField] private EnvironmentType _environmentType = EnvironmentType.None;
	[SerializeField] private int _index = 0;
	[SerializeField] private List<MapItem> _neighbours = null;

	[SerializeField] private Image _image = null;
	[SerializeField] private Sprite _pinkSprite = null;
	[SerializeField] private Sprite _greenSprite = null;
	[SerializeField] private Sprite _purpleSprite = null;

	public void Start()
	{
		switch (_environmentType)
		{
			case EnvironmentType.Green:
				{
					_image.sprite = _greenSprite;
				}
				break;
			case EnvironmentType.Pink:
				{
					_image.sprite = _pinkSprite;
				}
				break;
			case EnvironmentType.Purlple:
				{
					_image.sprite = _purpleSprite;
				}
				break;
		}
	}

	public void ActivateNext()
	{
        foreach (MapItem neighbour in _neighbours)
        {
			neighbour.Activate();
		}
    }

	public void OnPressed()
    {
		MapManager.Instance.Validate(_environmentType, _index);
    }

	public void Activate()
	{
		GetComponent<Button>().interactable = true;
		GetComponent<Button>().Select();
	}
}
