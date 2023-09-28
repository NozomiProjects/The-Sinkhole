using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class clickedItem : MonoBehaviour
{
    public slot clickedSlot;

    [SerializeField] RawImage image;
    [SerializeField] TextMeshProUGUI txtName;
    [SerializeField] TextMeshProUGUI txtStack;
    [SerializeField] TextMeshProUGUI txtDescription;

    private void OnEnable()
    {
        setUp();
    }

    void setUp()
    {
        txtName.text = clickedSlot.itemInSlot.name;
        txtStack.text = $"{clickedSlot.amountInSlot}";
        txtDescription.text = clickedSlot.description;

    }

}
