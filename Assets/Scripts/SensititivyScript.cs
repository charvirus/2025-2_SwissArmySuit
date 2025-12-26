using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SensititivyScript : MonoBehaviour
{ 
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI sliderText;
    [SerializeField]
    private MouseLook mouseLook;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(UpdateSensitivity);
        
        UpdateSensitivity(slider.value);
    }

    // Update is called once per frame
    void UpdateSensitivity(float value)
    {
        mouseLook.SetMouseSensitivity(value);
        sliderText.text = value.ToString("F2");
    }
}
