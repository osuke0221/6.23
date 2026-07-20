using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardGame : MonoBehaviour
{
    public TMP_Text playerAtkText;
    public TMP_Text enemyHpText;

    int playerAtk = 2;
    int enemyHP = 20;

    public Button cardX2;
    public Button cardPlus5;
    public Button cardPlus8;
    public Button cardX3;

    void Start()
    {
        UpdateUI();
    }

    public void ApplyCard(string effect)
    {
        if (effect == "x2") playerAtk *= 2;
        if (effect == "+5") playerAtk += 5;
        if (effect == "+8") playerAtk += 8;
        if (effect == "x3") playerAtk *= 3;

        UpdateUI();
        DisableCard(effect);
    }

    void DisableCard(string effect)
    {
        if (effect == "x2") cardX2.interactable = false;
        if (effect == "+5") cardPlus5.interactable = false;
        if (effect == "+8") cardPlus8.interactable = false;
        if (effect == "x3") cardX3.interactable = false;
    }

    public void Attack()
    {
        if (playerAtk >= enemyHP)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            
        }
    }

    public void ResetGame()
    {
        playerAtk = 2;
        UpdateUI();

        cardX2.interactable = true;
        cardPlus5.interactable = true;
        cardPlus8.interactable = true;
        cardX3.interactable = true;
    }

    void UpdateUI()
    {
        playerAtkText.text = playerAtk.ToString();
        enemyHpText.text = enemyHP.ToString();
    }
}
