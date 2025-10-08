using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score = 0;

    private void Awake()
    {
        // Zorg dat het tekstveld gekoppeld is
        if (scoreText == null)
            scoreText = GetComponent<TMP_Text>();

        // Zet beginscore
        UpdateScoreText();
    }

    private void OnEnable()
    {
        // Luistert naar pickup events
        Pickup.OnPickedUp += AddScore;
    }

    private void OnDisable()
    {
        // Stop luisteren als dit object uitgeschakeld is
        Pickup.OnPickedUp -= AddScore;
    }

    private void AddScore()
    {
        score += 50;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
