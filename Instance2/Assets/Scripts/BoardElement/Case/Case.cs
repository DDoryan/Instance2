using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Case : MonoBehaviour
{
    protected Dictionary<int, MonoBehaviour> scripts = new Dictionary<int, MonoBehaviour>();

    protected void AddToList(int id, MonoBehaviour script)
    {
        scripts.Add(id, script);
    }

    public MonoBehaviour GetScript(int id)
    {
        if (scripts.ContainsKey(id))
        {
            return scripts[id];

        }
        else
            return null;
    }

}
