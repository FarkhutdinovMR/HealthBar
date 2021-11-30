using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _startHealth;

    private float _health;

    public UnityAction<float> HealthChanged;

    private void Start()
    {
        SetHealth(_startHealth);
    }

    public void TakeDamage(float value)
    {
        SetHealth(-value);
    }

    public void Healing(float value)
    {
        SetHealth(value);
    }

    private void SetHealth(float value)
    {
        _health += value;
        _health = Mathf.Clamp(_health, 0f, _maxHealth);
        HealthChanged?.Invoke(_health);
    }
}