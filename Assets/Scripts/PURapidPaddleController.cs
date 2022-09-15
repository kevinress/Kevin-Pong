using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PURapidPaddleController : MonoBehaviour
{
    public Collider2D ball;
    public int magnitude;
    public PowerUpManager manager;
    public GameObject leftPaddle;
    public GameObject rightPaddle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            leftPaddle.GetComponent<PaddleController>().ActivatePURapidPaddle(magnitude);
            rightPaddle.GetComponent<PaddleController>().ActivatePURapidPaddle(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}
