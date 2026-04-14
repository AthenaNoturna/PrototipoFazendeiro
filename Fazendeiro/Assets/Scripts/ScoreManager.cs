using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public int winScore = 20;

    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

public void AddScore(int value)
{
    score += value;

    scoreText.text = "Pontos: " + score;

    if (score >= winScore)
    {
        FindFirstObjectByType<MenuPrincipal>().Victory();
    }

    if (score < 0)
    {
        FindFirstObjectByType<MenuPrincipal>().GameOver();
    }
}
}