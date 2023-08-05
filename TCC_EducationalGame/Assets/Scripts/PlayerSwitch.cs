using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public Player player;
    public Robot robot;

    public bool playerIsActive = true;
    private Robot activeRobot;

    public GameObject playerCamera;
    public GameObject robotCamera;


    private void Start()
    {
        activeRobot = GameObject.FindGameObjectWithTag("Robot").GetComponent<Robot>();
    }

    void Update()
    {
        if (activeRobot.isActiveAndEnabled && Input.GetKeyDown(KeyCode.E))
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
            playerCamera.SetActive(false);
            robotCamera.SetActive(true);
        }
        else
        {
            player.enabled = true;
            robot.enabled = false;
            playerIsActive = true;
            playerCamera.SetActive(true);
            robotCamera.SetActive(false);
        }
    }
}
