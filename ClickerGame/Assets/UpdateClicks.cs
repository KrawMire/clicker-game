using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UpdateClicks : MonoBehaviour
{
    public Image faceImage;
    public Image backgroundImage;
    public TMP_Text clicksText;
    
    private const float ShakeDuration = 0.5f;
    private const float ShakeStrength = 10f;
    
    private int _clicks;
    private Vector3 _originalScale;
    private Vector3 _smallerScale;

    public void Start()
    {
        faceImage ??= GetComponent<Image>();
        backgroundImage ??= GetComponent<Image>();
        
        _originalScale = faceImage.transform.localScale;
        _smallerScale = _originalScale * 0.9f;
    }

    public void PushDown()
    {
        IncrementClicks();
        faceImage.transform.localScale = _smallerScale;
    }

    public void PushUp()
    {
        faceImage.transform.localScale = _originalScale;
        StartCoroutine(ShakeBackground());
    }
    
    private void IncrementClicks()
    {
        _clicks++;
        clicksText.text = $"Clicks: {_clicks}";
    }

    private IEnumerator ShakeBackground()
    {
        var originalPos = backgroundImage.transform.localPosition;
        var elapsed = 0.0f;

        while (elapsed < ShakeDuration)
        {
            var x = Random.Range(-1f, 1f) * ShakeStrength + originalPos.x;
            var y = Random.Range(-1f, 1f) * ShakeStrength + originalPos.y;
            
            backgroundImage.transform.localPosition = new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            
            yield return null;
        }

        backgroundImage.transform.localPosition = originalPos;
    }
}
