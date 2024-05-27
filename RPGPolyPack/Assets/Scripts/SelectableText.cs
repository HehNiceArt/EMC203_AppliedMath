using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectableText : MonoBehaviour
{
    public TextMeshProUGUI lookPercentText;
    public float lookPercent;

    private void Update()
    {
        lookPercentText.text = lookPercent.ToString("F3");
    }
}
