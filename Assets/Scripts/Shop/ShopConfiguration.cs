using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create ShopConfiguration", fileName = "ShopConfiguration", order = 0)]
public class ShopConfiguration : ScriptableObject
{
    [SerializeField] private float intervalRequest;
    [SerializeField] private float sellTime;

    public float SellTime => sellTime;

    public float IntervalRequest => intervalRequest;
}