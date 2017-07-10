using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInterruptor : MonoBehaviour {

    public GameObject controlador;

    private AbrirObjetosCerrados abrirObjetosCerradosScript;
    private bool luzEncendida = true;
	// Use this for initialization
	void Start () {
        abrirObjetosCerradosScript = controlador.GetComponent<AbrirObjetosCerrados>();
	}

    void OnMouseDown()
    {
        if (luzEncendida)
        {
            abrirObjetosCerradosScript.ApagarLuz();
            luzEncendida = false;
        }
        else {
            abrirObjetosCerradosScript.EncenderLuz();
            luzEncendida = true;
        }
    }

        // Update is called once per frame
    void Update () {
		
	}
}
