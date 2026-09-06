using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CardGame : MonoBehaviour
{
    public TMP_Text playerAtkText;
    public TMP_Text enemyHpText;

    int playerAtk = 2;
    int enemyHP = 20;

    public CardDrawer cardDrawer;
    public SpriteRenderer enemyRenderer;
    public SpriteRenderer backgroundRenderer;

    public Sprite enemyWeak, enemyMid, enemyStrong, enemyBoss;
    public Sprite bgForest, bgFactory, bgCastle, bgBoss;

    // ★敵ごとにBGMを変える
    public AudioSource bgmSource;
    public AudioClip bgmWeak;
    public AudioClip bgmMid;
    public AudioClip bgmStrong;
    public AudioClip bgmBoss;

    // ★攻撃音 & バフ音
    public AudioSource attackSE;   // 攻撃ボタンを押した時
    public AudioSource buffSE;     // カードを押した時

    void Start()
    {
        GenerateEnemy();
        UpdateUI();
    }

    public void ApplyCard(string effect)
    {
        // ★カードを押した時のバフ音
        if (buffSE != null)
            buffSE.Play();

        if (effect == "x2") playerAtk *= 2;
        if (effect == "+5") playerAtk += 5;
        if (effect == "+8") playerAtk += 8;
        if (effect == "x3") playerAtk *= 3;
        if (effect == "-3") playerAtk -= 3;

        if (effect == "reset") playerAtk = 2;

        if (effect.StartsWith("R"))
        {
            int value = int.Parse(effect.Substring(1));
            playerAtk += value;
        }

        UpdateUI();
    }

    public void Attack()
    {
        // ★攻撃音
        if (attackSE != null)
            attackSE.Play();

        if (playerAtk == enemyHP)
        {
            playerAtk = 2;
            GenerateEnemy();
            UpdateUI();
        }
        else if (playerAtk > enemyHP)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void UpdateUI()
    {
        playerAtkText.text = playerAtk.ToString();
        enemyHpText.text = enemyHP.ToString();
    }

    void GenerateEnemy()
    {
        int[] hpStages = { 25, 50, 70, 100 };
        enemyHP = hpStages[Random.Range(0, hpStages.Length)];

        UpdateEnemyAppearance();
        enemyHpText.text = enemyHP.ToString();
    }

    void UpdateEnemyAppearance()
    {
        Sprite newBg;

        if (enemyHP == 25)
        {
            enemyRenderer.sprite = enemyWeak;
            newBg = bgForest;
            PlayBGM(bgmWeak);
        }
        else if (enemyHP == 50)
        {
            enemyRenderer.sprite = enemyMid;
            newBg = bgFactory;
            PlayBGM(bgmMid);
        }
        else if (enemyHP == 70)
        {
            enemyRenderer.sprite = enemyStrong;
            newBg = bgCastle;
            PlayBGM(bgmStrong);
        }
        else // 100
        {
            enemyRenderer.sprite = enemyBoss;
            newBg = bgBoss;
            PlayBGM(bgmBoss);
        }

        StartCoroutine(FadeBackground(newBg));
    }

    // ★BGM切り替え（フェード付き）
    void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip) return;
        StartCoroutine(FadeBGM(clip));
    }

    IEnumerator FadeBGM(AudioClip newClip)
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            bgmSource.volume = Mathf.Lerp(1, 0, t);
            yield return null;
        }

        bgmSource.clip = newClip;
        bgmSource.Play();

        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            bgmSource.volume = Mathf.Lerp(0, 1, t);
            yield return null;
        }
    }

    IEnumerator FadeBackground(Sprite newBg)
    {
        backgroundRenderer.color = new Color(1, 1, 1, 1);
        Color c = backgroundRenderer.color;

        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            c.a = Mathf.Lerp(1, 0, t);
            backgroundRenderer.color = c;
            yield return null;
        }

        backgroundRenderer.sprite = newBg;
        backgroundRenderer.color = new Color(1, 1, 1, 0);

        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            c.a = Mathf.Lerp(0, 1, t);
            backgroundRenderer.color = c;
            yield return null;
        }
    }
}
