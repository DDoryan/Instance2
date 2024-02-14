// Ignore Spelling: Desactivation,
using System.Collections.Generic;
using TMPro;
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

    #region Bool

    private bool _p1Choose;
    private bool _p2Choose;


    #endregion

    #region Int

    private int _p1Turn = 0;
    private int _p2Turn = 1;

    [SerializeField]
    private List<int> _basePos = new List<int>();
    [SerializeField]
    private List<int> _selectedPos = new List<int>();


    #endregion

    #region Text
    [SerializeField]
    private TextMeshProUGUI _textPlayerTurn;

    [SerializeField]
    private GameObject _accetptanceText;

    #endregion

    #region Artifact Selected
    private Artefacte _artefacteP1;
    private Artefacte _artefacteP2;
    #endregion


    private Color _clear = Color.clear;
    private Color _white = Color.white;

    private void Start()
    {
        PlayerManager.Instance.ExchangeEvent += OnActivation;
        PlayerManager.Instance.NavEventExchange += NavigateInUIExchange;
        PlayerManager.Instance.RefreshUiAfterUse += GetSprite;
        PlayerManager.Instance.SelectedArtifactToExchangeEvent += SelectedArtefactToExchange;
        PlayerManager.Instance.ExchangeEndEvent += OnDesactivation;

        PlayerManager.Instance.ConfirmeExchangeEvent += ConfirmeText;
        PlayerManager.Instance.AccepteEventExchange += Accepte;
        PlayerManager.Instance.DeclineExchangeEvent += Decline;

        for (int i = 0; i < _imageExchangeP1List.Count; i++)
        {
            _imageExchangeP1List[i].color = _clear;
        }
        for (int i = 0; i < _imageExchangeP2List.Count; i++)
        {
            _imageExchangeP2List[i].color = _clear;
        }
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
        SetTextPlayer();
        SetBool();
        _artefacteP1 = null;
        _artefacteP2 = null;
        _imageExchangeP1.color = _clear;
        _imageExchangeP1.sprite = null;
        _imageExchangeP2.color = _clear;
        _imageExchangeP2.sprite = null;
    }

    public void OnDesactivation()
    {
        DesactiveUI();
    }

    private void DesactiveUI()
    {
        _canvasToActivate.SetActive(false);
        _canvasToDeactivate.SetActive(true);
        SetBool();
        SetSpriteOff();


    }

    private void SetTextPlayer()
    {
        _textPlayerTurn.text = PlayerManager.Instance.ExchangeTurn.ToString();
        _accetptanceText.SetActive(false);
    }


    private void SetBool()
    {
        _p1Choose = false;
        _p2Choose = false;
    }

    private void SetSpriteOff()
    {
        for (int i = 0; i < _imageExchangeP1List.Count; i++)
        {
            _imageExchangeP1List[i].sprite = null;
            _imageExchangeP1List[i].color = _clear;
        }
        for (int i = 0; i < _imageExchangeP2List.Count; i++)
        {
            _imageExchangeP2List[i].sprite = null;
            _imageExchangeP2List[i].color = _clear;
        }
    }




    private void GetSprite()
    {
        for (int i = 0; i < _imageExchangeP1List.Count && i < PlayerManager.Instance.InventoryAmmount(_p1Turn); i++)
        {
            _imageExchangeP1List[i].sprite = PlayerManager.Instance.PlayerList[0].InventoryPlayer[i].CardSpriteGrave;
            _imageExchangeP1List[i].color = _white;
        }
        for (int i = 0; i < _imageExchangeP2List.Count && i < PlayerManager.Instance.InventoryAmmount(_p2Turn); i++)
        {
            _imageExchangeP2List[i].sprite = PlayerManager.Instance.PlayerList[1].InventoryPlayer[i].CardSpriteGrave;
            _imageExchangeP2List[i].color = _white;
        }
    }


    public void NavigateInUIExchange()
    {
        List<Image>[] ImageList = new List<Image>[2]
        {
            _imageExchangeP1List,
            _imageExchangeP2List
        };

        List<int>[] PositionStart = new List<int>[2]
        {
            _basePos,
            _selectedPos
        };

        for (int i = 0; i < PlayerManager.Instance.InventoryAmmount(PlayerManager.Instance.ExchangeTurn); i++)
        {
            if (i == PlayerManager.Instance.PlayerList[PlayerManager.Instance.ExchangeTurn].SelectedPerk)
            {
                if (ImageList[PlayerManager.Instance.ExchangeTurn][i].transform.position.x == PositionStart[0][PlayerManager.Instance.ExchangeTurn])
                    ImageList[PlayerManager.Instance.ExchangeTurn][i].transform.position = new Vector3(PositionStart[1][PlayerManager.Instance.ExchangeTurn], ImageList[PlayerManager.Instance.ExchangeTurn][i].transform.position.y, 0);
            }
            else
            {
                ImageList[PlayerManager.Instance.ExchangeTurn][i].transform.position = new Vector3(PositionStart[0][PlayerManager.Instance.ExchangeTurn], ImageList[PlayerManager.Instance.ExchangeTurn][i].transform.position.y, 0);
            }
        }
    }


    private void SelectedArtefactToExchange()
    {
        if (!_p1Choose && !_p2Choose && _imageExchangeP1.sprite == null)
        {
            _imageExchangeP1.sprite = PlayerManager.Instance.PlayerList[PlayerManager.Instance.ExchangeTurn].ArtefactSelected.CardSpriteGrave;
            _imageExchangeP1.color = _white;
            _imageExchangeP1List[PlayerManager.Instance.PlayerList[PlayerManager.Instance.ExchangeTurn].SelectedPerk].sprite = null;
            _imageExchangeP1List[PlayerManager.Instance.PlayerList[PlayerManager.Instance.ExchangeTurn].SelectedPerk].color = _clear;
            PlayerManager.Instance.PlayerList[_p1Turn].SelectedPerk = 0;

            _artefacteP1 = PlayerManager.Instance.PlayerList[PlayerManager.Instance.ExchangeTurn].ArtefactSelected;
            PlayerManager.Instance.PlayerList[PlayerManager.Instance.ExchangeTurn].InventoryPlayer.Remove(_artefacteP1);
            PlayerManager.Instance.PlayerList[_p1Turn].ArtefactSelected = null;

            _p1Choose = true;
        }
        else if (!_p2Choose && _p1Choose && _imageExchangeP2.sprite == null)
        {
            _imageExchangeP2.sprite = PlayerManager.Instance.PlayerList[PlayerManager.Instance.ExchangeTurn].ArtefactSelected.CardSpriteGrave;

            _imageExchangeP2List[PlayerManager.Instance.PlayerList[PlayerManager.Instance.ExchangeTurn].SelectedPerk].sprite = null;
            _imageExchangeP2List[PlayerManager.Instance.PlayerList[PlayerManager.Instance.ExchangeTurn].SelectedPerk].color = _clear;

            PlayerManager.Instance.PlayerList[PlayerManager.Instance.ExchangeTurn].SelectedPerk = 0;
            _imageExchangeP2.color = _white;

            _artefacteP2 = PlayerManager.Instance.PlayerList[PlayerManager.Instance.ExchangeTurn].ArtefactSelected;
            PlayerManager.Instance.PlayerList[PlayerManager.Instance.ExchangeTurn].InventoryPlayer.Remove(_artefacteP2);

            PlayerManager.Instance.PlayerList[_p2Turn].ArtefactSelected = null;
            _p2Choose = true;
        }
    }

    private void ConfirmeText()
    {
        if(_p1Choose && _p2Choose)
        {
            _accetptanceText.SetActive(true);
        } 
    }

    private void Accepte()
    {
        PlayerManager.Instance.PlayerList[_p1Turn].InventoryPlayer.Add(_artefacteP2);
        PlayerManager.Instance.PlayerList[_p2Turn].InventoryPlayer.Add(_artefacteP1);
        PlayerManager.Instance.PlayerList[_p2Turn].InventoryPlayer.Remove(_artefacteP2);
        PlayerManager.Instance.PlayerList[_p1Turn].InventoryPlayer.Remove(_artefacteP1);
        OnDesactivation();
    }

    private void Decline()
    {
        PlayerManager.Instance.PlayerList[_p2Turn].InventoryPlayer.Add(_artefacteP2);
        PlayerManager.Instance.PlayerList[_p1Turn].InventoryPlayer.Add(_artefacteP1);
        OnDesactivation();
    }


}
