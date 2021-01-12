using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet : MonoBehaviour
{
    public Vector3 Power;
    public int status;
    private Rigidbody rg;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            Destroy(this.gameObject);

            if (other.tag == "Enemy")
            {
                Rigidbody rg_o = other.gameObject.GetComponent<Rigidbody>();
                rg_o.velocity = rg.velocity * 1.0f;
            }

        }
    }

    public void SetPower(Vector3 pv)
    {
        rg = this.GetComponent<Rigidbody>();
        rg.velocity = new Vector3(Mathf.Cos(pv.z/180.0f*3.14159265f) * 
            120.0f, Mathf.Sin(pv.z/180.0f*3.14159265f) * 120.0f, 0.0f);

    }
}

