using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanvasPosition : MonoBehaviour
{
  private RectTransform myRectTransform;

  private GameObject sphere;

  void Start()
  {
    sphere = GameObject.Find("Sphere");
  }


  public void PresentationSetup(double a,double b,double deckx,double decky,double deckz) {
    myRectTransform = GetComponent<RectTransform>();

    /*Vector2 size = new Vector2((float)a,(float)b);
    myRectTransform.sizeDelta = size;
    this.gameObject.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = size;
    Vector3 vector = new Vector3((float)deckx,(float)decky,(float)deckz);*/
    //myRectTransform.SetPositionAndRotation(vector,new Quaternion());
  }

}
