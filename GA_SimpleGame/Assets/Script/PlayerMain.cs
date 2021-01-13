using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private Vector3 pos;
    private Rigidbody rg;

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        //60fpsに固定
        Application.targetFrameRate = 120;

        pos = this.transform.position;
        rg = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 180.0f));
            rg.AddForce(new Vector3(-Speed, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
            rg.AddForce(new Vector3(Speed, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
            rg.AddForce(new Vector3(0.0f, Speed, 0.0f));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 270.0f));
            rg.AddForce(new Vector3(0.0f, -Speed, 0.0f));
        }

    }

}
