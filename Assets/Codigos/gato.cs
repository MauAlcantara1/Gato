using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gato : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI txtJuego;
    private int[,] matrizGato = new int[3, 3];
    private int turno = 1;
    private int ganador = 0;
    public Sprite spriteX;
    public Sprite spriteO;
    
    void Start()
    {
        IniciaGato();
    }

    public void AsignaTurno(Button btn)
    {
        if (ganador == 0)
        {
            txtJuego.text = "Juego en curso";

            DibujaSimbolo(btn, turno);

            turno = (turno == 0) ? 1 : 0;
        }
    }


    private void DibujaSimbolo(Button btn, int turno)
    {
        Image img = btn.GetComponent<Image>();

        if (turno == 1)
        {
            img.sprite = spriteX;
        }
        else
        {
            img.sprite = spriteO;
        }

        img.color = Color.white;
        btn.interactable = false;
    }


    private void IniciaGato()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matrizGato[i, j] = 0;
            }
        }

        for (int i = 1; i <= 9; i++)
        {
            Image img = GameObject.Find("c" + i).GetComponent<Image>();
            img.sprite = null;        
            img.color = new Color(1,1,1,0); 
            GameObject.Find("c" + i).GetComponent<Button>().interactable = true;
        }
    }


    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("Main");
    }
}
