using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool haveairstrike;
    public void tacticalAirstrike()
    {
        if(Input.GetKeyDown(KeyCode.T) && haveairstrike == true)
        {

        }
    }
}
