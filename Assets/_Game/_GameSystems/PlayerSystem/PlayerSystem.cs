using System;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    public Action OnPlayerShoot;

    public GameObject playerGO;
    public float palyerSpeed;
    public float fireDelay;

    public bool isMoved;
}
