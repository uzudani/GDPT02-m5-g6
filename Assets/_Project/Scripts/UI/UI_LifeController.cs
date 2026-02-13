using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LifeController _life;
    [SerializeField] private Image _lifeBar;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _life.OnHealthChanged += UpdateLifeBar;
        _life.OnHealingPoints += ChangeUIText;
    }

    private void OnDisable()
    {
        _life.OnHealthChanged -= UpdateLifeBar;
        _life.OnHealingPoints -= ChangeUIText;
    }

    public void UpdateLifeBar(float hp, float maxHp)
    {
        _lifeBar.fillAmount = hp / maxHp; // Da 0 a 1
        _text.text = $"{hp} / {maxHp}";
    }

    public void ChangeUIText(float hp)
    {
        _text.text = hp.ToString();
    }
}
