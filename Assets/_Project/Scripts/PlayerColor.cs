using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [Header("References Settings")]
    [SerializeField] private TimerManager _timerManager;
    [SerializeField] private Renderer _renderer;

    private bool _isCounting = false;

    private void Update()
    {
        InputWithTime();
    }

    private void InputWithTime()
    {
        if (Input.GetKeyDown(KeyCode.F) && !_isCounting) // Se F e nessun timer in corso
        {
            StartCoroutine(ChangeColorAfterCountdown()); // Corutine timer + cambio colore
        }
    }

    private IEnumerator ChangeColorAfterCountdown()
    {
        _isCounting = true; // Timer in corso

        yield return StartCoroutine(_timerManager.StartCountDown()); // Avvio corutine del TimerManager e aspetto che finisca

        _renderer.material.color = Random.ColorHSV(); // Cambia colore random a countdown finito

        _isCounting = false; // Timer concluso (posso premere F)
    }
}
