using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;

    private void Start()
    {
        // Recuperar valor guardado
        if (PlayerPrefs.HasKey("volumen"))
        {
            float savedVolumen = PlayerPrefs.GetFloat("volumen");
            CambiarVolumen(savedVolumen);
            slider.value = savedVolumen;
        }
        else
        {
            CambiarVolumen(slider.value);
        }
    }

    public void CambiarVolumen(float valor)
    {
        // Convierte el valor (0 a 1) a decibelios (AudioMixer usa dB)
        float volumenDB = Mathf.Log10(Mathf.Clamp(valor, 0.0001f, 1f)) * 20;
        audioMixer.SetFloat("Volumen", volumenDB);

        // Guardar valor para que se mantenga entre escenas
        PlayerPrefs.SetFloat("volumen", valor);
    }
}
