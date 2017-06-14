using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploGuardar : MonoBehaviour {

    public int[,] matrizSimbolo1 = new int[3, 3];
    public int[,] matrizSimbolo2 = new int[3, 3];
    public int[,] matrizSimbolo3 = new int[3, 3];

    public static string nombre;
    public static string simboloBolaPapelIzq;
    public static string simboloBolaPapelDcha;
    public static string simboloLibreta;

    public void GuardarPartida()
    {
        ObjetoJuego miPartida = new ObjetoJuego(nombre);
        miPartida.setPartida(simboloBolaPapelIzq, matrizSimbolo1);
        miPartida.setPartida(simboloBolaPapelDcha, matrizSimbolo2);
        miPartida.setPartida(simboloLibreta, matrizSimbolo3);
        miPartida.guardarPartida();

    }
}
