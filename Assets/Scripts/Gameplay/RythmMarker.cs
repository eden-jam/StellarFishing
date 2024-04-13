using UnityEngine;

public sealed class RythmMarker : MonoBehaviour
{
	#region Fields
	[SerializeField] private GameObject _neutralTick = null;
	[SerializeField] private GameObject _succeedTick = null;
	[SerializeField] private GameObject _failedTick = null;

	private bool _isSucceed = false;
	#endregion Fields

	#region Propertis
	public bool IsSucceed { get => _isSucceed; }
	#endregion Propertis

	#region Methods
	public void SetState(bool succeed)
	{
		_isSucceed = succeed;

		_neutralTick.SetActive(false);

		_succeedTick.SetActive(succeed == true);
		_failedTick.SetActive(succeed == false);
	}
	#endregion Methods
}
