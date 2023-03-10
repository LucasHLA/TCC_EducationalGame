using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperRobot : Robot
{

    protected override void Update()
    {
        base.Update();
        RobotBaseMoviment();
    }
}
