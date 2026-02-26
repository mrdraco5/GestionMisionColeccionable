using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    // ============================
    // LISTA (Módulo 2 del PDF)
    // ============================
    public List<Coleccionable> listaColeccionables = new List<Coleccionable>();

    // ============================
    // PILA PRINCIPAL (Módulo 3)
    // ============================
    public Stack<Mision> misionesStack = new Stack<Mision>();

    // PILA PARA UNDO (obligatorio)
    public Stack<Mision> historialStack = new Stack<Mision>();

    private GameData gameData;

    // Se llama desde botón Cargar
    public void CargarDatos()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("GameData");

        if (jsonFile == null)
        {
            Debug.LogError("No se encontró GameData");
            return;
        }

        gameData = JsonUtility.FromJson<GameData>(jsonFile.text);

        listaColeccionables = gameData.coleccionables;

        misionesStack.Clear();
        historialStack.Clear();

        // Cargar pila en orden inverso
        for (int i = gameData.misiones.Count - 1; i >= 0; i--)
        {
            misionesStack.Push(gameData.misiones[i]);
        }
    }

    // Buscar usando Equals (el profe lo exige)
    public Coleccionable BuscarColeccionablePorNombre(string nombre)
    {
        foreach (Coleccionable c in listaColeccionables)
        {
            if (c.nombre.Equals(nombre))
            {
                return c;
            }
        }
        return null;
    }

    // Peek obligatorio
    public Mision ObtenerMisionActual()
    {
        if (misionesStack.Count > 0)
            return misionesStack.Peek();

        return null;
    }

    // Pop obligatorio
    public void CompletarMision()
    {
        if (misionesStack.Count > 0)
        {
            Mision completada = misionesStack.Pop();
            historialStack.Push(completada);
        }
    }

    // Undo obligatorio
    public void Revertir()
    {
        if (historialStack.Count > 0)
        {
            Mision ultima = historialStack.Pop();
            misionesStack.Push(ultima);
        }
    }
}