using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInformationRelay
{
    RelayData GetInformation();
}

public class RelayData
{
    public Vector3 positionData;
    public int integerData;
    public float floatData;
} 