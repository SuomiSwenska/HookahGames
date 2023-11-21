using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathComponent : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy") player.Death(collision.transform.position);
    }
}
