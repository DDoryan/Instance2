using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{
    [SerializeField]
    private Case _case;

    [SerializeField]
    private int _numberOfCase;

    [SerializeField]
    private Vector3 _selectPos;

    [SerializeField]
    private int _id;


    private void Start()
    {

        MonoBehaviour script = _case.GetScript(_id);
        if (script != null)
        {
            // Faites quelque chose avec le script r�cup�r�
            Debug.Log("Script trouv� !");
        }
        else
        {
            Debug.LogError("Aucun script avec l'identifiant 1 trouv�.");
        }
    }
}
