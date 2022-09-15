using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBoostPaddleController : MonoBehaviour
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
            leftPaddle.GetComponent<PaddleController>().ActivatePUBoostPaddle(magnitude);
            rightPaddle.GetComponent<PaddleController>().ActivatePUBoostPaddle(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}
