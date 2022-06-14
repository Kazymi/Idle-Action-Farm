using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create GatherConfiguration", fileName = "GatherConfiguration", order = 0)]
public class GatherConfiguration : ScriptableObject
{
    [SerializeField] private float lookingTime;
    [SerializeField] private float radius;
    [SerializeField] private float intervalBetweenCorn;
    [SerializeField] private int maxCorns;

    public int MAXCorns => maxCorns;

    public float IntervalBetweenCorn => intervalBetweenCorn;

    public float LookingTime => lookingTime;
    public float Radius => radius;
}