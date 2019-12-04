using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{

  public GameObject sphere;
  private YoutubeVideoManagerPlayer youtubeVideoManagerPlayer;
  public bool endofimage;
  public bool videoDownloaded;

  // Start is called before the first frame update
  void Start()
    {
    youtubeVideoManagerPlayer = sphere.GetComponent<YoutubeVideoManagerPlayer>();
    endofimage = false;
    videoDownloaded = false;
    //youtubeVideoManagerPlayer.run();
    }

    // Update is called once per frame
    void Update()
    {
      if(youtubeVideoManagerPlayer.videoSaved) {
        videoDownloaded = true;
      }
    }



  public void PlayVideoPlay() {
    youtubeVideoManagerPlayer.UrlToVideo();
  }

  public void StopVideoPlay() {
    if(endofimage) {
      youtubeVideoManagerPlayer.Stop();
    }
  }

  public void PauseVideoPlay() {
    youtubeVideoManagerPlayer.Pause();
  }
}
