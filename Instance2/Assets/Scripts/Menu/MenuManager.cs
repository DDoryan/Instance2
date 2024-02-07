using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Scene Menu")]
    [SerializeField] private string _playNameButton   = "Play";
    [SerializeField] private string _menuNameButton   = "Menu";

    [Header("Canvas Button")]
    private bool _victoryBool  = false;
    private bool _defeatBool   = false;
    [SerializeField] private GameObject _victoryGameObject;
    [SerializeField] private GameObject _defeatGameObject;

    [Header("GameControlleur GamePad")]
    [SerializeField] private Button _buttonVictory;
    [SerializeField] private Button _buttonDefeat;

    private void Start()
    {
        _victoryBool = false;
        _defeatBool = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!_victoryBool)
            {
                _victoryBool = true;
            }
            else
            {
                _victoryBool = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_defeatBool)
            {
                _defeatBool = true;
            }
            else
            {
                _defeatBool = false;
            }
        }

        if (_victoryBool)
        {
            HudVictoryEnable();
        }
        else if (_defeatBool)
        {
            HudDefeatEnable();
        }
        else
        {
            HudMenuDisable();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/" + _playNameButton);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/" + _menuNameButton);
    }
    
    private void HudVictoryEnable()
    {
        _defeatBool = false;

        _victoryGameObject.SetActive(true);
        _defeatGameObject.SetActive(false);

        if (_buttonVictory != null && _buttonVictory.interactable)
        {
            _buttonVictory.Select();
        }
    }
    
    private void HudDefeatEnable()
    {
        _victoryBool = false;

        _victoryGameObject.SetActive(false);
        _defeatGameObject.SetActive(true);

        if (_buttonDefeat != null && _buttonDefeat.interactable)
        {
            _buttonDefeat.Select();
        }
    }

    private void HudMenuDisable()
    {
        _victoryGameObject.SetActive(false);
        _defeatGameObject.SetActive(false);

        if (_buttonVictory != null)
        {
            _buttonVictory.OnDeselect(null);
        }
        if (_buttonDefeat != null)
        {
            _buttonDefeat.OnDeselect(null);
        }
    }

    public bool GetVicoryBool()
    {
        return _victoryBool;
    }

    public bool SetVictoryBool(bool victoryArg)
    {
        _victoryBool = victoryArg;
        return _victoryBool;
    }
    
    public bool GetDefeatBool()
    {
        return _defeatBool;
    }

    public bool SetDefeatBool(bool defeatArg)
    {
        _defeatBool = defeatArg;
        return _defeatBool;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}