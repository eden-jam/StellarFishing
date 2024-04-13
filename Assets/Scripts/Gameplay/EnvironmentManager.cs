using UnityEngine;

public sealed class EnvironmentManager : Singleton<EnvironmentManager>
{
	#region Fields
	[SerializeField] private EnvironmentType _currentEnvironmentType = EnvironmentType.None;
	#endregion Fields

	#region Properties
	public EnvironmentType CurrentEnvironmentType { get => _currentEnvironmentType; }
	#endregion Properties
}