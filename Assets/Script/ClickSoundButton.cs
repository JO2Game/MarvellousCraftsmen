﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSoundButton : MonoBehaviour {
    
    //背景音乐对象
    public AudioSource backmusic;

    //静音图片资源
    public Sprite muteSoundSprite;

    //用于判断是否静音
    public bool mute = false;

    void Start()
    {
        //获取是否静音静音的int值
        int iMute = PlayerPrefs.GetInt("mute");
        //转为bool值
        mute = Convert.ToBoolean(iMute);

        //静音时的操作
        if (mute)
        {
            //获取Image资源
            Image image = gameObject.GetComponent<Image>();
            //获取Music资源

            //先保存原来的图片,设置新的图片资源
            Sprite tempSprite = image.sprite;
            image.sprite = muteSoundSprite;
            muteSoundSprite = tempSprite;

           //静音
            backmusic.Stop();
           
        }
        
    }

    //点击时将声音按钮图片设置为静音状态
    public void OnClicSoundButton()
    {
        //获取Image资源
        Image image = gameObject.GetComponent<Image>();
        //获取Music资源

        //先保存原来的图片,设置新的图片资源
        Sprite tempSprite = image.sprite;
        image.sprite = muteSoundSprite;
        muteSoundSprite = tempSprite;

        //修改静音判断bool值
        mute = !mute;
        //将静音值存入PlayerPrefs
        PlayerPrefs.SetInt("mute",Convert.ToInt32(mute));

        //执行静音操作
        if (mute)
        {
            backmusic.Stop();
        }
        else
        {
            backmusic.Play();
        }
    }

}
