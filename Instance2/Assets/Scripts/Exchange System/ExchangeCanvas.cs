// Ignore Spelling: Desactivation,
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    #region ImageList
    [SerializeField]
    private List<Image> _imageExchangeP1List;

    [SerializeField]
    private List<Image> _imageExchangeP2List;
    #endregion

    #region ImageArtefactSelected
    [SerializeField]
    private Image _imageExchangeP1;
    [SerializeField]
    private Image _imageExchangeP2;
    #endregion

    private void Awake()
    {
        PlayerManager.playerManager.ExchangeEvent += OnActivation;
        PlayerManager.playerManager.NavEvent += NavigateInUIExchange;
    }

    public void OnActivation()
    {
        ActivateUI();
    }

    private void ActivateUI()
    {
        _canvasToActivate.SetActive(true);
        _canvasToDeactivate.SetActive(false);
        GetSprite();
    }

    public void OnDesactivation()
    {
        SetSprite();
    }


    private void GetSprite()
    {
        for (int i = 0; i < _imageExchangeP1List.Count && i < PlayerManager.playerManager.InventoryAmmount(0); i++)
        {
            _imageExchangeP1List[i].sprite = PlayerManager.playerManager.GetArtifactByIndex(i).CardSpriteGrave;
        }
        for (int i = 0; i < _imageExchangeP2List.Count && i < PlayerManager.playerManager.InventoryAmmount(1); i++)
        {
            _imageExchangeP2List[i].sprite = PlayerManager.playerManager.GetArtifactByIndex(i).CardSpriteGrave;
        }
    }

    public void NavigateInUIExchange()
    {
        for (int i = 0; i < PlayerManager.playerManager.InventoryAmmount(0); i++)
        {
            if (i == PlayerManager.playerManager.PlayerList[PlayerManager.playerManager.CurrentTurn()].GetSelectedPerk())
            {
                if (_imageExchangeP1List[i].transform.position.x != 0)
                    _imageExchangeP1List[i].transform.position = new Vector3(120, _imageExchangeP1List[i].transform.position.y, 0);
            }
            else
            {
                _imageExchangeP1List[i].transform.position = new Vector3(0, _imageExchangeP1List[i].transform.position.y, 0);
            }
        }

        for (int i = 0; i < PlayerManager.playerManager.InventoryAmmount(1); i++)
        {
            if (i == PlayerManager.playerManager.PlayerList[PlayerManager.playerManager.CurrentTurn()].GetSelectedPerk())
            {
                if (_imageExchangeP2List[i].transform.position.x != 0)
                    _imageExchangeP2List[i].transform.position = new Vector3(-120, _imageExchangeP2List[i].transform.position.y, 0);
            }
            else
            {
                _imageExchangeP2List[i].transform.position = new Vector3(0, _imageExchangeP2List[i].transform.position.x, 0);
            }
        }
    }


    private void SelectedArtefactToExchange()
    {
        if (_imageExchangeP1 == null)
        {
            _imageExchangeP1.sprite = PlayerManager.playerManager.GetArtifactByInput().CardSpriteGrave;
            _imageExchangeP1List[PlayerManager.playerManager.PlayerList[PlayerManager.playerManager.CurrentTurn()].SelectedPerk].sprite = null;
        }
        else if (_imageExchangeP2 == null)
        {
            _imageExchangeP2.sprite = PlayerManager.playerManager.GetArtifactByInput().CardSpriteGrave;
            _imageExchangeP2List[PlayerManager.playerManager.PlayerList[PlayerManager.playerManager.CurrentTurn()].SelectedPerk].sprite = null;
        }
    }

















    private void SetSprite()
    {
        for (int i = 0; i < _imageExchangeP1List.Count && i < PlayerManager.playerManager.InventoryAmmount(0); i++)
        {
            _imageExchangeP1List[i].sprite = PlayerManager.playerManager.GetArtifactByIndex(i).CardSpriteGrave;
        }


        for (int i = 0; i < _imageExchangeP2List.Count && i < PlayerManager.playerManager.InventoryAmmount(1); i++)
        {
            _imageExchangeP2List[i].sprite = PlayerManager.playerManager.GetArtifactByIndex(i).CardSpriteGrave;
        }
    }
}
