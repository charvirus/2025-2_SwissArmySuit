using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI volumeText;

    private void Start()
    {
        slider.value = MusicBehavior.instance.GetVolume();
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        OnSliderValueChanged(slider.value);
    }

    void OnSliderValueChanged(float value)
    {
        MusicBehavior.instance.SetVolume(value);
        volumeText.text = value.ToString("F2");
    }
}