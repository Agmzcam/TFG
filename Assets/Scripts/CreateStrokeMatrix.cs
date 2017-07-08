using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class CreateStrokeMatrix : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private const int NCELLS = 10; // numero de filas y columnas de la matriz en la que se guardarán los datos y en las que se dividirá pantalla

    public int[,] matrix = new int[NCELLS, NCELLS]; // matriz de datos del dibujo
    public GameObject utilidadGuardar;
  
    private float cellsWidth;
    private float cellsHeigth;
    private RectTransform lienzoRectTransform;
    private int row, column; // coordenadas columna, fila
    private bool held;
    private bool dibujar;
    private bool hayTrazo;
    private Camera cam;
    private Vector3 mousePosition;
    private Vector3 prevPosition;
    private Vector3 endPosition;
    private Mesh drawMesh;
    public Material mat;
    private Draw drawScript;
    private ControladorPaneles controladorPanelesScript;
    private EjemploGuardar ejemploGuardarScript;
    private GameObject dibujo;


    private void Start () {
        lienzoRectTransform = GetComponent<RectTransform>();
        cellsWidth = lienzoRectTransform.rect.width / NCELLS; // ancho de cada celda
        cellsHeigth = lienzoRectTransform.rect.height / NCELLS; // alto de cada celda
        cam = GetComponent<Camera>();
        drawScript = utilidadGuardar.GetComponent<Draw>();
        drawMesh = new Mesh();
        //mat = new Material(Shader.Find("Sprites/Default"));
        held = false;
        dibujar = false;
        hayTrazo = false;
        InitializeMatrix();
	
	}

    private void InitializeMatrix()
    {
        for (int r = 0; r < NCELLS; r++)
        {
            for (int c = 0; c < NCELLS; c++)
            {
                matrix[r,c] = 0;
            }
        }
    }

    private int Mousex2Column (float coorX)
    {
        float origenX = lienzoRectTransform.offsetMin.x;
        //print("offsetMin: " + lienzoRectTransform.offsetMin);
        double v = (coorX - origenX) / cellsWidth;
        return (int)Math.Truncate(v);
    }

    private int Mousey2Row (float coorY)
    {
        float origenY = -lienzoRectTransform.offsetMax.y;
        //print("origen y: " + origenY);
        float coorY2 = Screen.height - coorY;
        double v = (coorY2 - origenY) / cellsHeigth;
        //print("v: " + v);
        //return (int)v;
       // print("truncate: " + (int)Math.Truncate(v));
        return (int)Math.Truncate(v);
    }

    private void CreateDrawObject()
    {
        GameObject drawObject = new GameObject("DrawObject");
        drawObject.layer = 8;
        drawObject.transform.parent = dibujo.transform;
        MeshFilter mf = drawObject.AddComponent<MeshFilter>();
        mf.mesh = drawMesh;
        MeshRenderer mr = drawObject.AddComponent<MeshRenderer>();
        mr.material = mat;
        drawObject.transform.position = Vector3.forward;
        drawMesh = new Mesh();
        hayTrazo = false;
    }

    public void CrearDibujoGO()
    {
        dibujo = new GameObject("Dibujo");
        dibujo.tag = "drawObject";
        dibujo.layer = 8;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        dibujar = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        dibujar = false;
    }

    public void GuardarSimbolo(string nSimbolo)
    {
        ejemploGuardarScript = utilidadGuardar.GetComponent<EjemploGuardar>();
        int[,] mS = ejemploGuardarScript.SetMatriz(matrix);
        ejemploGuardarScript.GuardarSimbolo(nSimbolo, mS);
        InitializeMatrix();
    }
    
    public void GuardarPartida(string nombre)
    {
        ejemploGuardarScript.GuardarPartida(nombre);
    }	
	private void Update () {

        if (Input.GetMouseButton(0) && dibujar)
        {

            hayTrazo = true;
            mousePosition = Input.mousePosition;
            row = Mousey2Row(mousePosition.y);
            column = Mousex2Column(mousePosition.x);
            //Debug.Log(" X = " + mousePosition.x + "--> " + column + " Y = " + mousePosition.y + "--> " + row);

            if (matrix[row, column] == 0)
            {
                matrix[row, column] = 1;
            }

            if (!held)
            {
                prevPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                held = true;
            }
            else
            {
                endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                drawScript.AddLineSegmentToDrawMesh(drawMesh, prevPosition, endPosition);
                prevPosition = endPosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            held = false;
            if (hayTrazo)
                CreateDrawObject();
        }

        Graphics.DrawMesh(drawMesh, Vector3.forward, Quaternion.identity, mat, 0);
	}

}
