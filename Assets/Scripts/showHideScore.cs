using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHideScore : MonoBehaviour
{
    public bool timeToShowScore;

    private GameObject score;
    public int scoreCreativity;
    public int scoreTaste;
    private Text scoreLabelC;
    private Text scoreLabelT;

    // Start is called before the first frame update
    void Start()
    {
    score = GameObject.Find("Score UI");

    scoreCreativity = 0;
    scoreTaste = 0;
    scoreLabelC = GameObject.Find("Score Number Creativity").GetComponent<Text>();
    scoreLabelT = GameObject.Find("Score Number Taste").GetComponent<Text>();

    timeToShowScore = false;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timeToShowScore == true)
        {
            scoreLabelC.text = scoreCreativity.ToString();
            scoreLabelT.text = scoreTaste.ToString();
            score.SetActive(true);
        } else
        {
            score.SetActive(false);
        }

    }
}
