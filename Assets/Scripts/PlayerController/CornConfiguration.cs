using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create CornConfiguration", fileName = "CornConfiguration", order = 0)]
public class CornConfiguration : ScriptableObject
{
    [SerializeField] private float respawnTime;

    public float RespawnTime => respawnTime;
}