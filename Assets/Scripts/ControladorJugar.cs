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
    private CreateStrokeMatrix createStrokeMatrixComponente;
    private Draw drawComponente;

    // Use this for initialization
    void Start () {
        panelPartidas.SetActive(true);
        panelInGame.SetActive(false);
        ejemploLeerFicherosScript = GetComponent<EjemploLeerFicheros>();
        ejemploLeerFicherosScript.MostrarPartidas(partidaBoton, partidaBotonPadre);
        createStrokeMatrixComponente = GetComponent<CreateStrokeMatrix>();
        drawComponente = GetComponent<Draw>();
        createStrokeMatrixComponente.enabled = false;
        drawComponente.enabled = false;
    }
	
    public void CambiarAInGame()
    {
        panelInGame.SetActive(true);
        panelPartidas.SetActive(false);
        createStrokeMatrixComponente.enabled = true;
        drawComponente.enabled = true;
    }

}
