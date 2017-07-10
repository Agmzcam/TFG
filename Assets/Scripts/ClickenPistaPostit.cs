using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickenPistaPostit : MonoBehaviour {
  

    public GameObject panelNegro;
    public GameObject pistaPostit;

    public static bool pistaAbierta = false;

	// Use this for initialization
	void Start () {
		
	}

    void OnMouseDown()
    {
        if (!pistaAbierta)
        {
            panelNegro.SetActive(true);
            pistaPostit.SetActive(true);
            pistaAbierta = true;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
