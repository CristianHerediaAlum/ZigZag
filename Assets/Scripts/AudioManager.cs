using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sonido[] sonidos;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Sonido s in sonidos)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }

        PlaySound("MainTheme");
    }

    public void PlaySound(string nombre)
    {
        foreach(Sonido s in sonidos)
        {
            if(s.nombre == nombre)
                s.source.Play();
        }
    }
}
