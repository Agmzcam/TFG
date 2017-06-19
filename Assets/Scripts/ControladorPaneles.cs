using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPaneles : MonoBehaviour {

    public GameObject panelPartida;
    public GameObject lienzo;
    public GameObject panelSimbolo;
    public GameObject panelJuego;
    public GameObject imagenLienzo; //imagen de papel
    public InputField inputNombrePartida;
    public InputField inputNombreSimbolo;
    public Text nombreSimbolo;
    public Text dibujaSimbolo;
    public Button validar;
    public Button descartar;
    

    private CreateStrokeMatrix createStrokeMatrixComponente;
    private Draw drawComponente;
    private Button objetoSeleccionado;

    // Use this for initialization
    void Start()
    {
        panelPartida.SetActive(false);
        panelSimbolo.SetActive(false);
        panelJuego.SetActive(true);
        imagenLienzo.SetActive(false);
        createStrokeMatrixComponente = lienzo.GetComponent<CreateStrokeMatrix>();
        drawComponente = GetComponent<Draw>();
        drawComponente.enabled = false;

    }

    public void ActivarDibujo (bool activar)
    {
        createStrokeMatrixComponente.enabled = activar;
        drawComponente.enabled = activar;
        if (activar)
        {
            createStrokeMatrixComponente.CrearDibujoGO();
        }

}

    public void CambiarADibujarSimbolo()
    {
        dibujaSimbolo.gameObject.SetActive(true);
        nombreSimbolo.gameObject.SetActive(false);
        imagenLienzo.SetActive(true);
        ActivarDibujo(true);
        validar.gameObject.SetActive(true);
        descartar.gameObject.SetActive(true);
        inputNombreSimbolo.gameObject.SetActive(false);
    }

    public void CambiarAJuego()
    {
        panelPartida.SetActive(false);
        panelSimbolo.SetActive(false);
        panelJuego.SetActive(true);
        imagenLienzo.SetActive(false);
        ActivarDibujo(false);

    }

    public void CambiarANombreSimbolo(Button b)
    {
        panelPartida.SetActive(false);
        panelSimbolo.SetActive(true);
        panelJuego.SetActive(false);
        imagenLienzo.SetActive(true);
        inputNombreSimbolo.gameObject.SetActive(true);
        dibujaSimbolo.gameObject.SetActive(false);
        nombreSimbolo.gameObject.SetActive(true);
        ActivarDibujo(false);
        validar.gameObject.SetActive(false);
        descartar.gameObject.SetActive(false);
        objetoSeleccionado = b;
        
    }

    public void CambiarANombrePartida()
    {
        panelPartida.SetActive(true);
        panelSimbolo.SetActive(false);
        panelJuego.SetActive(false);
    }

    public void EliminarTrazo()
    {
        GameObject drawGO = GameObject.FindGameObjectWithTag("drawObject");
        Destroy(drawGO);
    }

    public void Validar()
    {
        createStrokeMatrixComponente.GuardarSimbolo(inputNombreSimbolo.text, objetoSeleccionado.name);
        EliminarTrazo();
    }

    public void GuardarPartida()
    {
        createStrokeMatrixComponente.GuardarPartida(inputNombrePartida.text);
    }
}
