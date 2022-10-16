using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hauptmenü : MonoBehaviour
{
    public Button StartButton;
    public Button Speed;
    void Start()
    {
        StartButton.onClick.AddListener(switchToGameScene);
        Speed.onClick.AddListener(switchToSpeedrunScene);
    }

   
    void switchToGameScene()
    {
        SceneManager.LoadScene(3);
    }
    void switchToSpeedrunScene()
    {
        SceneManager.LoadScene(2);
    }
    void Update()
    {
       
    }
}
