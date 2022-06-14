using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create DroppedCornConfiguration", fileName = "DroppedCornConfiguration", order = 0)]
public class DroppedCornConfiguration : ScriptableObject
{
    [SerializeField] private float duration;

    public float Duration => duration;
}