using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_bola : MonoBehaviour
{
    // Publicas
    public Camera camara;
    public GameObject suelo;
    public float velocidad = 5.0f;

    // Privadas
    private Vector3 offset;
    private float Valx, Valz;
    private Vector3 DireccionActual;
    // Start is called before the first frame update
    void Start()
    {
        offset = camara.transform.position - transform.position;
        CrearSueloInicial();
        DireccionActual = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        camara.transform.position =  transform.position + offset;
        if(Input.GetKeyUp(KeyCode.Space)) {
            CambiarDireccion();
        }
        transform.Translate(DireccionActual * velocidad * Time.deltaTime);
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Suelo") {
            StartCoroutine(BorrarSuelo(other.gameObject));
        }
        
    }

    IEnumerator BorrarSuelo(GameObject suelo) {
        float aleatorio = Random.Range(0.0f, 1.0f);
        if(aleatorio > 0.5f) {
            Valx += 6.0f;
        }
        else {
            Valz += 6.0f;
        }
        Instantiate(suelo, new Vector3(Valx, 0, Valz), Quaternion.identity);
        yield return new WaitForSeconds(2);
        suelo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        suelo.gameObject.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(2);
        Destroy(suelo);
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
}
