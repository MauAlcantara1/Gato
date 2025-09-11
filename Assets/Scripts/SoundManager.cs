using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Clips de sonido")]
    public AudioClip pitido;
    public AudioClip alerta;

    private AudioSource audioSource;

    private void Awake()
    {
        // Singleton para acceder fácilmente desde cualquier script
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Para que no se borre al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirPitido()
    {
        audioSource.PlayOneShot(pitido);
    }

    public void ReproducirAlerta()
    {
        audioSource.PlayOneShot(alerta);
    }
}