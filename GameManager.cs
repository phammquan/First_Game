using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] List<GameObject> _player = new List<GameObject>();
    void Start()
    {

    }

    void Update()
    {
        ChangePlayer();
    }
    void ChangePlayer()
    {

        foreach (GameObject player in _player)
        {
            if (player.GetComponent<PlayerController>().PlayerSelect == _player.IndexOf(player))
            {
                player.GetComponent<PlayerController>().enabled = true;
            }
            else
            {
                player.GetComponent<PlayerController>().enabled = false;
            }
        }
    }
}
