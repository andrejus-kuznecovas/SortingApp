using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneController : MonoBehaviour
{

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void QuitApp()
    {
        Application.Quit();
    }
}
