using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeCanvas : MonoBehaviour
{
    #region Canvas 
    [SerializeField]
    private GameObject _canvasToActivate;
    [SerializeField]
    private GameObject _canvasToDeactivate;
    #endregion

    [SerializeField]
    private List<Image> _imageExchangeP1List;

    [SerializeField]
    private List<Image> _imageExchangeP2List;

    [SerializeField]
    private Image _imageExchangeP1;
    [SerializeField]
    private Image _imageExchangeP2;

    private int _playerPlay;

    private void Awake()
    {
        //PlayerManager.playerManager.ExchangeEvent += ;
    }   

    private void GetSprite()
    {
        if(PlayerManager.playerManager.CurrentTurn() == 0)
        {
            for (int i = 0; i < _imageExchangeP1List.Count; i++)
            {
                _imageExchangeP1List[i].sprite = PlayerManager.playerManager.Get
            }
        }
    }

}
