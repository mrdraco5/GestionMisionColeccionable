using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Inventario : MonoBehaviour
{
    public DataManager dataManager;
    public GameObject itemPrefab;
    public Transform contentParent;

    void Start()
    {
        MostrarColeccionables();
    }

    public void MostrarColeccionables()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        List<Coleccionable> lista = dataManager.listaColeccionables;

        foreach (Coleccionable coleccionable in lista)
        {
            GameObject nuevoItem = Instantiate(itemPrefab, contentParent);

            TextMeshProUGUI texto = nuevoItem.GetComponentInChildren<TextMeshProUGUI>();

            if (texto != null)
            {
                texto.text = coleccionable.nombre;
            }
            else
            {
                Debug.LogError("No se encontró TextMeshProUGUI en el prefab");
            }
        }
    }
}