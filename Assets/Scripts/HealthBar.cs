using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;
    [SerializeField] private float _changeSpeed;

    private float _currentValue;
    private Coroutine _changeHealth;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float value)
    {
        _currentValue = value / 100f;
        _text.SetText($"Çהמנמגüו: {value.ToString()}");

        if (_changeHealth != null)
            StopCoroutine(_changeHealth);

        _changeHealth = StartCoroutine(nameof(ChangeHealth));
    }

    private IEnumerator ChangeHealth()
    {
        while (Mathf.Approximately(_slider.value, _currentValue) == false)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _currentValue, _changeSpeed * Time.deltaTime);

            yield return null;
        }
    }
}