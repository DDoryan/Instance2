using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDeath : Entity
{
    [SerializeField] private BoardManager _boardManager;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TileManager _tileManager;
    [SerializeField] private Transform StartPosition;
    [SerializeField] private float _cellSize;
    private int _cellOn;
    public static TheDeath Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public override void StartRound()
    {
        //MoveTo(PathFinding());
        base.StartRound();
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
        this.transform.position = StartPosition.position;
    }

    /*private Vector3 PathFinding()
    {

    }*/

    private void MoveTo(Vector3 direction)
    {
        this.transform.position = this.transform.position + direction * _cellSize;
    }
}
