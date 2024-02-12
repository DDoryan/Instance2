using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textAP;
    [SerializeField] private TextMeshProUGUI _textMP;
    [SerializeField] private List<Image> _perkListP1;
    [SerializeField] private List<Image> _perkListP2;
    private Color _color;
    private Color _colorWhite;
    private Player _player;

    void Start()
    {
        _color = Color.clear;
        _colorWhite = Color.white;
        StartUI();
        PlayerManager.Instance.MovementEvent += RefreshAPUI;
        PlayerManager.Instance.MovementEvent += RefreshMPUI;
        PlayerManager.Instance.ActionEvent += RefreshInventoryUI;
        PlayerManager.Instance.NavEvent += RefreshSelectedPerkUI;
        PlayerManager.Instance.ExchangeEndEvent += StartUI;
        RefreshAPUI();
        RefreshMPUI();
    }

    private void StartUI()
    {
        for (int i = 0; i < _perkListP1.Count; i++)
        {
            _perkListP1[i].sprite = null;
            _perkListP1[i].color = _color;
        }
        for (int i = 0; i < _perkListP2.Count; i++)
        {
            _perkListP2[i].sprite = null;
            _perkListP2[i].color = _color;
        }
    }

    void Update()
    {
        _player = PlayerManager.Instance.GetPlayer();
    }

    private void RefreshInventoryUI()
    {
        for (int i = 0; i < PlayerManager.Instance.InventoryAmmount(0) && i < _perkListP1.Count; i++)
        {
            _perkListP1[i].sprite = PlayerManager.Instance.PlayerList[0].InventoryPlayer[i].CardSpriteGrave;
            _perkListP1[i].color = _colorWhite;
        }
        for (int i = 0; i < PlayerManager.Instance.InventoryAmmount(1) && i < _perkListP2.Count; i++)
        {
            _perkListP2[i].sprite = PlayerManager.Instance.PlayerList[1].InventoryPlayer[i].CardSpriteGrave;
            _perkListP2[i].color = _colorWhite;
        }
    }

    private void RefreshAPUI()
    {
        _textAP.text = PlayerManager.Instance._actionPoints.ToString();
    }

    private void RefreshMPUI()
    {
        _textMP.text = PlayerManager.Instance._magicPoints.ToString();
    }

    private void RefreshSelectedPerkUI()
    {
        if (PlayerManager.Instance.CurrentTurn() == 0)
        {
            for (int i = 0; i < PlayerManager.Instance.InventoryAmmount(0); i++)
            {
                if (i == PlayerManager.Instance.PlayerList[PlayerManager.Instance.CurrentTurn()].GetSelectedPerk())
                {
                    if (_perkListP1[i].transform.position.y == 0)
                        _perkListP1[i].transform.position = new Vector3(_perkListP1[i].transform.position.x, 160, 0);
                }
                else
                {
                    _perkListP1[i].transform.position = new Vector3(_perkListP1[i].transform.position.x, 0, 0);
                }
            }
        }
        else if (PlayerManager.Instance.CurrentTurn() == 1)
        {
            for (int i = 0; i < PlayerManager.Instance.InventoryAmmount(1); i++)
            {
                if (i == PlayerManager.Instance.PlayerList[PlayerManager.Instance.CurrentTurn()].GetSelectedPerk())
                {
                    if (_perkListP2[i].transform.position.y == 0)
                        _perkListP2[i].transform.position = new Vector3(_perkListP2[i].transform.position.x, 160, 0);
                }
                else
                {
                    _perkListP2[i].transform.position = new Vector3(_perkListP2[i].transform.position.x, 0, 0);
                }
            }
        }
    }
}
