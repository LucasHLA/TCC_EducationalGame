using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public Player player;
    public Robot robot;

    public bool playerIsActive = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        if (playerIsActive)
        {
            player.enabled = false;
            robot.enabled = true;
            playerIsActive = false;
        }
        else
        {
            player.enabled = true;
            robot.enabled = false;
            playerIsActive = true;

        }
    }
}
