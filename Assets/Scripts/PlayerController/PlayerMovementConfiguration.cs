using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create PlayerMovementConfiguration", fileName = "PlayerMovementConfiguration", order = 0)]
public class PlayerMovementConfiguration : ScriptableObject
{
    [SerializeField] private float timeToNewPosition;
    [SerializeField] private float speed;

    public float TimeToNewPosition => timeToNewPosition;

    public float Speed => speed;
}