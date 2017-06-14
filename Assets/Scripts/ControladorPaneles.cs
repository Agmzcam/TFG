using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPaneles : MonoBehaviour {

    public GameObject panelPartida;
    public GameObject lienzo;
    public GameObject panelSimbolo;
    public GameObject panelJuego;
    public InputField inputNombrePartida;
    public InputField inputNombreSimbolo;
    public Text nombreSimbolo;
    public Text dibujaSimbolo;
    public Button validar;
    public Button descartar;

    private CreateStrokeMatrix createStrokeMatrixComponente;
    private Draw drawComponente;
    public static int contadorSimbolos;

    // Use this for initialization
    void Start()
    {
        panelPartida.SetActive(true);
        panelSimbolo.SetActive(false);
        panelJuego.SetActive(false);
        createStrokeMatrixComponente = lienzo.GetComponent<CreateStrokeMatrix>();
        drawComponente = GetComponent<Draw>();
        //createStrokeMatrixComponente.enabled = false;
        drawComponente.enabled = false;
        contadorSimbolos = 1;

    }

    //public void CambiarAPanelSimbolo()
    //{
    //    EjemploGuardar.nombre = inputNombrePartida.text;
    //    textoExplicativoSimbolo.text = "Introduce el nombre del símbolo " + contadorSimbolos;
    //    panelPartida.SetActive(false);
    //    panelSimbolo.SetActive(true);
    //    lienzo.gameObject.SetActive(false);
    //}

    public void ActivarDibujo (bool activar)
    {
        createStrokeMatrixComponente.enabled = activar;
        lienzo.gameObject.SetActive(true);
        drawComponente.enabled = activar;
    }

    public void CambiarADibujarSimbolo()
    {
        dibujaSimbolo.gameObject.SetActive(true);
        nombreSimbolo.gameObject.SetActive(false);
        validar.gameObject.SetActive(true);
        descartar.gameObject.SetActive(true);
        switch(inputNombreSimbolo.name)
        {
            case "BolaPapelIzq":
                EjemploGuardar.simboloBolaPapelIzq = inputNombreSimbolo.text;
                break;
            case "BolaPapelDcha":
                EjemploGuardar.simboloBolaPapelDcha = inputNombreSimbolo.text;
                break;
            case "Libreta":
                EjemploGuardar.simboloLibreta = inputNombreSimbolo.text;
                break;
        }
        inputNombreSimbolo.gameObject.SetActive(false);


    }
    public void CambiarAJuego()
    {
        panelPartida.SetActive(false);
        panelSimbolo.SetActive(false);
        panelJuego.SetActive(true);

    }

    public void CambiarANombreSimbolo()
    {
        dibujaSimbolo.gameObject.SetActive(false);
        nombreSimbolo.gameObject.SetActive(true);
        panelPartida.SetActive(false);
        panelSimbolo.SetActive(true);
        panelJuego.SetActive(false);
        validar.gameObject.SetActive(false);
        descartar.gameObject.SetActive(false);
        //inputNombreSimbolo.gameObject.SetActive(true);

        EliminarTrazo();
        /*GameObject[] drawGOArray = GameObject.FindGameObjectsWithTag("drawObject");
        foreach (GameObject dGO in drawGOArray)
        {
            Destroy(dGO);
        }*/
        
    }

    public void EliminarTrazo()
    {
        GameObject drawGO = GameObject.FindGameObjectWithTag("drawObject");
        Destroy(drawGO);
    }
}
