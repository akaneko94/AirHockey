using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMain : MonoBehaviour
{
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
        float x = Random.Range(-200.0f, 200.0f);
        float y = Random.Range(-100.0f, 100.0f);
        this.transform.position = new Vector3(x, y, 0.0f);
    }
}
