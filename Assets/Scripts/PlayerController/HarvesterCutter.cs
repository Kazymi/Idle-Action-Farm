using UnityEngine;

public class HarvesterCutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var corn = other.GetComponent<Corn>();
        if (corn && corn.IsCornActive)
        {
            corn.CuteCorn();
        } 
    }
}