using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImages : MonoBehaviour
{
  public EndOfPresentation endOfPresentation;
  public DownloadImg script;
  public VideoManager videoManager;
  //https://hatrabbits.com/wp-content/uploads/2017/01/random.jpg
  public string[] image_url;
  public int imageNumber;
  private float pushBtn;
  private bool canLoadImg;

  private void Start() {
    imageNumber = 0;
  }

  void Update() {
    //project settings->input->nextimage (space)
    pushBtn = Input.GetAxis("NextImage");

    if(pushBtn > 0.1) canLoadImg = true;
    else canLoadImg = false;

    if(canLoadImg && Input.GetButtonDown("NextImage")){
      if(imageNumber != image_url.Length) {
        Load();
      } else {
        videoManager.endofimage = true;
        videoManager.StopVideoPlay();
        endOfPresentation.enabled = true;
      }
    }
  }

  public void OnPointerClick() {
    if(imageNumber != image_url.Length) {
      Load();
    } else {
      videoManager.endofimage = true;
      videoManager.StopVideoPlay();
      endOfPresentation.enabled = true;
    }
  }

  private void Load() {
    canLoadImg = false;
    print("next image: " + image_url);
    script.image_url = image_url[imageNumber];
    script.StartCoroutine("Download",0.1f);
    imageNumber++;
    //script.StopCoroutine("Download");

  }
}
 