using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadImg : MonoBehaviour
{
  public string image_url;

  public IEnumerator Download() {
    print("imageurl: " + image_url);
    WWW www = new WWW(image_url);
    while(!www.isDone)
      yield return null;
    Debug.Log(www.texture.name);
    GameObject rawImage = GameObject.Find("RawImage");
    rawImage.GetComponent<RawImage>().texture = www.texture;
  }
}
