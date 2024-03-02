using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

    private float targetL;
    private float targetR;
    private float targetU;
    private float targetD;

    private bool followX;
    private bool followY;
    private bool isTargetInFrame;

    void Start()
    {
        l = leftdown.transform.position.x + 9f;
        r = rightup.transform.position.x - 9f;
        d = leftdown.transform.position.y + 5f;
        u = rightup.transform.position.y - 5f;
    }

    // Update is called once per frame
    void Update()
    {

        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;
        if (targetX <= l)
        {
            xOffset = l-targetX;
            followX = false;
        }
        else if (targetX >= r)
        {
            xOffset = r-targetX;
            followX = false;
        }
        else
        {
            xOffset = 0;
            followX =true;
        }

        if (targetY <= d)
        {
            yOffset = d-targetY;
            followY = false;
        }
        else if (targetY >= u)
        {
            yOffset = u-targetY;
            followY = false;
        }
        else
        {
            yOffset = 0;
            followY = true;
        }

        //CheckTargetInFrame();

        //if (followX || followY || !isTargetInFrame)
        //{
        //    Vector3 newPos = new Vector3(target.transform.position.x + xOffset, target.transform.position.y + yOffset, -10f);
        //    transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        //}

        if (followX && followY)
        {
            FollowXY();
        }
        else
        {
            if (followX)
            {
                FollowX();
            }else {
                yOffset = 0f;
            }
            
            if (followY)
            {
                FollowY();
            }
            else
            {
                xOffset = 0f;
            }
        }

        //if (followX && followY)
        //{
        //    Vector3 newPos = new Vector3(target.transform.position.x + xOffset, target.transform.position.y + yOffset, -10f);
        //    transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        //}
    }

    private void FollowY()
    {
        Vector3 newPos = new Vector3(target.transform.position.x + xOffset, target.transform.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }

    private void FollowX()
    {
        Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }

    private void FollowXY()
    {
        Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }

    private void GetTargetPosition()
    {
        targetL = target.transform.position.x - 9f;
        targetR = target.transform.position.x + 9f;
        targetU = target.transform.position.y + 5f;
        targetD = target.transform.position.y - 5f;
    }

    private void CheckTargetInFrame()
    {
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;
        if (targetX -9f < l || targetX + 9f > r)
        {
            followX = false;
        }
        else
        {
            followX = true;
        }

        if (targetY - 5f < d || targetY + 5f > u)
        {
            followY = false;
        }
        else
        {
            followX = true;
        }

    }
}
