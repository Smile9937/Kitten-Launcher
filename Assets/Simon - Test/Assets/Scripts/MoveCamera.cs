using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public void Move(float horizontal, float vertical)
    {
        transform.position += new Vector3(horizontal, vertical, 0);
    }

}
