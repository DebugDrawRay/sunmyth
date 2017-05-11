using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTarget : MonoBehaviour, IInformationRelay
{
    public bool useVision;
    public float trackingDistance;

    public LayerMask visionLayers;
    public LayerMask nonVisionLayers;

    public string targetTag = "Player";
    private GameObject[] targets
    {
        get
        {
            return GameObject.FindGameObjectsWithTag(targetTag);
        }
    }
    public RelayData GetInformation()
    {
        RelayData data = new RelayData();
        LayerMask mask = nonVisionLayers;
        if(useVision)
        {
            mask = visionLayers;
        }

        //vvv Fucking change this vvv
        GameObject target = targets[0];
        Vector3 targetDir = target.transform.position - transform.position;
        Ray targeting = new Ray(transform.position, targetDir);

        data.isTriggered = Physics.Raycast(targeting, trackingDistance, mask);
        data.positionData = target.transform.position;
        return data;
    }
}
