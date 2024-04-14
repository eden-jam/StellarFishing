using UnityEngine;
using UnityEngine.UI;

public class FishThumbnail : MonoBehaviour
{
	#region Fields
	[SerializeField] private FishDescription _fishDescription = null;
	[SerializeField] private RawImage _image = null;
	#endregion Fields

	#region Properties
	public FishDescription FishDescription { get => _fishDescription;  }
	#endregion Properties

	#region Methods
	private void OnEnable()
	{
		if (GameManager.Instance.FishesFished.Contains(_fishDescription))
		{
			_image.color = Color.white;
		}
		else
		{
			_image.color = Color.black;
		}
	}
	#endregion Methods
}
