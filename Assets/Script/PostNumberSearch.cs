using HoloToolkit.Unity.InputModule;
using System;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Collections;

public class PostNumberSearch : MonoBehaviour, IInputClickHandler
{
	public GameObject postCode;
	public GameObject address;
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}
	public void OnInputClicked(InputClickedEventData eventData)
	{
		String number = postCode.GetComponent<TextMesh>().text;
		Debug.Log(number);
		StartCoroutine(GetAddressAPI(number));
		//address.GetComponent<TextMesh>().text ;
	}
	// WebAPIにアクセス
	private IEnumerator GetAddressAPI(string number)
	{
		Debug.Log("in!!");
		WWW www = new WWW("http://zipcloud.ibsnet.co.jp/api/search?zipcode="+number);
		yield return www;
		string addressText = "郵便番号を入力に\n誤りがあります";
		if (www.error != null || www.text == "")
		{
			Debug.Log("error!!");
			// TODO:error operation
		}
		else
		{
			JSONObject json = new JSONObject(www.text);

			if (json.GetField("message").str == null)
			{
				Debug.Log(www.text);
				//JSONObjectで解析
				JSONObject data = json.GetField("results");
				Debug.Log(data[0].GetField("address1").str);
				addressText = data[0].GetField("address1").str + data[0].GetField("address2").str + "\n" + data[0].GetField("address3").str;
			}
		}
		address.GetComponent<TextMesh>().text = addressText;
	}
}
