using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTarget : MonoBehaviour, IInformationRelay
{
    public bool useVision;
    public float trackingDistance;
    public LayerMask visionLayers;
    public LayerMask nonVisionLayers;
    private RelayData targetData;

    private void Update()
    {
        targetData = CheckForTarget();
    }

    
    public RelayData GetInformation()
    {
        return targetData;
    }
}
