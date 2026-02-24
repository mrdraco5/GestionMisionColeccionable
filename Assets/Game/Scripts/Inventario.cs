using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventario : MonoBehaviour
{
    public DataManager dataManager;
    public GameObject itemPrefab;
    public Transform contentParent;

    void Start()
    {
        dataManager.CargarDatos();
        MostrarColeccionables();
    }

    public void MostrarColeccionables()
    {
        List<Coleccionable> lista = dataManager.listaColeccionables;

        foreach (Coleccionable coleccionable in lista)
        {
            GameObject nuevoItem = Instantiate(itemPrefab, contentParent);

            Text texto = nuevoItem.GetComponentInChildren<Text>();
            texto.text = coleccionable.nombre;
        }
    }
}