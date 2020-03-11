using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideScore : MonoBehaviour
{
    [HideInInspector] public bool timeToShowScore = false;

    private GameObject score;
    [HideInInspector] public int scoreCreativity;
    [HideInInspector] public int scoreTaste;
    private Text scoreLabelC;
    private Text scoreLabelT;
    [HideInInspector]  public List<string> ComboNames; //use this to display names of food combos (if there are any)

    // Start is called before the first frame update
    void Start()
    {
    score = GameObject.Find("Score UI");
    
    scoreLabelC = GameObject.Find("Score Number Creativity").GetComponent<Text>();
    scoreLabelT = GameObject.Find("Score Number Taste").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToShowScore == true)
        {
            scoreLabelC.text = scoreCreativity.ToString();
            scoreLabelT.text = scoreTaste.ToString();
            //score label x
            score.SetActive(true);
            foreach (var combo in ComboNames)
            {
                //socre label x.text += combo
            }
        } else
        {
            score.SetActive(false);
        }

    }
}
