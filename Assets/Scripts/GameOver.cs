using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    private Button salir;
    private Button empezar;


    // Start is called before the first frame update
    void Start()
    {
        empezar = GameObject.FindWithTag("BotonSalir").GetComponent<Button>();
        salir = GameObject.FindWithTag("Acabar").GetComponent<Button>();
        empezar.onClick.AddListener(Ocultar);
        salir.onClick.AddListener(Salir);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Ocultar()
    {
        salir.gameObject.SetActive(false);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
