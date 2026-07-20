using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour
{
    // ゲーム終了ボタン
    public void QuitGame()
    {
        Application.Quit();

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // CardGameMain に戻るボタン
    public void BackToMain()
    {
        SceneManager.LoadScene("CardGameMain");
    }
}
