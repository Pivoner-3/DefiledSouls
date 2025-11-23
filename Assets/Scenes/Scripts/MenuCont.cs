using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCont : MonoBehaviour
{
    public string _newGame;
    public void NewGame()
    {
        SceneManager.LoadScene(_newGame);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
