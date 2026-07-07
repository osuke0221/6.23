using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("TowerDifence"); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("ƒQ[ƒ€I—¹"); 
    }
}
