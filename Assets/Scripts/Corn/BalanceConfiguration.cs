using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create BalanceConfiguration", fileName = "BalanceConfiguration", order = 0)]
public class BalanceConfiguration : ScriptableObject
{
    [SerializeField] private float interval;
    [SerializeField] private float idleShaking;
    [SerializeField] private float maxShaking;
    [SerializeField] private float shakingIncrease;
    [SerializeField] private float speed;

    public float Interval => interval;

    public float Speed => speed;

    public float IdleShaking => idleShaking;

    public float MAXShaking => maxShaking;

    public float ShakingIncrease => shakingIncrease;
}