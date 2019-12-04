using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptedEventHandler : MonoBehaviour
{

  public SetCanvasPosition deck;

  public LoadImages loadImages;

  public string[] decklist;
  public string[] promterlist;
  //deckpos
  public double deckA;
  public double deckB;
  public double deckX;
  public double deckY;
  public double deckZ;

  //promterpos
  public double promterTopleftX;
  public double promterTopleftY;
  public double promterBottomRightX;
  public double promterBottomRightY;

  // Start is called before the first frame update
  void Start()
    {
    setDeckListSize(14.ToString());
    setDeckList("https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483387/t0mp59lfmei2xp2ntado.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483385/q059nia0to8bucdguyqi.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483385/xneuctugr1slzunc2caq.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483387/qyzgxkanodk2yedz0fgw.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483389/baf0eg6ip8psostzuj26.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483387/ndphyh2rjjydxdnuodqh.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483391/zno0p0de81scrjocj2xy.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483387/na1nugwkepe71alvswmo.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483400/zc7glkozelrmvkzbj6md.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483396/kwrztcfvqxpgxvxnb97a.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483391/pys4apxeyuifubrcpvr6.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483393/vpwojp34kpjtv58gbswz.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483398/alxzufhbhgb6rghijobr.jpg@https://res.cloudinary.com/dsbdera98/image/upload/w_1920,h_1080,c_scale/v1573483394/rgsp27yfpyhigmzlywww.jpg");
    //setPositionDeck("12.582627561654231@8.833372023666085@1.4979297@7.5701294@6.7636013");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  public void setDeckListSize(string decklistsize) {
    int size= 0;
    Debug.Log("decklistsize: " + int.TryParse(decklistsize,out size));
    Debug.Log("decklistsize: " + size);
    decklist = new string[size];
  }
  //https://res.cloudinary.com/dsbdera98/image/upload/v1571746197/uxzpvqid0wx0ukoukdov.jpg@https://res.cloudinary.com/dsbdera98/image/upload/v1571746197/dpzpnorkks7jwn8rqsga.jpg@https://res.cloudinary.com/dsbdera98/image/upload/v1571746197/v3qlx8odmvmvnnwlxlke.jpg
  public void setDeckList(string deckliststr) {
    Debug.Log("setDeckList: " + deckliststr);
    decklist = deckliststr.Split('@');
    loadImages.image_url = decklist;
    loadImages.enabled = true;

  }

  public void setPromterListSize(string promterlistsize) {
    Debug.Log("promterlistsize: " + promterlistsize);
    promterlist = new string[int.Parse(promterlistsize)];
  }

  public void setPromterList(string promterliststr) {
    Debug.Log("setPromterList: " + promterliststr);
    promterlist = promterliststr.Split('@');
  }

  public void setPositionDeck(string allposstr) {
    Debug.Log("setPositionDeck: " + allposstr);
    allposstr = allposstr.Replace('.',',');
    string[] deckPos = allposstr.Split('@');
    if(deckPos.Length != 5) {
      throw new System.Exception("deck positions is not perfect");
    } else {
      deckA = double.Parse(deckPos[0]);
      deckB = double.Parse(deckPos[1]);
      deckX = double.Parse(deckPos[2]);
      deckY = double.Parse(deckPos[3]);
      deckZ = double.Parse(deckPos[4]);
    }
   
    deck.PresentationSetup(deckA,deckB,deckX,deckY,deckZ);
  }

  public void setPositionPromter(string allposstr) {
    Debug.Log("setPositionPromter: " + allposstr);
    string[] promterPos = allposstr.Split('@');
    if(promterPos.Length != 4) {
      throw new System.Exception("promter positions is not perfect");
    } else {
      promterTopleftX = double.Parse(promterPos[0]);
      promterTopleftY = double.Parse(promterPos[1]);
      promterBottomRightX = double.Parse(promterPos[2]);
      promterBottomRightY = double.Parse(promterPos[3]);
    }
    
  }
}
