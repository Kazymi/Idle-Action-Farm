using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create HarvestConfiguration", fileName = "HarvestConfiguration", order = 0)]
public class HarvestConfiguration : ScriptableObject
{
    [SerializeField] private float lookingTime;
    [SerializeField] private float radius;

    public float LookingTime => lookingTime;

    public float Radius => radius;
}