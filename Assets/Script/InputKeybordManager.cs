using System;
using HoloToolkit.UI.Keyboard;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class InputKeybordManager : MonoBehaviour , IInputClickHandler
{

    public GameObject text;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnInputClicked(InputClickedEventData eventData)
    {
        // すでにキーボードを開いていれば閉じる
        Keyboard.Instance.Close();
        // キーボードを表示する
        Keyboard.Instance.PresentKeyboard();
        // キーボードの位置をオブジェクトの近くに調整する
        //Vector3 pos = transform.position;
        //pos.z = pos.z - 4;
        //transform.position = pos;
        //Keyboard.Instance.RepositionKeyboard(transform, null, 0.1f);
        // キー入力値更新時のイベントを設定する
        Keyboard.Instance.OnTextUpdated += KeyboardOnTextUpdated;
        // キーボードを閉じたときのイベントを設定する
        Keyboard.Instance.OnClosed += KeyboardOnClosed;
    }
    private void KeyboardOnTextUpdated(string s)
    {
        // 入力された文字列が渡されるので、
        // TextMeshにセットする
        //TargetTextMesh.text = s;
        text.GetComponent<TextMesh>().text = s;
    }
    private void KeyboardOnClosed(object sender, EventArgs eventArgs)
    {
        // イベントを解除する
        Keyboard.Instance.OnTextUpdated -= KeyboardOnTextUpdated;
        Keyboard.Instance.OnClosed -= KeyboardOnClosed;
    }
}
