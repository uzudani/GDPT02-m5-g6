using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class TimerManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _countdownTime = 3f;

    public void StartCountDown(Action onComplete)
    {
        StartCoroutine(CountDownLogic(onComplete));
    }


    // Funzione da richiamare in PlayerColor (StartCorutine)
    private IEnumerator CountDownLogic(Action onComplete)
    {
        float time = _countdownTime;

        while (time > 0)
        {
            _timerText.text = time.ToString("F1"); // F1 Grazie Luca!
            time -= Time.deltaTime; // Tempo in ogni frame (-)
            yield return null; // Frame successivo
        }
        _timerText.text = "Press F to repeat!";
        onComplete?.Invoke();
    }
}
