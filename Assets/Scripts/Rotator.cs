using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	#region Fields
	[SerializeField] private Vector3 _rotation = Vector3.zero;
	#endregion Fields

	#region Methods
	private void FixedUpdate()
	{
		transform.Rotate(_rotation);
	}
	#endregion Methods
}
