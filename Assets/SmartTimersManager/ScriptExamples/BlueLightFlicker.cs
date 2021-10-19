﻿using Timers;using UnityEngine;[RequireComponent(typeof(Light))]public class BlueLightFlicker : MonoBehaviour{    private Light m_PointLight;    private void Start()    {        m_PointLight = gameObject.GetComponent<Light>();        // set a timer that calls ChangeIntensity() every 0.1 seconds        TimersManager.SetLoopableTimer(this, 0.1f, ChangeIntensity);        TimersManager.SetTimer(this, 5f, delegate { Destroy(this); });    }    private void ChangeIntensity()    {        m_PointLight.intensity = Random.Range(0f, 3f);    }}