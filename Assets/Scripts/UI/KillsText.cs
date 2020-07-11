using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillsText : MonoBehaviour
{
    public IntVariable playerKills;
    public Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        playerKills.value = playerKills.InitialValue;
        
        textComponent.text = "" + playerKills.value;
    }

    public void updateKills()
    {
        playerKills.value++;
        textComponent.text = "" + playerKills.value;
    }
}
