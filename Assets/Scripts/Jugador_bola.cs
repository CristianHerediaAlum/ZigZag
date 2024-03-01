using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jugador_bola : MonoBehaviour
{
    // Publicas
    public Camera camara;
    public GameObject suelo;
    public float velocidad = 5.0f;
    public ParticleSystem particleSystem;
    public Image CorazonImage1;
    public Image CorazonImage2;
    public Image CorazonImage3;
    public Text contador;



    // Privadas
    private Vector3 offset;
    private float Valx, Valz;
    private Vector3 DireccionActual;
    private Rigidbody rb;
	private int totalEstrellas = 0;
    private int totalCorazones = 3;
    private string escena = "";

    // Start is called before the first frame update
    void Start()
    {
        offset = camara.transform.position - transform.position;
        rb = GetComponent<Rigidbody>();
        CrearSueloInicial();
        DireccionActual = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.X)) {
            CambiarDireccion();
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            if(rb.position.y < 1.0f)
                rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void FixedUpdate() {
        camara.transform.position =  transform.position + offset;
        transform.Translate(DireccionActual * velocidad * Time.deltaTime);
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Suelo") {
            StartCoroutine(BorrarSuelo(other.gameObject));
        }
        
    }

    // IEnumerator BorrarSuelo(GameObject suelo) {
    //     float aleatorio = Random.Range(0.0f, 1.0f);
    //     if(aleatorio > 0.5f) {
    //         Valx += 6.0f;
    //     }
    //     else {
    //         Valz += 6.0f;
    //     }
    //     Instantiate(suelo, new Vector3(Valx, 0, Valz), Quaternion.identity);
    //     yield return new WaitForSeconds(1);
    //     suelo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    //     suelo.gameObject.GetComponent<Rigidbody>().useGravity = true;
    //     yield return new WaitForSeconds(2);
    //     Destroy(suelo);
    // }
    IEnumerator BorrarSuelo(GameObject suelo) {
        float aleatorio = Random.Range(0.0f, 1.0f);
        if(aleatorio > 0.5f) {
            Valx += 6.0f;
        }
        else {
            Valz += 6.0f;
        }
        GameObject nuevoSuelo = Instantiate(suelo, new Vector3(Valx, 0, Valz), Quaternion.identity);
        yield return new WaitForSeconds(1);
        suelo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        suelo.gameObject.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(2);
        if (suelo != null) {
            Destroy(suelo);
    }
}

    void CambiarDireccion() {
        if(DireccionActual == Vector3.forward) {
            DireccionActual = Vector3.right;
        } 
        else {
            DireccionActual = Vector3.forward;
        }
    }

    void CrearSueloInicial() {
        for (int i = 0; i < 3; i++)
        {
            Valz += 6.0f;
            Instantiate(suelo, new Vector3(Valx, 0, Valz), Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Premio")){
            if (particleSystem != null)
            {
                particleSystem.Play(); // Inicia la reproducción del sistema de partículas al tocar el cubo
            }
            FindObjectOfType<AudioManager>().PlaySound("CogerMoneda");
            totalEstrellas++;
			contador.text = "Contador = " + totalEstrellas;
            Destroy(other.gameObject);
            if(totalEstrellas >= 10) {

                escena = SceneManager.GetActiveScene().name;
                int escenaActual = int.Parse(escena);
                if(escenaActual == 3) {
                    SceneManager.LoadScene("Ganar");
                }
                escenaActual++;
                escena = (escenaActual).ToString();
                SceneManager.LoadScene(escena);
            }
        }
        if(other.gameObject.CompareTag("Enemigo")) {
            FindObjectOfType<AudioManager>().PlaySound("Golpe"); // Hay que meter sonido
            totalCorazones--;
            if(totalCorazones == 2) {
                CorazonImage3.enabled = false;
            }
            else if(totalCorazones == 1) {
                CorazonImage2.enabled = false;
            }
            else if(totalCorazones == 0) {
                CorazonImage1.enabled = false;
                SceneManager.LoadScene("GameOver");
            }
            Destroy(other.gameObject);
        }
    }
}
