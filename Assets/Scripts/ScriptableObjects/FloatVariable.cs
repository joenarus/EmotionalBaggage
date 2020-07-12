using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public float value;
    public float InitialValue;

    [NonSerialized]
    public float RuneTimeValue;

    public void OnAfterDeserialize()
    {
        RuneTimeValue = InitialValue;
    }
    public void OnBeforeSerialize()
    {

    }
}
