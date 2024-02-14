using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TheDeath : MonoBehaviour
{
    
}
public class Interface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textAP;
    [SerializeField] private TextMeshProUGUI _textMP;
    [SerializeField] private List<Image> _perkListP1;
    [SerializeField] private List<Image> _perkListP2;
    [SerializeField] private Transform _arrowPlayerTransform;
    [SerializeField] private Transform _arrowDeathTransform;
    private Color _color;
    private Color _colorWhite;
    private Player _player;
    private SpriteRenderer _spriteArrowDeathRenderer;
    private SpriteRenderer _spriteArrowPlayerRenderer;


    void Start()
    {
        _spriteArrowDeathRenderer = _arrowDeathTransform.GetComponent<SpriteRenderer>();
        _spriteArrowPlayerRenderer = _arrowPlayerTransform.GetComponent<SpriteRenderer>();    
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
        
        switch (GameManager.Instance.GetCurrentTurn())
        {
            case 0:
                
                _spriteArrowDeathRenderer.enabled = false;
                _spriteArrowPlayerRenderer.enabled = true;
                if (PlayerManager.Instance.CurrentTurn() == 0)
                {
                    _arrowPlayerTransform.position = new Vector3(0, 0 + 0.2f, 0); // ajouter le getter pour la position du player
                     
                }
                if (PlayerManager.Instance.CurrentTurn() == 1)
                {
                    _arrowPlayerTransform.position = new Vector3(0, 0 + 0.2f, 0);// ajouter le getter pour la position du player
                }
                break;
            case 1:
                _spriteArrowDeathRenderer.enabled = true;
                _spriteArrowPlayerRenderer.enabled = false;

                _arrowDeathTransform.position = new Vector3(0, 0 + 0.2f, 0); //ajouter la position de la mort a la place des 0
                break;
            case 2:
                _spriteArrowDeathRenderer.enabled = false;
                _spriteArrowPlayerRenderer.enabled = false;
                break;
            default:
                _spriteArrowDeathRenderer.enabled = false;
                _spriteArrowPlayerRenderer.enabled = false;
                break;
        }
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
        _textAP.text = "Action Points : " + PlayerManager.Instance._actionPoints.ToString();
    }

    private void RefreshMPUI()
    {
        _textMP.text = "Magic Points : " +PlayerManager.Instance._magicPoints.ToString();
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
