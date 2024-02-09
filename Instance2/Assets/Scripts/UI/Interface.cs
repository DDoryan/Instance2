using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private TextMeshProUGUI _textAP;
    [SerializeField] private TextMeshProUGUI _textMP;
    [SerializeField] private List<Image> _perkList;
    private Color _color;
    private Color _colorWhite;
    private Player _player;

    void Start()
    {
        _color = Color.clear;
        _colorWhite = Color.white;
        StartUI();
        _playerManager.MovementEvent += RefreshAPUI;
        _playerManager.MovementEvent += RefreshMPUI;
        _playerManager.ActionEvent += RefreshInventoryUI;
        _playerManager.NavEvent += RefreshSelectedPerkUI;
        _playerManager.ChangePlayerEvent += RefreshCurrentInventoryUI;
    }

    private void StartUI()
    {
        for (int i= 0; i < _perkList.Count; i++)
        {
            _perkList[i].color = _color;
        }
    }
    void Update()
    {
        _player = _playerManager.GetPlayer();
    }

    private void RefreshInventoryUI()
    {
        for (int i = 0; i < _playerManager.GetPlayerPerkLimit(); i++)
        {
            if (_player.GetPerk(i) != null)
            {
                _perkList[i].overrideSprite = _player.GetPerk(i).CardSpriteGrave;
                _perkList[i].color = _colorWhite;
            }
        }
    }

    private void RefreshAPUI()
    {
        _textAP.text = _playerManager._actionPoints.ToString();
    }

    private void RefreshMPUI()
    {
        _textMP.text = _playerManager._magicPoints.ToString();
    }

    private void RefreshSelectedPerkUI()
    {
        for (int i = 0; i < _playerManager.GetPlayerPerkLimit(); i++)
        {
            if (i == _player.GetSelectedPerk())
            {
                if (_perkList[i].transform.localScale == Vector3.one)
                {
                    _perkList[i].transform.localScale *= 2;
                }
            }
            else
            {
                _perkList[i].transform.localScale = Vector3.one;
            }
        }
    }

    private void RefreshCurrentInventoryUI()
    {
        for (int i = 0; i < _perkList.Count; i++)
        {
            for (int j = 0; j < _playerManager.GetPlayerPerkLimit(); j++)
            {
                _perkList[i].color = _color;
            }
            if (_perkList[i].color == _color)
            {
                _perkList[i].color = _colorWhite;
            }
        }
    }
}
