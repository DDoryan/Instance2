using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Named Scene")]
    [SerializeField] private string _playClick = "Play";
    [SerializeField] private string _menuClick = "Menu";
    [SerializeField] private string _victoryClick = "Victory";
    [SerializeField] private string _defeatClick = "Defeat";

    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/" + _playClick);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/" + _menuClick);
    }
    
    public void VictoryGame()
    {
        SceneManager.LoadScene("Scenes/" + _victoryClick);

    }

    public void DefeatGame()
    {
        SceneManager.LoadScene("Scenes/" + _defeatClick);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}