using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class HeadFollower : MonoBehaviour
{
    public Transform head;
    public Transform target;


    private void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, target.position, 0.5f);
        transform.position = newPos;
        transform.LookAt(head.position);
        for(int i = 0; i < transform.childCount;i++)
        {
            transform.GetChild(i).transform.LookAt(head);
        }

    }
}
