using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Elympics;

public class Key : MonoBehaviour, IObservable, IInitializable
{
    [SerializeField] private ElympicsBool picked;
    [SerializeField] private ElympicsInt playerID;
    [SerializeField] private Transform keyHolder;

    public void Initialize()
    {
        picked.Value = false;
        playerID.Value = -1;
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.GetComponentInParent<ElympicsBehaviour>().NetworkId == playerID.Value) return;
        this.transform.SetParent(col.transform);
        this.transform.localPosition = new Vector3(-1,0,0);
        playerID.Value = col.GetComponentInParent<ElympicsBehaviour>().NetworkId;
        picked.Value = true;
    }
}
