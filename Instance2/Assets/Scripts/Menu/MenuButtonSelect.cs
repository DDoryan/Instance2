using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonSelect : MonoBehaviour
{
    [SerializeField] private Button _primaryButton;
    
    void OnEnable()
    {
        _primaryButton.Select();
    }
}