using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data; // Contiene Action e Func

public class ExCallbacks : MonoBehaviour
{

    public Action onEnterPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            onEnterPressed?.Invoke();
        }
    }


    void Start()
    {
        Action myAction01; // Posso collegare funzioni void SENZA parametri

        myAction01 = VoidSenzaParamentri;
        myAction01 += FuncA; // Senza parentesi!!
        myAction01 += FuncB;

        myAction01?.Invoke();

        myAction01 -= FuncA;

        myAction01?.Invoke();

        Action<int, int> actionCon2Iny = PrintLifePercenttage; // Parametri come UnityEvents con <variabile>

        actionCon2Iny?.Invoke(20, 30); // Qui per forza due parametri dato che abbiamo chiamato action con parametri

        Action<int> actionCon1Int = PrintDouble;

        actionCon1Int?.Invoke(2);
        actionCon1Int?.Invoke(10);
        actionCon1Int?.Invoke(255);

        Action<int, string, bool> actionIntStringBool = FunzioneConParametriIntSringBool;
        actionIntStringBool?.Invoke(10, "casa", true);

        // Ultima cosa che metto tra parentesi angolari e' il TIPO DI DATO RESTITUITO
        Func<int> funcInt = RandomNumber0To100; // Funzioni senza parametri che restituiscono int
        Debug.Log("Numeri Casuali");

        for (int i = 0; i < 4; i++)
        {
            int random = (funcInt != null) ? funcInt.Invoke() : 0;
            Debug.Log(random);
        }

        Func<bool> funcBool = FlipCoin;
        Debug.Log("Lanciamo la moneta!");

        for (int i = 0; i < 4; i++)
        {
            string text = funcBool.Invoke() ? "TESTA" : "CROCE";
            Debug.Log(" E' uscito" + text);
        }

        // Si collega a funzioni che restituiscono bool e che hanno parametri int
        // <parametro, restituzione>
        Func<int, bool> funcBoolConParamInt = IsEven;
        Debug.Log("IsEven(13)" + funcBoolConParamInt.Invoke(13));
        Debug.Log("IsEven(16)" + funcBoolConParamInt.Invoke(16));

        // posso anche collegare funzioni ANONIME dette funzioni LAMBDA
        //                  (nomi dei parametri) => { ISTRUZIONI }
        Action myAction02 = () => { Debug.Log("Questa e' una funzione LAMBDA"); };

        // non serve mettere in una sola riga, ANZI..
        myAction02 += () =>
        {
            Debug.Log("Qui ci posso fare cio che voglio, perfino un ciclo");
            for (int i = 0; i < 4; i++)
            {
                // e richiamare altre funzioni o altre ACTION a patto che siano visibili
                bool b = funcBool.Invoke();
                Debug.Log("funcBool.Invoke" + b);
            }
        };

        myAction02?.Invoke();

        DoSomethingAfterInstantCountdown(10, VoidSenzaParamentri);
        DoSomethingAfterInstantCountdown(10, null);
        DoSomethingAfterInstantCountdown(10, () =>
        {
            Debug.Log("Funzione lambda dopo countdown");
        });

        StartCoroutine(DoSomethingAfterRealCountdown(3, VoidSenzaParamentri));
        StartCoroutine(DoSomethingAfterRealCountdown(10, null));
        StartCoroutine(DoSomethingAfterRealCountdown(20,
        () =>
        {
            Debug.Log("Proviamo a far partire una corutine dopo questo countdown finito");
            StartCoroutine(DoSomethingAfterRealCountdown(5,
                () =>
                {
                    Debug.Log("Finito anche il countdown secondario");
                }));
        }));

    }

    // callback molto usato "fai questo e poi mi richiami"
    void DoSomethingAfterInstantCountdown(int countdownStart, Action callback)
    {
        for (int i = countdownStart; i >= 0; i--)
        {
            Debug.Log(i);
        }
        Debug.Log("Eseguiamo callback!");
        callback?.Invoke(); // Sempre mettere "?"!!
    }

    IEnumerator DoSomethingAfterRealCountdown(int seconds, Action callback)
    {
        WaitForSeconds wfs = new WaitForSeconds(1);
        for (int i = 0; i < seconds; i++)
        {
            Debug.Log(i + Time.time);
            yield return wfs;
        }
        Debug.Log("Eseguiamo callback!");
        callback?.Invoke();
    }

    bool FlipCoin()
    {
        return UnityEngine.Random.Range(0, 101) >= 50;
    }

    int RandomNumber0To100()
    {
        return UnityEngine.Random.Range(0, 101);
    }

    void FunzioneConParametriIntSringBool(int a, string b, bool c)
    {
        Debug.Log("Eseguito esempio IntStringBool");
    }

    void VoidSenzaParamentri()
    {
        Debug.Log("Eseguito-VoidSenzaParamentri()");
    }

    void FuncA()
    {
        Debug.Log("Eseguito-FuncA()");
    }

    void FuncB()
    {
        Debug.Log("Eseguito-FuncB()");
    }

    void PrintLifePercenttage(int currentHp, int maxHp)
    {
        int lifePercentage = currentHp * 100 / maxHp;
        Debug.Log($"Life = {currentHp} / {maxHp} % ... {lifePercentage} ");
    }

    void PrintDouble(int number)
    {
        Debug.Log($"{number * 2}");
    }

    bool IsEven(int number)
    {
        return number % 2 == 0;
    }
}
