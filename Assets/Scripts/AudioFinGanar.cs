using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerSceneSpecific : MonoBehaviour
{

    private string currentScene;

    void Start()
    {
        // Obtener el nombre de la escena actual
        currentScene = SceneManager.GetActiveScene().name;

        // Reproducir el sonido correspondiente según la escena
        PlaySceneSpecificSound();
    }

    void PlaySceneSpecificSound()
    {
        if (currentScene == "GameOver")
        {
            FindObjectOfType<AudioManager>().PlaySound("Muerte");
        }
        else if (currentScene == "Ganar")
        {
            FindObjectOfType<AudioManager>().PlaySound("Victoria");
        }
    }
}
