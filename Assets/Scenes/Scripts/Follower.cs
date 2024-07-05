using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform place;

    private void Update()
    {
        transform.position = place.position;
    }
}
