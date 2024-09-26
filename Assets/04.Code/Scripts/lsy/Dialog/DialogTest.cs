using System.Collections;
using TMPro;
using UnityEngine;

public class DialogTest : MonoBehaviour
{
    [SerializeField] private DialogSystem dialogSystem01;
    [SerializeField] private TMP_Text textCountDown;
    [SerializeField] private DialogSystem dialogSystem02;

    private IEnumerator Start()
    {
        textCountDown.gameObject.SetActive(false);
        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

        textCountDown.gameObject.SetActive(true);
        int count = 5;
        while (count > 0)
        {
            textCountDown.text = count.ToString();
            count--;

            yield return new WaitForSeconds(1);
        }

        textCountDown.gameObject.SetActive(false);
        yield return new WaitUntil(() => dialogSystem02.UpdateDialog());
        
        textCountDown.gameObject.SetActive(true);
        textCountDown.text = "The End";

        yield return new WaitForSeconds(2);
    }
}
