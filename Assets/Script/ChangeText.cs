using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour , IInputClickHandler
{
    public GameObject cubeText;
    public GameObject image;
    public GameObject cube;
    private int count;
    // Use this for initialization
    void Start () {
        count = 0;
        image.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void OnInputClicked(InputClickedEventData eventData)
    {
        cubeText.GetComponent<TextMesh>().text = count+"";
        if (count % 2!=0)
        {
            image.SetActive(false);
        }
        else
        {
            image.SetActive(true);
        }
        count++;
        //message.text= "Cubeを押したね!!";
        //text.GetComponent<Text>().text = "Cubeを押したね!!";
    }
   
}
