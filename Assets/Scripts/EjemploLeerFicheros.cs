using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploLeerFicheros : MonoBehaviour {

    private string ficheroAbrir;
    private ObjetoJuego partida;

	// Use this for initialization
	void Start () {
        foreach (string file in System.IO.Directory.GetFiles(Application.persistentDataPath))
        {
            if (ficheroAbrir == null) ficheroAbrir = file;
            Debug.Log(file);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            partida = GestorPersistencia.cargarDatos(ficheroAbrir);

            Debug.Log(partida.nombrePartida);
            foreach (string nombreSimbolo in partida.nombresSimbolos)
            {
                Debug.Log(nombreSimbolo);
            }

            for (int matriz = 0; matriz < partida.matricesSimbolos.Count; matriz++) {
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        Debug.Log(partida.matricesSimbolos[matriz][i, j]);
                    }
                }
            }


        }

    }
}
