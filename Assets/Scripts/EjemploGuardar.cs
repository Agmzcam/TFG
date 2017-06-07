using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploGuardar : MonoBehaviour {

    public int[,] matrizSimbolo1 = new int[3, 3];
    public int[,] matrizSimbolo2 = new int[3, 3];
    public int[,] matrizSimbolo3 = new int[3, 3];

    public static string nombre;
    public static string nombreSimbolo1;
    public static string nombreSimbolo2;
    public static string nombreSimbolo3;

    public void GuardarPartida()
    {
        ObjetoJuego miPartida = new ObjetoJuego(nombre);
        miPartida.setPartida(nombreSimbolo1, matrizSimbolo1);
        miPartida.setPartida(nombreSimbolo2, matrizSimbolo2);
        miPartida.setPartida(nombreSimbolo3, matrizSimbolo3);
        miPartida.guardarPartida();

    }
}
