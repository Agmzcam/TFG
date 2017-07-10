using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickClave : MonoBehaviour {

    public static bool clickEnClave = false;

    public GameObject controlador;
    private ControladorJugar controladorJugarScript;
	// Use this for initialization
	void Start () {
        controladorJugarScript = controlador.GetComponent<ControladorJugar>();
	}
	
    void OnMouseDown ()
    {
        if (!clickEnClave)
        {
            clickEnClave = true;
            //panelNegro.gameObject.SetActive(true);
            controladorJugarScript.IntroducirClave(this.gameObject);
        }

    }
}
