using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EjemploLeerFicheros : MonoBehaviour {

    private string ficheroAbrir;
    private ObjetoJuego partida;
    private ControladorJugar controladorJugarScript;

	// Use this for initialization
	void Start () {
        controladorJugarScript = GetComponent<ControladorJugar>();
    }

    public void MostrarPartidas (GameObject botonPartida, GameObject botonPartidaPadre)
    {
        foreach (string file in System.IO.Directory.GetFiles(Application.persistentDataPath))
        {
            if (ficheroAbrir == null)
            {
                GameObject partida = Instantiate(botonPartida, botonPartidaPadre.transform);
                int contadorLetrasRuta = (Application.persistentDataPath + "/").Length;
                string nombre = file.Remove(0, contadorLetrasRuta); //quita ruta
                nombre = nombre.Remove(nombre.Length - 4, 4); //quita extensión
                partida.GetComponentInChildren<Text>().text = nombre;
                partida.GetComponent<Button>().onClick.AddListener(() => { LeerPartida(file); });
                partida.GetComponent<Button>().onClick.AddListener(controladorJugarScript.CambiarAInGame);
                Debug.Log(file);
            }
        }

    }

    private void LeerPartida(string fichero)
    {
        partida = GestorPersistencia.cargarDatos(fichero);

        Debug.Log(partida.nombrePartida);
        foreach (string nombreSimbolo in partida.nombresSimbolos)
        {
            Debug.Log(nombreSimbolo);
        }

        for (int matriz = 0; matriz < partida.matricesSimbolos.Count; matriz++)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Debug.Log(partida.matricesSimbolos[matriz][i, j]);
                }
            }
        }
    }
}
