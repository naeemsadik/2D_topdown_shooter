using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maximumHealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;

    public void TakeDamage (float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        _currentHealth -= damageAmount;
        OnHealthChanged.Invoke();

        if(_currentHealth < 0)
        {
            _currentHealth = 0;
            HandlePlayerDeath();
        }

        if (_currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if(_currentHealth== _maximumHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;
        OnHealthChanged.Invoke();

        if(_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }
    }

    
    private void HandlePlayerDeath()
    {
        SceneManager.LoadScene(2);
    }

    void Update() {
        if(_currentHealth <= 0) {
            HandlePlayerDeath();
        }
    }
}
