using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorJugar : MonoBehaviour {

    public GameObject panelPartidas;
    public GameObject panelInGame;
    public GameObject partidaBoton;
    public GameObject partidaBotonPadre;
    public GameObject lienzo;
    public GameObject pistaPostit;
    public GameObject pistaLibro;
    public GameObject pistaBola;
    public List<Text> textSimbolos;
    public GameObject imagenLienzo;

    private EjemploLeerFicheros ejemploLeerFicherosScript;
    private CreateStrokeMatrix createStrokeMatrixComponente;
    private Draw drawComponente;
    private List<ObjetoSimbolo> simbolos;
    private int[,] matrizCorrecta;
    private int celdas = 10;

    void Start () {
        panelPartidas.SetActive(true);
        panelInGame.SetActive(false);
        pistaBola.SetActive(false);
        pistaLibro.SetActive(false);
        pistaPostit.SetActive(false);
        ejemploLeerFicherosScript = GetComponent<EjemploLeerFicheros>();
        ejemploLeerFicherosScript.MostrarPartidas(partidaBoton, partidaBotonPadre);
        createStrokeMatrixComponente = lienzo.GetComponent<CreateStrokeMatrix>();
        drawComponente = GetComponent<Draw>();
        createStrokeMatrixComponente.enabled = false;
        drawComponente.enabled = false;
        imagenLienzo.SetActive(false);
        simbolos = new List<ObjetoSimbolo>();
        
    }

    public void CargarPartida(string fich)
    {
        pistaLibro.SetActive(true);
        panelPartidas.SetActive(false);
        panelInGame.SetActive(true);
        simbolos = ejemploLeerFicherosScript.LeerPartida(fich);
        List<string> nombreSimbolos = new List<string>();
        foreach (ObjetoSimbolo s in simbolos)
        {
            nombreSimbolos.Add(s.nombre);
        }
        List<string> listaSimbolosAleatrorizada = AleatorizarSimbolos(nombreSimbolos);
        for (int i = 0; i < listaSimbolosAleatrorizada.Count; i++)
        {
            textSimbolos[i].text = listaSimbolosAleatrorizada[i];
        }
    }

    private List<string> AleatorizarSimbolos(List<string> nombres) //luego serán sprites
    {
        //List<string> listaSimbolos = ejemploLeerFicherosScript.LeerPartida(fichero);
        for (int i = 0; i < nombres.Count; i++)
        {
            string temp = nombres[i];
            int indiceRandom = Random.Range(0, nombres.Count);
            nombres[i] = nombres[indiceRandom];
            nombres[indiceRandom] = temp;
        }
        return nombres;
    }

    public void IntroducirClave (Button objeto)
    {
        Sprite clave = objeto.GetComponentInChildren<SpriteRenderer>().sprite; //imágenes de la clave
        GameObject pista = GameObject.Find(clave.name); // buscar la pista que tiene esa imagen
        string n = pista.GetComponentInChildren<Text>().text;
        matrizCorrecta = simbolos.Find(s => s.nombre == n).matriz;
        panelInGame.SetActive(false);
        lienzo.SetActive(true);
        drawComponente.enabled = true;
        createStrokeMatrixComponente.enabled = true;
        createStrokeMatrixComponente.CrearDibujoGO();
        imagenLienzo.SetActive(true);
    }

    public void ComprobarDibujo()
    {
        int[,] m = new int[celdas, celdas];
        for (int f = 0; f < celdas; f++)
        {
            for (int c = 0; c < celdas; c++)
            {
                m[f, c] = createStrokeMatrixComponente.matrix[f, c];
            }
        }
        print("comprobando dibujo");
        float aciertos = CalcularPorcentajeAciertos(m);
        if (aciertos > 90)
        {
            print("es correcto");
            createStrokeMatrixComponente.ResetMatriz();
        }
    }

    public float CalcularPorcentajeAciertos (int [,] matrizJugador)
    {
        print("calculando porcentaje de aciertos");
        float porcentajeMaximoAciertos = 0;
        string nombreSimboloCercano = "";
        float aciertosActuales;
        for (int matriz = 0; matriz < simbolos.Count; matriz++)
        {
            aciertosActuales = SumaAciertosMultiplicacion(matrizJugador, simbolos[matriz].matriz);
            if (aciertosActuales > porcentajeMaximoAciertos)
            {
                porcentajeMaximoAciertos = aciertosActuales;
                nombreSimboloCercano = simbolos[matriz].nombre;
                print("porcentaje maximo de aciertos: " + porcentajeMaximoAciertos);
                print("por ahora se acerca más a símbolo: " + nombreSimboloCercano);
            }
           
        }

        return porcentajeMaximoAciertos;
    }

    public float SumaAciertosMultiplicacion(int[,]m1, int[,]m2)
    {
        print("en sumaaciertos multiplicacion");
        int[,] multiplicacion = new int[celdas, celdas];
        int columna = 0;
        int resultado = 0;
        int f = 0;
        float aciertos = 0;
        while (f < celdas)
        {
            for (int c = 0; c < celdas; c++)
            {
                resultado += m1[f, c] * m2[c, columna];
            }
            multiplicacion[f, columna] = resultado;
            resultado = 0;
            if (columna == celdas-1)
            {
                columna = 0;
                f++;
            }
            else
            {
                columna += 1;
            }

        }
       
        for (int fi = 0; fi < celdas; fi++)
        {
            for (int c = 0; c < celdas; c++)
            {
                if (multiplicacion[fi, c] != 1)
                {
                    aciertos += multiplicacion[fi,c];
                }
                    
            }
        }
        return aciertos;
    }

}
