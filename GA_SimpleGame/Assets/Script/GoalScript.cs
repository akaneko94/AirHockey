using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    public Text ScoreText;
    private int DeathCount;
    public int WinCount;
    public GameObject Ball;
    public GameObject Player;
    public GameObject Enemy;
    private Vector3 InitBallPos;
    private Vector3 InitPlayerPos;
    private Vector3 InitEnemyPos;
    private Rigidbody Ballrb;
    private Rigidbody Playerrb;
    private Rigidbody Enemyrb;

    // Start is called before the first frame update
    void Start()
    {
        DeathCount = 0;
        ScoreText.text = DeathCount.ToString();

        InitBallPos = Ball.transform.position;
        InitPlayerPos = Player.transform.position;
        InitEnemyPos = Enemy.transform.position;

        Ballrb = Ball.GetComponent<Rigidbody>();
        Playerrb = Player.GetComponent<Rigidbody>();
        Enemyrb = Enemy.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            DeathCount++;
            if (DeathCount == WinCount)
            {
                ScoreText.text = ("WIN");
            }
            else
            {
                ScoreText.text = DeathCount.ToString();

            }

            Ball.transform.position = InitBallPos;
            Player.transform.position = InitPlayerPos;
            Enemy.transform.position = InitEnemyPos;

            Ballrb.velocity = Vector3.zero;
            Playerrb.velocity = Vector3.zero;
            Enemyrb.velocity = Vector3.zero;
        }
    }

}
