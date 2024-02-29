using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Sonido
{
    public string nombre;
    public AudioClip clip;

    public float volumen;

    public bool loop;

    public AudioSource source;
}
