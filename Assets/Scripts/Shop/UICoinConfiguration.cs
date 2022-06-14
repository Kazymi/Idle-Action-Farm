using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create UICoinConfiguration", fileName = "UICoinConfiguration", order = 0)]
public class UICoinConfiguration : ScriptableObject
{
    [SerializeField] private float duration;

    public float Duration => duration;
}