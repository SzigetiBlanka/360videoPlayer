using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionTest : MonoBehaviour
{

  public RawImage internet_rawimg;
  public RawImage emotiv_rawimg;
  public RawImage controller_rawimg;
  public RawImage data_rawimg;

  public Texture done_img;
  public Texture notDone_img;

  private VideoManager videoManager;

  private void Start() {
    videoManager = GameObject.Find("VideoMNG").GetComponent<VideoManager>();

  }
  void Update()
    {

      //check internet connection
      if(Application.internetReachability != NetworkReachability.NotReachable) {
      internet_rawimg.texture = done_img;
      } else {
        internet_rawimg.texture = notDone_img;
      }
    if(videoManager.videoDownloaded) {
      data_rawimg.texture = done_img;
    } else {
      data_rawimg.texture = notDone_img;
    }

    }
}
