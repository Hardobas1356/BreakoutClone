using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball.Instance.ResetBall();
    }
}
