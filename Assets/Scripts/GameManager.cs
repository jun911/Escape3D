using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public float playTime;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        playTime = Time.time;
    }
}
