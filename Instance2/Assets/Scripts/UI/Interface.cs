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
        PlayerManager.playerManager.MovementEvent += RefreshAPUI;
        PlayerManager.playerManager.MovementEvent += RefreshMPUI;
        PlayerManager.playerManager.ActionEvent += RefreshInventoryUI;
        PlayerManager.playerManager.NavEvent += RefreshSelectedPerkUI;
        PlayerManager.playerManager.ChangePlayerEvent += RefreshCurrentInventoryUI;
    }

    private void StartUI()
    {
        RefreshAPUI();
        RefreshMPUI();
        for (int i = 0; i < _perkListP1.Count; i++)
        {
            _perkListP1[i].color = _color;
        }
        for (int i = 0; i < _perkListP2.Count; i++)
        {
            _perkListP2[i].color = _color;
        }
    }

    void Update()
    {
        _player = PlayerManager.playerManager.GetPlayer();
    }

    private void RefreshInventoryUI()
    {
        for (int i = 0; i < PlayerManager.playerManager.InventoryAmmount(0); i++)
        {
            if (PlayerManager.playerManager.GetArtifactByIndex(0) != null)
            {
                _perkListP1[i].sprite = PlayerManager.playerManager.GetInventory(i, 0);
                _perkListP1[i].color = _colorWhite;
            }
        }
        for (int i = 0; i < PlayerManager.playerManager.InventoryAmmount(1); i++)
        {
            {
                _perkListP2[i].sprite = PlayerManager.playerManager.GetInventory(i, 1);
                _perkListP2[i].color = _colorWhite;
            }
        }
    }

    private void RefreshAPUI()
    {
        _textAP.text = PlayerManager.playerManager._actionPoints.ToString();
    }

    private void RefreshMPUI()
    {
        _textMP.text = PlayerManager.playerManager._magicPoints.ToString();
    }

    private void RefreshSelectedPerkUI()
    {
        if (PlayerManager.playerManager.CurrentTurn() == 0)
        {

            for (int i = 0; i < PlayerManager.playerManager.InventoryAmmount(0); i++)
            {
                if (i == PlayerManager.playerManager.PlayerList[PlayerManager.playerManager.CurrentTurn()].GetSelectedPerk())
                {
                    if (_perkListP1[i].transform.position.y == 0)
                        _perkListP1[i].transform.position = new Vector3(_perkListP1[i].transform.position.x, 125, 0);
                }
                else
                {
                    _perkListP1[i].transform.position = new Vector3(_perkListP1[i].transform.position.x, 0, 0);
                }
            }
        }
        else if (PlayerManager.playerManager.CurrentTurn() == 1)
        {
            for (int i = 0; i < PlayerManager.playerManager.InventoryAmmount(1); i++)
            {
                if (i == PlayerManager.playerManager.PlayerList[PlayerManager.playerManager.CurrentTurn()].GetSelectedPerk())
                {
                    if (_perkListP2[i].transform.position.y == 0)
                        _perkListP2[i].transform.position = new Vector3(_perkListP2[i].transform.position.x, 125, 0);
                }
                else
                {
                    _perkListP2[i].transform.position = new Vector3(_perkListP2[i].transform.position.x, 0, 0);
                }
            }
        }

    }

    private void RefreshCurrentInventoryUI()
    {

    }
}
