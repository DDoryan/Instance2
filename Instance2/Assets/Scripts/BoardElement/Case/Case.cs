using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Case : MonoBehaviour
{
    private static Case instance;

    //dictionnaire des script pour les case
    protected Dictionary<int, Case> scripts = new Dictionary<int, Case>();

    protected static Case GetInstance() { return instance; }


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    //fonction qui ajoute les script au dictionnaire
    public void AddToDictionnary(int id, Case instance)
    {
        if (!scripts.ContainsKey(id))
        {
            scripts.Add(id, instance);
        }
        else
        {
            Debug.LogWarning("Il existe deja le script avec cette id");
        }

        Debug.Log("il y a : " + scripts.Count + " instance dans le dictionnaire");
    }

    public abstract void VariableChange(int id, string variable, object value);
}
