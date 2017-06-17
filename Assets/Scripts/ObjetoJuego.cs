using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjetoJuego {

    public string nombrePartida;
    public List<string> nombresSimbolos = new List<string>();
    public List<int[,]> matricesSimbolos = new List<int[,]>();
    public List<string> nombresGO = new List<string>();

    /*public ObjetoJuego(string nPartida)
    {
        nombrePartida = nPartida;
    }*/

    public void setPartida(string nSimbolo, int[,] matrizSimbolo, string nGO)
    {
        nombresSimbolos.Add(nSimbolo);
        matricesSimbolos.Add(matrizSimbolo);
        nombresGO.Add(nGO);
    }

    public void guardarPartida(string nombre)
    {
        nombrePartida = nombre;
        GestorPersistencia.guardarDatos(this);
    }
}
