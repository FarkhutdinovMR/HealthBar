using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;
    [SerializeField] private float _changeSpeed;

    private float _currentValue;
    private float _runningTime;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void Update()
    {
        if (_slider.value != _currentValue)
        {
            _runningTime += Time.deltaTime;
            _slider.value = Mathf.Lerp(_slider.value, _currentValue, _runningTime * _changeSpeed);
        }
    }

    private void OnHealthChanged(float value)
    {
        _runningTime = 0f;
        _currentValue = value / 100f;
        _text.SetText($"Çהמנמגüו: {value.ToString()}");
    }
}