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
    private Player _player;

    void Start()
    {
        _perkList = new List<Image>();
        _playerManager.MovementEvent += RefreshAPUI;
        _playerManager.MovementEvent += RefreshMPUI;
        _playerManager.ActionEvent += RefreshInventoryUI;
        _playerManager.ActionEvent += RefreshSelectedPerkUI;
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
                _perkList[i].transform.localScale *= 2;
            }
        }
    }
}
