using System.Collections;
using UnityEngine;
using TMPro;

public class TextoInicio : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    public string mensaje = "Presiona la barra espaciadora para continuar...";
    public float velocidad = 0.05f;

    void Start()
    {
        textoUI.text = "";
        StartCoroutine(MostrarTexto());
    }

    IEnumerator MostrarTexto()
    {
        foreach (char letra in mensaje)
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidad);
        }
    }
}
