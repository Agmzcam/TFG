using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EjemploLeerFicheros : MonoBehaviour {

    private string ficheroAbrir;
    private ObjetoJuego partida;
    private ControladorJugar controladorJugarScript;
    private int celdas = 10;

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
                partida.GetComponentInChildren<Text>().text = "-"+ nombre;
                partida.GetComponent<Button>().onClick.AddListener(() => { controladorJugarScript.CargarPartida(file); });
                Debug.Log(file);
            }
        }

    }

    public List<ObjetoSimbolo> LeerPartida(string fichero) // llamar desde controlador jugar, la lista será después de sprites
    {
        partida = GestorPersistencia.cargarDatos(fichero);
        List<ObjetoSimbolo> listaSimbolos = new List<ObjetoSimbolo>();
        Debug.Log(partida.nombrePartida);
        for (int simbolo = 0; simbolo < partida.nombresSimbolos.Count; simbolo++)
        {
            int[,] m = new int[celdas, celdas];
            for (int i = 0; i < celdas; i++)
            {
                for (int j = 0; j < celdas; j++)
                {
                    m[i, j] = partida.matricesSimbolos[simbolo][i, j];
                }
            }
            ObjetoSimbolo obS = new ObjetoSimbolo(partida.nombresSimbolos[simbolo], m);
            listaSimbolos.Add(obS);
        }
        return listaSimbolos;
        
        /*foreach (string nombreSimbolo in partida.nombresSimbolos)
        {
            int[,] m;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    m[i,j] = partida.matricesSimbolos[]
                }
            }
            ObjetoSimbolo obS = new ObjetoSimbolo();
            listaNombreSimbolos.Add(nombreSimbolo);
            //Debug.Log(nombreSimbolo);
        }/*
        return listaNombreSimbolos;

        /*for (int matriz = 0; matriz < partida.matricesSimbolos.Count; matriz++)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Debug.Log(partida.matricesSimbolos[matriz][i, j]);
                }
            }
        }*/
    }
}
