using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Scene Menu")]
    [SerializeField] private string _playNameButton = "Play";
    [SerializeField] private string _menuNameButton = "Menu";

    [Header("Canvas Button")]
    private bool _victoryBool = false;
    private bool _defeatBool = false;
    [SerializeField] private GameObject _victoryGameObject;
    [SerializeField] private GameObject _defeatGameObject;

    [Header("GameControlleur GamePad")]
    [SerializeField] private Button _buttonVictory;
    [SerializeField] private Button _buttonDefeat;

    private bool _isGamePaused = false;

    private void Start()
    {
        _victoryBool = false;
        _defeatBool = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetVictoryBool(!_victoryBool);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetDefeatBool(!_defeatBool);
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

        // game pause
        if (_isGamePaused)
        {
            //Debug.Log("Time.timeScale set to pause");
            Time.timeScale = 0f;
        }
        else
        {
            //Debug.Log("Time.timeScale set to play");
            Time.timeScale = 1f;
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

    public void HudVictoryEnable()
    {
        _defeatBool = false;

        _victoryGameObject.SetActive(true);
        _defeatGameObject.SetActive(false);

        if (_buttonVictory != null && _buttonVictory.interactable)
        {
            _buttonVictory.Select();
        }

        _isGamePaused = true;
    }

    public void HudDefeatEnable()
    {
        _victoryBool = false;

        _victoryGameObject.SetActive(false);
        _defeatGameObject.SetActive(true);

        if (_buttonDefeat != null && _buttonDefeat.interactable)
        {
            _buttonDefeat.Select();
        }

        _isGamePaused = true;
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

        _isGamePaused = false;
    }

    public bool GetVicoryBool()
    {
        return _victoryBool;
    }

    public void SetVictoryBool(bool victoryArg)
    {
        _victoryBool = victoryArg;
    }

    public bool GetDefeatBool()
    {
        return _defeatBool;
    }

    public void SetDefeatBool(bool defeatArg)
    {
        _defeatBool = defeatArg;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}