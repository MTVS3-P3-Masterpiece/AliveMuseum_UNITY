using System.Collections;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;
using DG.Tweening;

public class GenImageController : MonoBehaviour
{
    private VisualEffect vfx;
    public Image orgImage;
    private float vfxSizeValue = 0f;
    private float vfxTurbulenceValue = 0f;
    void Start()
    {
        vfx = GetComponent<VisualEffect>();
        if (vfx == null)
        {
            Debug.LogError("GenImageController : vfx is null ");
        }

        vfx.SetFloat("ParticleSize", vfxSizeValue);
        vfx.SetFloat("Turbulence", vfxTurbulenceValue);

        //StartCoroutine(VfxControl());
    }

    public IEnumerator VfxControl()
    {
        yield return orgImage.DOFade(0f, 6f);
        yield return DOTween.To(GetVFXSizeValue, SetVFXSizeValue, 1f, 2f);
        yield return new WaitForSeconds(3f);
        yield return DOTween.To(GetVFXTurbulenceValue, SetVFXTurbulenceValue, 1f, 5f);
        yield return DOTween.To(GetVFXSizeValue, SetVFXSizeValue, 0f, 5f);
        yield return new WaitForSeconds(5f);
        yield return DOTween.To(GetVFXTurbulenceValue, SetVFXTurbulenceValue, 0f, 3f);
        //orgImage.DOFade(1f, 3f);
    }

    private float GetVFXSizeValue()
    {
        return vfxSizeValue;
    }

    private void SetVFXSizeValue(float value)
    {
        vfxSizeValue = value;
        vfx.SetFloat("ParticleSize", vfxSizeValue);
    }

    private float GetVFXTurbulenceValue()
    {
        return vfxTurbulenceValue;
    }

    private void SetVFXTurbulenceValue(float value)
    {
        vfxTurbulenceValue = value;
        vfx.SetFloat("Turbulence", vfxTurbulenceValue);
    }
    
}
