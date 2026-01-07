using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void StartGame(string GameScene)
    {
        SceneManager.LoadScene(GameScene);
    }
    // Метод для кнопки "Выход"
    public void OnExitButtonClick()
    {
        Debug.Log("Игра завершена");
        Application.Quit();
    }
}
