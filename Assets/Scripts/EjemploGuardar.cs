using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploGuardar : MonoBehaviour {

    private string nombre;
    private string nombreSimbolo1;
    private string nombreSimbolo2;
    private string nombreSimbolo3;
    private bool[,] matrizSimbolo1 = new bool[100, 100];
    private bool[,] matrizSimbolo2 = new bool[100, 100];
    private bool[,] matrizSimbolo3 = new bool[100, 100];

    void Start () {
        nombre = "PartidaNacho2";
        nombreSimbolo1 = "Mi Simbolo 1";
        nombreSimbolo2 = "Mi Simbolo 2";
        nombreSimbolo3 = "Mi Simbolo 3";

        for (int i=0; i<100; i++)
        {
            for(int j = 0; j<100; j++){
                matrizSimbolo1[i, j] = (Random.value >= 0.5);
                matrizSimbolo2[i, j] = (Random.value >= 0.5);
                matrizSimbolo3[i, j] = (Random.value >= 0.5);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ObjetoJuego miPartida = new ObjetoJuego(nombre);
            miPartida.setPartida(nombreSimbolo1, matrizSimbolo1);
            miPartida.setPartida(nombreSimbolo2, matrizSimbolo2);
            miPartida.setPartida(nombreSimbolo3, matrizSimbolo3);
            miPartida.guardarPartida();
        }


 
	}
}
