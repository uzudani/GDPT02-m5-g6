using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class LifeController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _hp = 100f;
    [SerializeField] private float _maxHp = 200f;

    public Action<float, float> OnHealthChanged;
    public Action<float> OnHealingPoints;
    public Action OnDeath;


    private void Start()
    {
        OnHealthChanged.Invoke(_hp, _maxHp);
    }

    public void TakeDamage(float damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
            return;
        }
        OnHealthChanged?.Invoke(_hp, _maxHp);
    }

    public void Heal(float healPoints)
    {
        _hp += healPoints;

        if (_hp > _maxHp) _hp = _maxHp;

        OnHealingPoints?.Invoke(_hp);          // Aggiorno il testo
        OnHealthChanged?.Invoke(_hp, _maxHp);  // Aggiorno la barra
    }
}
