using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Elympics;

public class Machine : MonoBehaviour
{
    public ElympicsFloat progress;

    private Transform currentPlayer;

    void OnTriggerEnter2D(Collider2D col)
    {
        progress.Value = 0;
        if(currentPlayer == null) currentPlayer = col.transform;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform == currentPlayer) 
        {
            if(col.GetComponent<Actions>().isPlayerWorking()) 
            {
                progress.Value += Time.deltaTime;
            }
            else 
            {
                progress.Value = 0;
            }
            Debug.Log(progress);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        currentPlayer = null;
        progress.Value = 0;
        Debug.Log("leftAREA");
    }

    
}
