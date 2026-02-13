using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSubscriber : MonoBehaviour
{

    [SerializeField] private ExCallbacks _exCallbacks;
    [SerializeField] private string _message = "A";

    private void PrintMessage()
    {
        Debug.Log(_message + " from" + gameObject.name, gameObject);
    }

    private void OnEnable()
    {
        _exCallbacks.onEnterPressed += PrintMessage;
    }

    private void OnDisable()
    {
        _exCallbacks.onEnterPressed -= PrintMessage;
    }
}
