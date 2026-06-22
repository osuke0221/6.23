using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int missCount = 0;   // ミス回数
    public int maxMiss = 3;     // 3回でゲームオーバー

    void Awake()
    {
        instance = this;
    }

    public void Miss()
    {
        missCount++;

        Debug.Log("ミス回数: " + missCount);

        if (missCount >= maxMiss)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
