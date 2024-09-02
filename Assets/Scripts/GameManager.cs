using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public int Lives;
    public TMP_Text LivesText;
    public AudioSource AS;
    public TMP_Text ScoreText;
    public int Score;
    public static int HighScore;
    public TMP_Text HighScoreText;

    private void Start()
    {
        HighScoreText.text = "High Score: " + HighScore;
    }

    public void RemoveLife()
    {
        AS.Play();
        Lives--;
        LivesText.text = "Lives: " + Lives;
        if (Lives <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void AddScore()
    {
        Score += 100;
        ScoreText.text = "Score: " + Score;
        if (Score > HighScore)
        {
            HighScore = Score;
            HighScoreText.text = "High Score: " + HighScore;
        }
    }

    private void FixedUpdate()
    {
        int Gubmo = Random.Range(0, 1000);
        if (Gubmo >= 980)
        {
            int GubTwo = Random.Range(0, 100);
            if (GubTwo > 60)
            {
                Instantiate(Enemy3, new Vector2(0, -900), Quaternion.identity);
            }
            else if (GubTwo < 40)
            {
                Instantiate(Enemy1, new Vector2(0, -900), Quaternion.identity);
            }
            else
            {
                Instantiate(Enemy2, new Vector2(0, -900), Quaternion.identity);
            }
        }
    }
}
