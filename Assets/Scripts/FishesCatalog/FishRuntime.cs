using UnityEngine;

public static class FishSpawner
{
	#region Methods
	public static GameObject SpawnFish(FishDescription fishDescription, Transform modelTransform)
	{
		 return GameObject.Instantiate(fishDescription.ModelPrefab, modelTransform);
	}
	#endregion Methods
}
