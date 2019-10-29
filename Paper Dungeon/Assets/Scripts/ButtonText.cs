using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Changes textbox text based on what button is being hovered over
    [SerializeField]
    private Text Textbox;
    [SerializeField]
    private string Description;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Textbox.text = Description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Textbox.text = "";
    }
}
