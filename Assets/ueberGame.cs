using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ueberGame : MonoBehaviour
{
    public Button Day;
    public Button Night;
    void Start()
    {
        Day.onClick.AddListener(GameDay);
        Night.onClick.AddListener(GameNight);
    }

    void GameDay()
    {
        SceneManager.LoadScene(1);
    }
    void GameNight()
    {
        SceneManager.LoadScene(2);
    }
}
