using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorJugar : MonoBehaviour {

    public GameObject panelPartidas;
    public GameObject panelInGame;
    public GameObject partidaBoton;
    public GameObject partidaBotonPadre;

    private EjemploLeerFicheros ejemploLeerFicherosScript;

	// Use this for initialization
	void Start () {
        panelPartidas.SetActive(true);
        panelInGame.SetActive(false);
        ejemploLeerFicherosScript = GetComponent<EjemploLeerFicheros>();
        ejemploLeerFicherosScript.MostrarPartidas(partidaBoton, partidaBotonPadre);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
