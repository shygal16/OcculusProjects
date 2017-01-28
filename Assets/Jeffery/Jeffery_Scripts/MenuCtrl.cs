using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCtrl : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        print(GameData.Instance.score);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
