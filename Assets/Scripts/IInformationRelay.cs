using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInformationRelay
{
    RelayData GetInformation();
}
[System.Serializable]
public class RelayData
{
    public Vector3 positionData;
    public bool isTriggered;
    public int integerData;
    public float floatData;
} 