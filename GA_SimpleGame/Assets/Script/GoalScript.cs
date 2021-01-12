using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    public Text ScoreText;
    private int DeathCount;

    // Start is called before the first frame update
    void Start()
    {
        DeathCount = 0;
        ScoreText.text = DeathCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            DeathCount++;
            ScoreText.text = DeathCount.ToString();
        }
    }

}
