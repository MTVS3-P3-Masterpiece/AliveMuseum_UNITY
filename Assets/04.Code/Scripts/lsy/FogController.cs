using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class FogController : MonoBehaviour
{ 
    public List<EnvironmentData> environments;
    private EnvironmentData curEnvironment;
    
    //public float blendDuration = 20f;  // 블렌딩 시간
    private float blendTimer = 0f;  
    
    public Camera _mainCamera;
    [SerializeField] private float course1Density;
    [SerializeField]
    private Color course1Color;
    

    [SerializeField] private float course2Density;
    [SerializeField]
    private Color course2Color;

    [SerializeField] private float course3_1Density;
    [SerializeField]
    private Color course3_1Color;

    [SerializeField] private float course3_2Density;
    [SerializeField]
    private Color course3_2Color;


    public void Start()
    {
        // 초기 설정
        environments[0].skyBoxMaterial.SetFloat("_Blend", 0f);
        environments[1].skyBoxMaterial.SetFloat("_Blend", 0f);
        environments[2].skyBoxMaterial.SetFloat("_Blend", 0f);
        environments[3].skyBoxMaterial.SetFloat("_Blend", 0f);
        
        RenderSettings.skybox = environments[0].skyBoxMaterial;
        RenderSettings.fogColor = environments[0].fogColor;
        RenderSettings.fogDensity = environments[0].fogDensity;
        environments[0].volume.weight = 1f;
        curEnvironment = environments[0];
    }
    
    public void SetCourse1Fog()
    {
        RenderSettings.fogColor = course1Color;
        RenderSettings.fogDensity = course1Density;
    }
    public void SetCourse2Fog()
    {
        _mainCamera.clearFlags = CameraClearFlags.Skybox;
        RenderSettings.fogColor = course2Color;
        RenderSettings.fogDensity = course2Density;
    }
    
    public void SetCourse3_1Fog()
    {
        RenderSettings.fogColor = course3_1Color;
        RenderSettings.fogDensity = course3_1Density;
    }

    public void SetCourse3_2Fog()
    {
        RenderSettings.fogColor = course3_2Color;
        RenderSettings.fogDensity = course3_2Density;
    }

    public IEnumerator StartBlending(EnvironmentData targetEnvironment, float blendDuration)
    {
        blendTimer = 0f;
        while (true)
        {
            blendTimer += Time.deltaTime;
            float blendFactor = Mathf.Clamp01(blendTimer / blendDuration);
         
            //  스카이박스 블렌딩
            targetEnvironment.skyBoxMaterial.SetFloat("_Blend", blendFactor);
            RenderSettings.skybox = targetEnvironment.skyBoxMaterial;
            //blendedSkybox.Lerp(curEnvironment.skyBoxMaterial ,targetEnvironment.skyBoxMaterial, blendFactor);
            //RenderSettings.skybox = blendedSkybox;

            // Volume 블렌딩
            curEnvironment.volume.weight = Mathf.Lerp(1f, 0f, blendFactor);
            targetEnvironment.volume.weight = Mathf.Lerp(0f, 1f, blendFactor);
            
            // Light 블렌딩
            curEnvironment.sceneLight.DOIntensity(0f, blendDuration);
            curEnvironment.sceneLight.DOIntensity(1f, blendDuration);
            //curEnvironment.sceneLight.intensity = Mathf.Lerp(1f, 0f, blendFactor);
            //targetEnvironment.sceneLight.intensity = Mathf.Lerp(0f, 1f, blendFactor);

            if (blendFactor >= 1f)
            {
                curEnvironment = targetEnvironment;
                break;
            }
            yield return null;
        }
    }
    
    
}
[System.Serializable]
public struct EnvironmentData
{
    public Volume volume;
    public Light sceneLight;
    public Material skyBoxMaterial;
    public Color fogColor;
    public float fogDensity;
    public Color shadowColor;
}