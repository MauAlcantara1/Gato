using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gato : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI txtJuego;
    public TextMeshProUGUI txtTurnos;
    public TextMeshProUGUI txtPuntosX;
    public TextMeshProUGUI txtPuntosO;

    private int[,] matrizGato = new int[3, 3];
    private int turno = 1;
    private int ganador = 0;
    private int puntosX = 0;
    private int puntosO = 0;

    public Sprite spriteX;
    public Sprite spriteO;
    private int movimientos = 0;

    void Start()
    {
        IniciaGato();
        movimientos = 0;
        txtTurnos.text = "Turno de X";
        ActualizarMarcador();
    }

    private void EscribeValorMatrizGato(string btn, int t)
    {
        int valor = (t == 1) ? 1 : 2;
        switch (btn)
        {
            case "c1":
                matrizGato[0, 0] = valor;
                break;
            case "c2":
                matrizGato[0, 1] = valor;
                break;
            case "c3":
                matrizGato[0, 2] = valor;
                break;
            case "c4":
                matrizGato[1, 0] = valor;
                break;
            case "c5":
                matrizGato[1, 1] = valor;
                break;
            case "c6":
                matrizGato[1, 2] = valor;
                break;
            case "c7":
                matrizGato[2, 0] = valor;
                break;
            case "c8":
                matrizGato[2, 1] = valor;
                break;
            case "c9":
                matrizGato[2, 2] = valor;
                break;
        }
    }

    private void VerificarGanador()
    {
        // todas las condiciones para encontrar ganador...
        if (matrizGato[0, 0] == 1 && matrizGato[0, 1] == 1 && matrizGato[0, 2] == 1)
        {
            ganador = 1;
            Debug.Log("1");
            ReiniciarConRetraso(3f);
        }
        if (matrizGato[1, 0] == 1 && matrizGato[1, 1] == 1 && matrizGato[1, 2] == 1)
        {
            ganador = 1;
            Debug.Log("2");
            ReiniciarConRetraso(3f);
        }
        if (matrizGato[2, 0] == 1 && matrizGato[2, 1] == 1 && matrizGato[2, 2] == 1)
        {
            ganador = 1;
            Debug.Log("3");
            ReiniciarConRetraso(3f);
        }

        if (matrizGato[0, 0] == 2 && matrizGato[0, 1] == 2 && matrizGato[0, 2] == 2)
        {
            ganador = 2;
            Debug.Log("4");
            ReiniciarConRetraso(3f);
        }
        if (matrizGato[1, 0] == 2 && matrizGato[1, 1] == 2 && matrizGato[1, 2] == 2)
        {
            ganador = 2;
            Debug.Log("5");
            ReiniciarConRetraso(3f);
        }
        if (matrizGato[2, 0] == 2 && matrizGato[2, 1] == 2 && matrizGato[2, 2] == 2)
        {
            ganador = 2;
            Debug.Log("6");
            ReiniciarConRetraso(3f);
        }
        //diagonales
        if (matrizGato[0, 0] == 1 && matrizGato[1, 1] == 1 && matrizGato[2, 2] == 1)
        {
            ganador = 1;
            Debug.Log("7");
            ReiniciarConRetraso(3f);
        }
        if (matrizGato[0, 2] == 1 && matrizGato[1, 1] == 1 && matrizGato[2, 0] == 1)
        {
            ganador = 1;
            Debug.Log("8");
            ReiniciarConRetraso(3f);
        }

        if (matrizGato[0, 0] == 2 && matrizGato[1, 1] == 2 && matrizGato[2, 2] == 2)
        {
            ganador = 2;
            Debug.Log("9");
            ReiniciarConRetraso(3f);
        }
        if (matrizGato[0, 2] == 2 && matrizGato[1, 1] == 2 && matrizGato[2, 0] == 2)
        {
            ganador = 2;
            Debug.Log("10");
            ReiniciarConRetraso(3f);
        }

        if (matrizGato[0, 0] == 1 && matrizGato[1, 0] == 1 && matrizGato[2, 0] == 1)
        {
            ganador = 1;
            Debug.Log("11");
            ReiniciarConRetraso(3f);
        }
        if (matrizGato[0, 1] == 1 && matrizGato[1, 1] == 1 && matrizGato[2, 1] == 1)
        {
            ganador = 1;
            Debug.Log("12");
            ReiniciarConRetraso(3f);
        }
        if (matrizGato[0, 2] == 1 && matrizGato[1, 2] == 1 && matrizGato[2, 2] == 1)
        {
            ganador = 1;
            Debug.Log("13");
            ReiniciarConRetraso(3f);
        }

        if (matrizGato[0, 0] == 2 && matrizGato[1, 0] == 2 && matrizGato[2, 0] == 2)
        {
            ganador = 2;
            Debug.Log("14");
            ReiniciarConRetraso(3f);
        }
        if (matrizGato[0, 1] == 2 && matrizGato[1, 1] == 2 && matrizGato[2, 1] == 2)
        {
            ganador = 2;
            Debug.Log("15");
            ReiniciarConRetraso(3f);
        }
        if (matrizGato[0, 2] == 2 && matrizGato[1, 2] == 2 && matrizGato[2, 2] == 2)
        {
            ganador = 2;
            Debug.Log("16");
            ReiniciarConRetraso(3f);
        }

        if (ganador == 0 && movimientos == 9)
        {
            txtJuego.text = "Empate";
        }

        if (ganador == 1)
        {
            txtJuego.text = "Ganador X";
            puntosX++;
            ActualizarMarcador();
            SoundManager.instance.ReproducirAlerta(); // sonido al ganar X
        }

        if (ganador == 2)
        {
            txtJuego.text = "Ganador O";
            puntosO++;
            ActualizarMarcador();
            SoundManager.instance.ReproducirAlerta(); // sonido al ganar O
        }
    }

    public void AsignaTurno(Button btn)
    {
        if (ganador == 0)
        {
            txtJuego.text = "Juego Nuevo";
            DibujaSimbolo(btn, turno);
            EscribeValorMatrizGato(btn.name, turno);
            movimientos++;

            SoundManager.instance.ReproducirPitido(); // 📢 sonido al colocar ficha

            VerificarGanador();

            turno = (turno == 1) ? 2 : 1;
            if (turno == 1)
            {
                txtTurnos.text = "Turno de X";
            }
            else
            {
                txtTurnos.text = "Turno de O";
            }
        }
    }

    private void ActualizarMarcador()
    {
        txtPuntosX.text = puntosX.ToString();
        txtPuntosO.text = puntosO.ToString();
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
            img.color = new Color(1, 1, 1, 0);
            GameObject.Find("c" + i).GetComponent<Button>().interactable = true;
        }
    }

    private void ReiniciarConRetraso(float segundos)
    {
        StartCoroutine(ReiniciarCoroutine(segundos));
    }

    private IEnumerator ReiniciarCoroutine(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        IniciaGato(); // 👈 Limpia tablero
        ganador = 0;
        movimientos = 0;
        turno = 1;
        txtJuego.text = "Turno de X"; // Reinicia turno
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("Main");
    }

    public void RegresarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
