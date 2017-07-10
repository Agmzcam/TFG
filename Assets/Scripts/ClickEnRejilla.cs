using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEnRejilla : MonoBehaviour {

    public Text objetoEncontrado;
    public Button destornillador;
    public GameObject controlador;

    private Animator animatorTexto;
	// Use this for initialization
	void Start () {
        animatorTexto = objetoEncontrado.GetComponent<Animator>();
	}

    void OnMouseDown()
    {
        objetoEncontrado.gameObject.SetActive(true);
        animatorTexto.SetTrigger("aparecertxt");
        destornillador.gameObject.SetActive(true);
        Invoke("DesaparecerTexto", 1f);

    }

    private void DesaparecerTexto()
    {
        objetoEncontrado.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
