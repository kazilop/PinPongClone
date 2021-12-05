using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreController : MonoBehaviour
{

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public GameObject scoreTextPl1;
    public GameObject scoreTextPl2;

    public int goalToWin;

    // Update is called once per frame
    void Update()
    {
        if(this.scorePlayer1 >= this.goalToWin || this.scorePlayer2 >= this.goalToWin)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void FixedUpdate()
    {
        Text uiScorePl1 = this.scoreTextPl1.GetComponent<Text>();
        uiScorePl1.text = scorePlayer1.ToString();

        Text uiScorePl2 = this.scoreTextPl2.GetComponent<Text>();
        uiScorePl2.text = scorePlayer2.ToString();
    }

    public void GoalPlayer1()
    {
        this.scorePlayer1++;
    }
    public void GoalPlayer2()
    {
        this.scorePlayer2++;
    }
}
