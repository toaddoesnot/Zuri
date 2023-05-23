using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    CanvasGroup canvasGroup;
    public AudioSource audioSource;
    public bool dropped;
    //public AudioClip pickUpSound;
    //Vector3 offset;

    public void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        //pickUpSound = GameObject.Find("pickUpCardObj").GetComponent<AudioSource>().GetComponent<AudioClip>();
    }

    void Awake()
    {
        //rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = GetMousePos();
        //transform.position = Input.mousePosition + offset;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //offset = transform.position - Input.mousePosition;
        //audioSource.clip = pickUpSound;
        audioSource.Play();
        canvasGroup.blocksRaycasts = false;
        dropped = false;
    }

    public void OnPointerUp (PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        
        dropped = true;
        //throw new System.NotImplementedException();
    }

    Vector3 GetMousePos()
    {
        //Vector3 mousePosition = Input.mousePosition;

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 40;
        return mousePos;
    }
}
