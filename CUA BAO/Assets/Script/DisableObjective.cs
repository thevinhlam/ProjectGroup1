using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjective : MonoBehaviour
{

     [SerializeField] GameObject _objective;

    public void _HideObj()
    {
        _objective.SetActive(false);
    }

    public void _HideGate()
    {
        _objective.SetActive(false);
    }
}
