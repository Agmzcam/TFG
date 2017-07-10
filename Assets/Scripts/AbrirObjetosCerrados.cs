using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirObjetosCerrados : MonoBehaviour {

    public GameObject puertaTaquilla;
    public GameObject claveEnTablet;
    public GameObject[] claveEnPared;
    public GameObject[] claveEnTaquilla;
    public GameObject claveAbrirTablet;
    public GameObject clavePicaporte;
    public Light luz;
	// Use this for initialization
	void Start () {
		
	}

    public void AbrirTaquilla()
    {
        puertaTaquilla.SetActive(false);
        foreach (GameObject go in claveEnTaquilla)
        {
            go.SetActive(false);
        }
    }

    public void ApagarLuz()
    {
        foreach (GameObject go in claveEnPared)
        {
            go.SetActive(true);
        }
 
        luz.intensity = 0;
        claveAbrirTablet.gameObject.SetActive(true);
    }

    public void EncenderLuz()
    {
        foreach (GameObject go in claveEnPared)
        {
            go.SetActive(false);
        }
        luz.intensity = 5.78f;
    }

    public void ActivarClavePuerta()
    {
        claveAbrirTablet.gameObject.SetActive(false);
        claveEnTablet.gameObject.SetActive(true);
        clavePicaporte.gameObject.SetActive(true);
    }
}
