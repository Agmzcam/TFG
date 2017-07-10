using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickEnLocker : MonoBehaviour {

    public GameObject camara;


    private ControlCamara controlCamaraScript;
    private Transform puntoZoom;
    private ControladorJugar controladorJugarScript;

    // Use this for initialization
    void Start () {
        controlCamaraScript = camara.GetComponent<ControlCamara>();
        puntoZoom = transform.Find("pzoom");
    }


    void OnMouseDown()
    {
        print("click en la taquilla");
        if (!controlCamaraScript.zoom)
            StartCoroutine(controlCamaraScript.Zoom(puntoZoom.position));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
