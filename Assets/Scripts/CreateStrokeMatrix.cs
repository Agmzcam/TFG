using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class CreateStrokeMatrix : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private const int NCELLS = 3; // numero de filas y columnas de la matriz en la que se guardarán los datos y en las que se dividirá pantalla

    public int[,] matrix = new int[NCELLS, NCELLS]; // matriz de datos del dibujo
    public GameObject utilidadGuardar;
  
    private float cellsWidth;
    private float cellsHeigth;
    private RectTransform lienzoRectTransform;
    private int row, column; // coordenadas columna, fila
    private bool held;
    private bool dibujar;
    private Camera cam;
    private Vector3 mousePosition;
    private Vector3 prevPosition;
    private Vector3 endPosition;
    private Mesh drawMesh;
    private Material mat;
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
        mat = new Material(Shader.Find("Sprites/Default"));
        held = false;
        dibujar = false;

        dibujo = new GameObject("Dibujo");
        dibujo.tag ="drawObject";
        dibujo.layer = 8;
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
        return (int)((coorX - origenX) / cellsWidth);
    }

    private int Mousey2Row (float coorY)
    {
        float origenY = -lienzoRectTransform.offsetMin.y;
        //print("origen y: " + origenY);
        float coorY2 = Screen.height - coorY;
        double v = (coorY2 + origenY) / cellsHeigth;
        return (int)v;
        //return Math.Truncate(v);
    }

    private void CreateDrawObject()
    {
        GameObject drawObject = new GameObject("DrawObject");
        //drawObject.tag = "drawObject";
        drawObject.layer = 8;
        drawObject.transform.parent = dibujo.transform;
        MeshFilter mf = drawObject.AddComponent<MeshFilter>();
        mf.mesh = drawMesh;
        MeshRenderer mr = drawObject.AddComponent<MeshRenderer>();
        mr.material = mat;
        drawObject.transform.position = Vector3.forward;

        drawMesh = new Mesh();

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        dibujar = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        dibujar = false;
    }

    public void GuardarMatrizSimbolo()
    {
        controladorPanelesScript = utilidadGuardar.GetComponent<ControladorPaneles>();
        ejemploGuardarScript = utilidadGuardar.GetComponent<EjemploGuardar>();
        bool fin = false;
        switch(ControladorPaneles.contadorSimbolos)
        {
            case 1:
                ejemploGuardarScript.matrizSimbolo1 = matrix;
                break;
            case 2:
                ejemploGuardarScript.matrizSimbolo2 = matrix;
                break;
            case 3:
                ejemploGuardarScript.matrizSimbolo3 = matrix;
                fin = true;
                break;
        }
        
        InitializeMatrix();
        if (fin)
            ejemploGuardarScript.GuardarPartida();
        else
        {
            controladorPanelesScript.ActivarDibujo(false);
            controladorPanelesScript.CambiarANombreSimbolo();
        }

    }

	
	private void Update () {

        if (Input.GetMouseButton(0) && dibujar)
        {
          
            mousePosition = Input.mousePosition;
            row = Mousey2Row(mousePosition.y);
            column = Mousex2Column(mousePosition.x);
            Debug.Log("Y = " + mousePosition.y + "--> " + row + " X = " + mousePosition.x + "--> " + column);

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
            CreateDrawObject();
        }

        Graphics.DrawMesh(drawMesh, Vector3.forward, Quaternion.identity, mat, 0);
	}

}
