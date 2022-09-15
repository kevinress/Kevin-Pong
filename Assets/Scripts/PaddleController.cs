using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    int defaultSpeed;
    Vector3 defaultScale;
    public int PUBoostPaddleDuration, PURapidPaddleDuration;
    public float PUBoostPaddleTimer, PURapidPaddleTimer;

    public KeyCode upKey;
    public KeyCode downKey;

    Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        defaultScale = transform.localScale;
        defaultSpeed = speed;
        PUBoostPaddleTimer = -1; //-1 maksudnya adalah PU tidak aktif, selain itu aktif
        PURapidPaddleTimer = -1;
    }

    void Update()
    {
        MoveObject(GetInput());

        if(PUBoostPaddleTimer != -1)
        {
            PUBoostPaddleTimer += Time.deltaTime;
        }

        if (PURapidPaddleTimer != -1)
        {
            PURapidPaddleTimer += Time.deltaTime;
        }

        if (PUBoostPaddleTimer >= PUBoostPaddleDuration)
        {
            DeactivatePUBoostPaddle();
        }

        if(PURapidPaddleTimer >= PURapidPaddleDuration)
        {
            DeactivatePURapidPaddle();
        }
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        //Debug.Log("TEST: " + movement);
        //diatas ini syarat penilaian tugas sebelumnya, saya matikan karena ganggu ;)
        rig.velocity = movement;
    }

    public void ActivatePUBoostPaddle(int magnitude)
    {
        //saya asumsikan boost tidak bisa stack scale karena dipermintaan fiturnya memanjang 2x lipat dari default, bukan dari panjang saat terkena PU
        //saya asumsikan boost tidak bisa stack durasi karena dipermintaan fiturnya hanya durasi 5 detik, tidak disebut apakah bisa bertambah
        if (transform.localScale == defaultScale) 
        {
            transform.localScale = new Vector3(this.transform.localScale.x, rig.transform.localScale.y * magnitude, this.transform.localScale.z);
            PUBoostPaddleTimer = 0; //start timer boost paddle
        }
    }

    public void DeactivatePUBoostPaddle()
    {
        transform.localScale = defaultScale;
        PUBoostPaddleTimer = -1;
    }

    public void ActivatePURapidPaddle(int magnitude)
    {
        //saya asumsikan PU Rapid tidak bisa stack speed dan durasi dengan alasan yang sama seperti PU Boost
        if(speed == defaultSpeed)
        {
            speed *= magnitude;
            PURapidPaddleTimer = 0;
        }
    }

    public void DeactivatePURapidPaddle()
    {
        speed = defaultSpeed;
        PURapidPaddleTimer = -1;
    }
}
