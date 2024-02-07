using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDeath : MonoBehaviour
{
    private TileManager _tileManager;
    private GameManager _gameManager;
    private int _cellOn;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _tileManager = _tileManager.Instance();
    }

    private void FixedUpdate()
    {
        if (_gameManager.GetCurrentTurn() == 2)
        {
            DeathSpawn();
        }
    }

    private void DeathSpawn()
    {
    }

    private void PathFinding()
    {

    }

    private void MoveTo()
    {
    }
}
