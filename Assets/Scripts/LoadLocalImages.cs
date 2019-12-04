using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLocalImages : MonoBehaviour
{
  public Material frontPlane_material;
  public GameObject plane;
  public Texture2D image;
  private int num_img =5;
  private int current_img = 0;

  private GameObject go;
  //public Plane plane;

  // Start is called before the first frame update
  void Start()
    {
    Renderer rend = plane.GetComponent<Renderer>();
    frontPlane_material.mainTexture = image;
    rend.material.mainTexture = image;
    /*rend.material = frontPlane_material;
    rend.sharedMaterial = frontPlane_material;*/
    current_img++;
    // Load the Image from somewhere on disk
    /*var filePath = "Assets/images/Slide1.jpg";
    if(System.IO.File.Exists(filePath)) {
      // Image file exists - load bytes into texture
      var bytes = System.IO.File.ReadAllBytes(filePath);
      var tex = new Texture2D(1,1);
      tex.LoadImage(bytes);
      frontPlane.mainTexture = tex;

      // Apply to Plane
      MeshRenderer mr = plane.GetComponent<MeshRenderer>();
      mr.material = frontPlane;
      }*/
  }

    // Update is called once per frame
    /*void Update()
    {
      if(Input.GetKeyDown(KeyCode.A)) {
      if(num_img != current_img) {
        Renderer rend = plane.GetComponent<Renderer>();
        current_img++;
        rend.material.mainTexture = Resources.Load("images/Slide"+current_img+".jpg/") as Texture;
      }
      }
    }*/
}
