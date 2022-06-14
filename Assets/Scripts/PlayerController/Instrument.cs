using UnityEngine;

public class Instrument : MonoBehaviour
{
    [SerializeField] private GameObject instrument;

    public void ActivateInstrument(bool value)
    {
        instrument.SetActive(value);
    }
}