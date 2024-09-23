using UnityEngine;

public class FogController : MonoBehaviour
{
    [SerializeField]
    private float course1Density = 0.5f;
    [SerializeField]
    private Color course1Color;
    
    [SerializeField]
    private float course2Density = 0.01f;
    [SerializeField]
    private Color course2Color;
    
    [SerializeField]
    private float course3_1Density = 0.01f;
    [SerializeField]
    private Color course3_1Color;

    [SerializeField]
    private float course3_2Density = 0.01f;
    [SerializeField]
    private Color course3_2Color;

    public void SetCourse1Fog()
    {
        RenderSettings.fogColor = course1Color;
        RenderSettings.fogDensity = course1Density;
    }
    public void SetCourse2Fog()
    {
        Debug.Log("FogController : SetCourse2Fog");
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
}
