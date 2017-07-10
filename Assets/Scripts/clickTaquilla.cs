using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickTaquilla : MonoBehaviour {

    public GameObject controlador;
    public GameObject lugarMovimientoInterruptor;
    public GameObject camara;

    private ControlCamara controlCamaraScript;
    private Transform puntoZoom;
    private ControladorJugar controladorJugarScript;
    // Use this for initialization
    void Start () {
        controladorJugarScript = controlador.GetComponent<ControladorJugar>();
        controlCamaraScript = camara.GetComponent<ControlCamara>();
        puntoZoom = transform.Find("pzoom");
    }

    void OnMouseDown()
    {
        print("click en la taquilla");
        if (!controlCamaraScript.zoom)
            StartCoroutine(controlCamaraScript.Zoom(puntoZoom.position));
        if (controladorJugarScript.taquillaAbierta && controladorJugarScript.tengoDestornillador)
        {
            this.gameObject.SetActive(false);
        }

    }

}
