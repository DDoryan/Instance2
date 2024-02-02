using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    /*private Board _board;
    private Ressources _ressources;
    private List<Asset> _assets;
    private int _assetsLimit;
    private bool _canOpenTombs;
    private int _cellOn;
    private int _selectedAsset;*/
    void Start()
    {
       //_cellOn = _board.GetStartCell;
    }

    void Update()
    {
        
    }

    public void OnMovementEnter(InputAction.CallbackContext context)
    {
        /*if (!HasFocus())
        {
            return;
        }
        switch (context.ReadValue<Vector2>().x)
        {
            case 1f:
                if (!_board.CellHasSomething())
                {
                    _cellOn += 1;
                    _ressources.actionPoints -= 1;
                }
                break;
            case -1f:
                if (!_board.CellHasSomething())
                {
                    _cellOn -= 1;
                    _ressources.actionPoints -= 1;
                }
                break;
        }
        switch (context.ReadValue<Vector2>().y)
        {
            case 1f:
                if (!_board.CellHasSomething())
                {
                    _cellOn += 15;
                    _ressources.actionPoints -= 1;
                }
                break;
            case -1f:
                if (!_board.CellHasSomething())
                {
                    _cellOn -= 15;
                    _ressources.actionPoints -= 1;
                }
                break;
        }*/
        print(context.ReadValue<Vector2>());
    }

    public void NavigateAssets(InputAction.CallbackContext context)
    {
        /*if ((_selectedAsset + context.ReadValue<Vector2>().x) <= _assetsLimit)
          {
                    _selectedAsset += context.ReadValue<Vector2>().x;  
          }*/
        print(context.ReadValue<Vector2>().x);
    }
}
