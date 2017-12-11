using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Fade : MonoBehaviour {

    float fadeSpeed = 0.02f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //パネルの色、不透明度を管理

    public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

    Image fadeImage;                //透明度を変更するパネルのイメージ

    //messageを表示するテキスト
    private GameObject messageText;

    void Start()
    {

        //シーン中のmessageTextオブジェクトを取得
        this.messageText = GameObject.Find("message");

        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
        //表示されるかテスト
       // this.messageText.GetComponent<Text>().text = GameData.Message_Of_CarClash;
    }

    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn();
        }

        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeIn()
    {
        alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
        SetAlpha();                      //b)変更した不透明度パネルに反映する
        if (alfa <= 0)
        {                    //c)完全に透明になったら処理を抜ける
            isFadeIn = false;
            fadeImage.enabled = false;    //d)パネルの表示をオフにする

            //Playerクラスでローディング中のフラグを立てたものを戻す
            GameData.IsLoading = false;

            //新しいステージに遷移
            SceneManager.LoadScene(GameData.NUMBER_OF_STAGES);
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;  // a)パネルの表示をオンにする
        alfa += fadeSpeed;         // b)不透明度を徐々にあげる
        SetAlpha();               // c)変更した透明度をパネルに反映する
        if (alfa >= 1)
        {             // d)完全に不透明になったら処理を抜け
            isFadeOut = false;


        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
