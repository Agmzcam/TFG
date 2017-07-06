using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploGuardar : MonoBehaviour {


    private ObjetoJuego miPartida = new ObjetoJuego();
    //private int[,] mSimbolo = new int[3, 3];

    /* public static string nombre;
     public static string simboloBolaPapelIzq;
     public static string simboloBolaPapelDcha;
     public static string simboloLibreta;*/

    public void GuardarPartida(string nombre)
    {
        miPartida.guardarPartida(nombre);

    }

    public void GuardarSimbolo(string nSimbolo, int[,] matrizSimbolo)
    {
        miPartida.setPartida(nSimbolo, matrizSimbolo);
    }

    public int[,] SetMatriz(int[,] m)
    {
        int[,] mSimbolo = new int[m.GetLength(0), m.GetLength(1)];
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                mSimbolo[i, j] = m[i, j];
            }

        }

        return mSimbolo;

    }
}
