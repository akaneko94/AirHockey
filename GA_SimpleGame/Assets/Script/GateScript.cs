using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    Transform myTrans;

    [SerializeField] Vector2[] positions;
    [SerializeField] float[] durations;

    int step;
    float time;
    int positionCount;

    public bool move;

    void Awake()
    {
        if (positions.Length != durations.Length)
            Debug.LogError("positionsとdurationsの要素数が異なっています");

        myTrans = transform;
        step = 0;
        time = 0f;
        positionCount = positions.Length;
        move = true;
    }

    void Update()
    {
        if (move)
        {
            time += Time.deltaTime / durations[step % positionCount];

            myTrans.localPosition = Vector3.Slerp(
                positions[step % positionCount],
                positions[(step + 1) % positionCount],
                time
            );

            if (time >= 1f)
            {
                myTrans.localPosition = positions[(step + 1) % positionCount];
                step++;
                time = 0f;
            }
        }
    }
}
