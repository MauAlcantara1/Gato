using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Importa el nuevo sistema

public class Navegacion : MonoBehaviour
{
    void Update()
    {
        // Detecta si se presionó la barra espaciadora
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            MenuAMain();
        }
    }

    public void MenuAMain()
    {
        SceneManager.LoadScene("Main");
    }
}

