using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using Unity.VisualScripting;
using UnityEngine;

public class FollowChar : MonoBehaviour
{
    // Start is called before the first frame update
    public float followSpeed =3.0f;
    public Transform cam;
    public Transform leftdown;
    public Transform rightup;
    public Transform target;

    private float xOffset = .0f;
    private float yOffset = .0f;
    private float l;
    private float r;
    private float u;
    private float d;
    private float camL;
    private float camR;
    private float camU;
    private float camD;
    private bool followX;
    private bool followY;
    private bool isTargetInFrame;

    void Start()
    {
        l = leftdown.transform.position.x;
        r = rightup.transform.position.x;
        d = leftdown.transform.position.y;
        u = rightup.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (camL - l <=0)
        {
            xOffset = +8.5f;
            followX = false;
        }
        else if (camR - r >= 0)
        {
            xOffset = -8.5f;
            followX = false;
        }
        else
        {
            xOffset = 0f;
            followX = true;
        }

        if (camD - d <= 0)
        {
            yOffset = +5f;
            followY = false;
        }
        else if (camU - u >= 0)
        {
            yOffset = -5f;
            followY = false;
        }
        else
        {
            yOffset = 0f;
            followY = true;
        }
        CheckTargetInFrame();

        //if (followX || followY || !isTargetInFrame)
        //{
        //    Vector3 newPos = new Vector3(target.transform.position.x + xOffset, target.transform.position.y + yOffset, -10f);
        //    transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        //}

        if (followX)
        {
            FollowX();
        }
        if (followY)
        {
            FollowY();
        }
        //if (followX && followY)
        //{
        //    Vector3 newPos = new Vector3(target.transform.position.x + xOffset, target.transform.position.y + yOffset, -10f);
        //    transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        //}
    }

    private void FollowX()
    {
        Vector3 newPos = new Vector3(target.transform.position.x + xOffset, cam.transform.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }

    private void FollowY()
    {
        Vector3 newPos = new Vector3(cam.transform.position.x, target.transform.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }

    private void GetCamPosition()
    {
        camL = cam.transform.position.x - 9f;
        camR = cam.transform.position.x + 9f;
        camU = cam.transform.position.y + 5f;
        camD = cam.transform.position.y - 5f;
    }

    private void CheckTargetInFrame()
    {
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;
        if (targetX -9f > camL || targetX + 9f < camR || targetY -5f > camD || targetY + 5f < camU)
        {
            isTargetInFrame = false;
        }
        else
        {
            isTargetInFrame = true;
        }
    }
}
