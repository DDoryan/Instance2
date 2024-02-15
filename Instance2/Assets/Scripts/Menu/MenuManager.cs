using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Scene Menu")]
    [SerializeField] private string _playNameButton = "Play";
    [SerializeField] private string _menuNameButton = "Menu";

    [Header("Canvas Button")]
    [SerializeField] private GameObject _victoryGameObject;
    [SerializeField] private GameObject _defeatGameObject;

    [Header("GameControlleur GamePad")]
    [SerializeField] private Button _buttonVictory;
    [SerializeField] private Button _buttonDefeat;

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
        print("win");
        _victoryGameObject.SetActive(true);
        _defeatGameObject.SetActive(false);

        if (_buttonVictory != null && _buttonVictory.interactable)
        {
            _buttonVictory.Select();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HudDefeatEnable()
    {
        print("dead");
        _victoryGameObject.SetActive(false);
        _defeatGameObject.SetActive(true);

        if (_buttonDefeat != null && _buttonDefeat.interactable)
        {
            _buttonDefeat.Select();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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

    public void ExitGame()
    {
        Application.Quit();
    }
}