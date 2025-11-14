using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    float pasttime = 0f;
    int score = 0;
    public Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pasttime += Time.deltaTime;
        
        if(pasttime >= 1f)
        {
            score += 1;
            pasttime = 0f;
            scoreText.text = "Score : " + score;
            
        }

    }
    public void ScoreIncrease(int increment)
    {
        score += increment;
        scoreText.text = "Score : " + score;
    }
}
