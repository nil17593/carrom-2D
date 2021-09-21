using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    public GameObject coins;

    private void Start()
    {
        Instantiate(coins);
    }
}
