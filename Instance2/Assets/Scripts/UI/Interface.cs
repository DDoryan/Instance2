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
    [SerializeField] private Image _Perk1;
    [SerializeField] private Image _Perk2;
    [SerializeField] private Image _Perk3;
    private Player _player;

    void Start()
    {
        _playerManager.ActionEvent += RefreshAPUI;
        _playerManager.ActionEvent += RefreshMPUI;
        _playerManager.ActionEvent += RefreshInventoryUI;
        _playerManager.ActionEvent += RefreshSelectedPerkUI;
    }


    void Update()
    {
        _player = _playerManager.GetPlayer();
    }

    private void RefreshInventoryUI()
    {
        //_Perk1.overrideSprite = _player.GetPerk(1).CardSpriteGrave;
        //_Perk2.overrideSprite = _player.GetPerk(2).CardSpriteGrave;
        //_Perk3.overrideSprite = _player.GetPerk(3).CardSpriteGrave;
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
        switch (_player.GetSelectedPerk())
        {
            case 1:
                _Perk1.transform.localScale *= 2;
                print("perk1");
                break;
            case 2:
                _Perk2.transform.localScale *= 2;
                print("perk2");
                break;
            case 3:
                _Perk3.transform.localScale *= 2;
                print("perk3");
                break;
            default:
                print("none");
                break;
        }
    }
}
