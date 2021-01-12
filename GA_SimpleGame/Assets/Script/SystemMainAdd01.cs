using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMainAdd01 : MonoBehaviour
{
    public GameObject D_PanelObj;
    static public GameObject D_Panel;

    public GameObject PlayerObj;
    static public GameObject Player;

    static public Text P_Score;
    static public Text E_Score;

    static private int P_score_Value=0;
    static private int E_score_Value=0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        D_Panel = Instantiate(D_PanelObj, new Vector3(
            Random.Range(-200.0f, 200.0f), 
            Random.Range(-100.0f, 100.0f), 0.0f), 
            Quaternion.identity);
        Player = Instantiate(PlayerObj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

        P_score_Value = 0;
        E_score_Value = 0;

        P_Score = GameObject.Find("PlayerScore").GetComponent<Text>();
        E_Score = GameObject.Find("EnemyScore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public GameObject Get_D_panel()
    {
        return D_Panel;
    }

    static public GameObject Get_Player()
    {
        return Player;
    }

    static public void AddPScore()
    {
        P_score_Value++;
    }

    static public void SetPScore()
    {
        P_Score.text = P_score_Value.ToString();
    }

    static public void AddEScore()
    {
        E_score_Value++;

    }

    static public void SetEScore()
    {
        E_Score.text = E_score_Value.ToString();
    }
}
