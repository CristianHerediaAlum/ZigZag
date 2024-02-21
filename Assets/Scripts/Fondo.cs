using UnityEngine;
using UnityEngine.UI;

public class BackgroundSetter : MonoBehaviour
{
    public Sprite backgroundImage; // Arrastra tu imagen de fondo aquí en el Inspector

    void Start()
    {
        var image = GetComponent<Image>();
        if (image != null)
        {
            image.sprite = backgroundImage;
        }
    }
}