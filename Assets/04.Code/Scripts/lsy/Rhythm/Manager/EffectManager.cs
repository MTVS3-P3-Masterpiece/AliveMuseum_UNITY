using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private Animator noteHitAnimator = null;
    private string hit = "Hit";

    [SerializeField] private Animator judgementAnimator = null;
    public Image JudgementImage = null;
    public Sprite[] judgementSprite = null;
    
    public void JudgementEffect(int p_num)
    {
        JudgementImage.sprite = judgementSprite[p_num];
        judgementAnimator.SetTrigger(hit);
    }
    public void NoteHitEffect()
    {
        noteHitAnimator.SetTrigger(hit);
    }
}
