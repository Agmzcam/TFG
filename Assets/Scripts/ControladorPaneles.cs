using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPaneles : MonoBehaviour {

    public GameObject panelPartida;
    public GameObject lienzo;
    public GameObject panelSimbolo;
    public GameObject panelInstrucciones;
    public GameObject imagenLienzo; //imagen de papel
    public InputField inputNombrePartida;
    public InputField inputNombreSimbolo;
    public Text nombreSimbolo;
    public Text dibujaSimbolo;
    public Button validar;
    public Button descartar;
    public Button siguiente;
    public Button anterior;
    public Button borrar;
    
    private CreateStrokeMatrix createStrokeMatrixComponente;
    private Draw drawComponente;
    private int contadorSimbolo;

    // Use this for initialization
    void Start()
    {
        contadorSimbolo = 1;
        panelInstrucciones.SetActive(true);
        panelPartida.SetActive(false);
        panelSimbolo.SetActive(false);
        imagenLienzo.SetActive(false);
        createStrokeMatrixComponente = lienzo.GetComponent<CreateStrokeMatrix>();
        createStrokeMatrixComponente.enabled = false;
        drawComponente = GetComponent<Draw>();
        drawComponente.enabled = false;
        validar.gameObject.SetActive(false);
        descartar.gameObject.SetActive(false);
        siguiente.gameObject.SetActive(false);
        borrar.gameObject.SetActive(false);

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
        dibujaSimbolo.text = "DIBUJA EL SÍMBOLO " + contadorSimbolo;
        dibujaSimbolo.gameObject.SetActive(true);
        nombreSimbolo.gameObject.SetActive(false);
        imagenLienzo.SetActive(true);
        ActivarDibujo(true);
        inputNombreSimbolo.gameObject.SetActive(false);
    }

    public void SimboloSiguiente ()
    {
        createStrokeMatrixComponente.GuardarSimbolo(inputNombreSimbolo.text);
        contadorSimbolo++;
        CambiarANombreSimbolo();
    }

    public void SimboloAnterior ()
    {
        contadorSimbolo--;
        CambiarANombreSimbolo();
    }

    public void CambiarANombreSimbolo()
    {
        borrar.gameObject.SetActive(true);
        EliminarTrazo();
        inputNombreSimbolo.text = "";
        panelPartida.SetActive(false);
        panelSimbolo.SetActive(true);
        panelInstrucciones.SetActive(false);
        imagenLienzo.SetActive(true);
        inputNombreSimbolo.gameObject.SetActive(true);
        dibujaSimbolo.gameObject.SetActive(false);
        nombreSimbolo.text = "INTRODUCE EL NOMBRE DEL SÍMBOLO " + contadorSimbolo;
        nombreSimbolo.gameObject.SetActive(true);
        ActivarDibujo(false);
        
    }

    public void CambiarANombrePartida()
    {
        panelPartida.SetActive(true);
        panelSimbolo.SetActive(false);
        imagenLienzo.SetActive(false);
    }
    public void Borrar()
    {
        EliminarTrazo();
        createStrokeMatrixComponente.CrearDibujoGO();
    }

    public void EliminarTrazo()
    {
        GameObject drawGO = GameObject.FindGameObjectWithTag("drawObject");
        if (drawGO)
            Destroy(drawGO);
    }

    public void Validar()
    {
        createStrokeMatrixComponente.GuardarSimbolo(inputNombreSimbolo.text);    
        EliminarTrazo();
        CambiarANombrePartida();
    }

    public void GuardarPartida()
    {
        createStrokeMatrixComponente.GuardarPartida(inputNombrePartida.text);
    }

    void Update()
    {
        if (GameObject.Find("DrawObject") && contadorSimbolo != 12)
        {
            siguiente.gameObject.SetActive(true);
        }
        else
        {
            siguiente.gameObject.SetActive(false);
            if (GameObject.Find("DrawObject")) {
                validar.gameObject.SetActive(true);
                descartar.gameObject.SetActive(true);
            }
            else
            {
                validar.gameObject.SetActive(false);
                descartar.gameObject.SetActive(false);
            }
        }

        if (contadorSimbolo > 1)
        {
            anterior.gameObject.SetActive(true);
        }

        else
        {
            anterior.gameObject.SetActive(false);
        }
    }
}
