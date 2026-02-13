using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _countdownTime = 3f;


    // Funzione da richiamare in PlayerColor (StartCorutine)
    public IEnumerator StartCountDown()
    {
        float time = _countdownTime;

        while (time > 0)
        {
            _timerText.text = time.ToString("F1"); // F1 Grazie Luca!
            time -= Time.deltaTime; // Tempo in ogni frame (-)
            yield return null; // Frame successivo
        }
        _timerText.text = "Press F to repeat!";
    }
}
