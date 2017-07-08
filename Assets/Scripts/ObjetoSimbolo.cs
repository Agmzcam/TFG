using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoSimbolo {

    public string nombre;
    public int[,] matriz;

    public ObjetoSimbolo (string nombreS, int[,] matrizS)
    {
        nombre = nombreS;
        matriz = matrizS;
    }
}
