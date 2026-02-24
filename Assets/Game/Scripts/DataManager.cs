using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    public List<Coleccionable> listaColeccionables = new List<Coleccionable>();
    public Stack<Mision> misionesStack = new Stack<Mision>();
    private GameData gameData;

    void Start()
    {
        CargarDatos();
    }

    public void CargarDatos()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("GameData");

        if (jsonFile == null)
        {
            Debug.LogError("No se encontró GameData en Resources");
            return;
        }

        gameData = JsonUtility.FromJson<GameData>(jsonFile.text);
        listaColeccionables = gameData.coleccionables;
        misionesStack.Clear();

        for (int i = gameData.misiones.Count - 1; i >= 0; i--)
        {
            misionesStack.Push(gameData.misiones[i]);
        }

        Debug.Log("Datos cargados correctamente");
    }

    public Coleccionable BuscarColeccionablePorNombre(string nombre)
    {
        return listaColeccionables.Find(c => c.nombre == nombre);
    }

    public Mision ObtenerMisionActual()
    {
        if (misionesStack.Count > 0)
            return misionesStack.Peek();
        else
            return null;
    }

    public void CompletarMision()
    {
        if (misionesStack.Count > 0)
        {
            Mision completada = misionesStack.Pop();
            Debug.Log("Misión completada: " + completada.titulo);
        }
        else
        {
            Debug.Log("No hay más misiones.");
        }
    }
}