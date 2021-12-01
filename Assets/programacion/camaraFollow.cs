using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraFollow : MonoBehaviour
{


    public GameObject follow;
    public Vector2 MinCamPos;
    public Vector2 MaxCamPos;
    public float altura;
    // Update is called once per frame
    void Update()
    {
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y + altura;

        transform.position = new Vector3(
            Mathf.Clamp(posX, MinCamPos.x, MaxCamPos.x),
            Mathf.Clamp(posY, MinCamPos.y, MaxCamPos.y),
            transform.position.z);
    }
}

