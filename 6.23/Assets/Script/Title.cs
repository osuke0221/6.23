using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TitleScene : MonoBehaviour
{
    public AudioSource buttonSE;   // ボタンSE
    public Image fadeImage;        // フェード用黒画像

    public void StartGame()
    {
        // SE再生
        buttonSE.Play();

        // SEが終わるまで待ってからフェード開始
        StartCoroutine(WaitSEAndFade());
    }

    IEnumerator WaitSEAndFade()
    {
        // SEが鳴り終わるまで待つ
        while (buttonSE.isPlaying)
        {
            yield return null;
        }

        // SE終了後にフェードアウト
        yield return StartCoroutine(FadeAndStart());
    }

    IEnumerator FadeAndStart()
    {
        Color c = fadeImage.color;

        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            c.a = Mathf.Lerp(0, 1, t);
            fadeImage.color = c;
            yield return null;
        }

        SceneManager.LoadScene("CardGameMain");
    }
}
