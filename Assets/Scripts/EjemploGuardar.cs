using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploGuardar : MonoBehaviour {

    public static int[,] matrizSimbolo1 = new int[100, 100];
    public static int[,] matrizSimbolo2 = new int[100, 100];
    public static int[,] matrizSimbolo3 = new int[100, 100];

    public static string nombre;
    public static string nombreSimbolo1;
    public static string nombreSimbolo2;
    public static string nombreSimbolo3;


    void Start () {
        /*nombre = "PartidaNacho2";
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
        }*/
    }
	
	/*void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ObjetoJuego miPartida = new ObjetoJuego(nombre);
            miPartida.setPartida(nombreSimbolo1, matrizSimbolo1);
            miPartida.setPartida(nombreSimbolo2, matrizSimbolo2);
            miPartida.setPartida(nombreSimbolo3, matrizSimbolo3);
            miPartida.guardarPartida();
        }


 
	}*/

    public void GuardarPartida()
    {
        ObjetoJuego miPartida = new ObjetoJuego(nombre);
        miPartida.setPartida(nombreSimbolo1, matrizSimbolo1);
        miPartida.setPartida(nombreSimbolo2, matrizSimbolo2);
        miPartida.setPartida(nombreSimbolo3, matrizSimbolo3);
        miPartida.guardarPartida();

    }
}
