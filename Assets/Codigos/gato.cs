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

    private void EscribeValorMatrizGato(string btn, int t)
    {
        int valor = (t == 1) ? 1 : 2;
        switch (btn)
        {
            case "c0": matrizGato[0, 0] = valor; break;
            case "c1": matrizGato[0, 1] = valor; break;
            case "c2": matrizGato[0, 2] = valor; break;
            case "c3": matrizGato[1, 0] = valor; break;
            case "c4": matrizGato[1, 1] = valor; break;
            case "c5": matrizGato[1, 2] = valor; break;
            case "c6": matrizGato[2, 0] = valor; break;
            case "c7": matrizGato[2, 1] = valor; break;
            case "c8": matrizGato[2, 2] = valor; break;
        }
    }
    
    private void VerificarGanador()
    {
        for (int i = 0; i < 3; i++)
        {
            if (matrizGato[i,0] != 0 && 
                matrizGato[i,0] == matrizGato[i,1] && 
                matrizGato[i,1] == matrizGato[i,2])
            {
                ganador = matrizGato[i,0];
                MostrarGanador();
                return;
            }
        }

        for (int j = 0; j < 3; j++)
        {
            if (matrizGato[0,j] != 0 && 
                matrizGato[0,j] == matrizGato[1,j] && 
                matrizGato[1,j] == matrizGato[2,j])
            {
                ganador = matrizGato[0,j];
                MostrarGanador();
                return;
            }
        }

        if (matrizGato[0,0] != 0 && 
            matrizGato[0,0] == matrizGato[1,1] && 
            matrizGato[1,1] == matrizGato[2,2])
        {
            ganador = matrizGato[0,0];
            MostrarGanador();
            return;
        }

        if (matrizGato[0,2] != 0 && 
            matrizGato[0,2] == matrizGato[1,1] && 
            matrizGato[1,1] == matrizGato[2,0])
        {
            ganador = matrizGato[0,2];
            MostrarGanador();
            return;
        }

        bool empate = true;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matrizGato[i, j] == 0) empate = false;
            }
        }

        if (empate)
        {
            txtJuego.text = "¡Empate!";
        }
    }

    private void MostrarGanador()
    {
        if (ganador == 1)
            txtJuego.text = "¡Ganó X!";
        else if (ganador == 2)
            txtJuego.text = "¡Ganó O!";

        for (int i = 1; i <= 9; i++)
        {
            GameObject.Find("c" + i).GetComponent<Button>().interactable = false;
        }
    }

    public void AsignaTurno(Button btn)
    {
        if (ganador == 0)
        {
            txtJuego.text = "Juego en curso";

            DibujaSimbolo(btn, turno);
            EscribeValorMatrizGato(btn.name, turno);
            VerificarGanador();

            turno = (turno == 1) ? 2 : 1; // alternar entre 1 y 2
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
