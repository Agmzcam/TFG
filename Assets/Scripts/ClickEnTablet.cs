using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEnTablet : MonoBehaviour {

    public GameObject controlador;
    public GameObject camara;
    
    public static bool mirandoTablet = false;
    private Transform puntoZoom;
    private ControlCamara controlCamaraScript;
    private ControladorJugar controladorJugarScript;
    // Use this for initialization
    void Start()
    {
        controladorJugarScript = controlador.GetComponent<ControladorJugar>();
        controlCamaraScript = camara.GetComponent<ControlCamara>();
        puntoZoom = transform.Find("pzoom");
    }

    void OnMouseDown()
    {
        if (!controlCamaraScript.zoom)
        {
            mirandoTablet = true;
            StartCoroutine(controlCamaraScript.Zoom(puntoZoom.position));
        }
            

    }
}
