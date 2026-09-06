using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDrawer : MonoBehaviour
{
    public Button[] cardButtons;
    public CardGame cardGame;

    // 通常カード
    string[] normalPool = { "x2", "+5", "+8", "x3", "-3", "reset" };

    // レアカード抽選
    string DrawEffect()
    {
        // ★レアカードは 10% の確率で出る
        if (Random.Range(0, 100) < 10)
        {
            int rareValue = Random.Range(1, 10); // 1〜9
            return "R" + rareValue; // 例：R7
        }

        // 通常カード
        return normalPool[Random.Range(0, normalPool.Length)];
    }

    public void DrawCards()
    {
        // 攻撃力リセットを廃止（新ルール）
        // cardGame.ResetPlayerAtk(); ← 削除

        for (int i = 0; i < cardButtons.Length; i++)
        {
            int index = i;

            string effect = DrawEffect();

            cardButtons[index].GetComponentInChildren<TMP_Text>().text = effect;
            cardButtons[index].image.color = GetColor(effect);

            cardButtons[index].onClick.RemoveAllListeners();
            cardButtons[index].onClick.AddListener(() =>
            {
                cardGame.ApplyCard(effect);
                cardButtons[index].interactable = false;
            });

            cardButtons[index].interactable = true;
        }
    }

    Color GetColor(string effect)
    {
        if (effect.StartsWith("R"))
            return new Color(1f, 0.85f, 0f); // 金色（レア）

        switch (effect)
        {
            case "x2": return Color.red;
            case "+5": return new Color(1f, 0.5f, 0f);
            case "+8": return Color.green;
            case "x3": return new Color(0.6f, 0f, 1f);
            case "-3": return Color.black;
            case "reset": return Color.cyan; // リセットカードの色（わかりやすく）
        }
        return Color.white;
    }
}
