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
            _isCounting = true;
            _timerManager.StartCountDown(
                () =>
                {
                    _renderer.material.color = Random.ColorHSV(); // Callback a fine timer
                    _isCounting = false;
                });
        }
    }
}
