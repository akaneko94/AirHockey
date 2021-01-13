using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EnemyMoveの改訂版なので、本来であれば派生・継承で作成すべきだが
//今回はわかりやすさのために、個別に作成


public class EnemyMoveScript : MonoBehaviour
{
    public GameObject PlayerObject;
    private Vector3 pos;
    private Rigidbody rg;

    private int InputWait;
    private int status;

    public float Speed;



    public int CommandNo = 0;
    private int CommandCount;

    private int MoveStatus;

    //以下コマンドデータ
    //コマンドリスト
    //L　無条件に左方向への移動
    //R　無条件に左方向への移動
    //U　無条件に左方向への移動
    //D　無条件に左方向への移動;
    //X　プレイヤーとの位置関係を確認し、左右方向へ近づく
    //Y　プレイヤーとの位置関係を確認し、上下方向へ近づく
    //S　しばらく移動しない（入力なしの状態）
    //r　コマンドの先頭に戻る

    private string[] sc_data = {
        "LLRRLLRRr",
        "XXSSYYSSLLUURRDDr",
        "XYr",
        "SSSSSXXXXSSSSSYYYYYr",
        "LLLUUUSSSSSRRRRRRRDDDSSSSLLr"
    };

    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
        rg = this.GetComponent<Rigidbody>();
        InputWait = 1;

        CommandCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        InputWait--;
        if (InputWait == 0)
        {
            InputWait = 40;

            bool flg = true;

            while (flg)
            {
                string str = sc_data[CommandNo].Substring(CommandCount, 1);
                switch (str)
                {
                    case "L":    //L　無条件に左方向への移動
                        MoveStatus = 0;
                        flg = false;
                        break;
                    case "R":    //R　無条件に左方向への移動
                        MoveStatus = 1;
                        flg = false;
                        break;
                    case "U":    //U　無条件に左方向への移動
                        MoveStatus = 2;
                        flg = false;
                        break;
                    case "D":    //D　無条件に左方向への移動;
                        MoveStatus = 3;
                        flg = false;
                        break;

                    case "X":    //X　プレイヤーとの位置関係を確認し、左右方向へ近づく
                        MoveStatus = 4;
                        flg = false;
                        break;

                    case "Y":    //Y　プレイヤーとの位置関係を確認し、上下方向へ近づく
                        MoveStatus = 5;
                        flg = false;
                        break;

                    case "S":    //S　しばらく移動しない（入力なしの状態）
                        MoveStatus = 9;
                        flg = false;
                        break;

                    case "r":    //r　コマンドの先頭に戻る
                        CommandCount = 0;
                        flg = true;
                        break;
                }
            }
            CommandCount++;
        }
        else
        {
            switch (MoveStatus)
            {
                case 0:
                    this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 180.0f));
                    rg.AddForce(new Vector3(-Speed, 0.0f, 0.0f));
                    break;
                case 1:
                    this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
                    rg.AddForce(new Vector3(Speed, 0.0f, 0.0f));
                    break;
                case 2:
                    this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
                    rg.AddForce(new Vector3(0.0f, Speed, 0.0f));
                    break;
                case 3:
                    this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 270.0f));
                    rg.AddForce(new Vector3(0.0f, -Speed, 0.0f));
                    break;

                case 4:
                    if (PlayerObject.transform.position.x == this.transform.position.x)
                    {
                    }
                    else if (PlayerObject.transform.position.x < this.transform.position.x)
                    {
                        this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 180.0f));
                        rg.AddForce(new Vector3(-Speed, 0.0f, 0.0f));
                    }
                    else
                    {
                        this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
                        rg.AddForce(new Vector3(Speed, 0.0f, 0.0f));
                    }
                    break;

                case 5:
                    if (PlayerObject.transform.position.y == this.transform.position.y)
                    {
                    }
                    else if (PlayerObject.transform.position.y < this.transform.position.y)
                    {
                        this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 270.0f));
                        rg.AddForce(new Vector3(0.0f, -Speed, 0.0f));
                    }
                    else
                    {
                        this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
                        rg.AddForce(new Vector3(0.0f, Speed, 0.0f));
                    }
                    break;

                case 9:
                    break;
            }
        }
    }

}

