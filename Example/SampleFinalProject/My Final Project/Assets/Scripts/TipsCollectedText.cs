using System.Collections;
using TMPro;
using UnityEngine;

public class TipsCollectedText : MonoBehaviour
{

    [SerializeField] TMP_Text tipsCollectedText;

    private void Start()
    {
        tipsCollectedText = GetComponent<TMP_Text>();
    }

    public void UpdateText()
    {
        StartCoroutine(WaitForSecond());
    }
    private IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(2);
        tipsCollectedText.text = "Tips Collected - " + GameManager.Instance.tipsCollected;
    }
}
