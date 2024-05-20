using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateClicks : MonoBehaviour
{
    public Image faceImage;
    public TMP_Text clicksText;
    private int _clicks;

    public void IncrementClicks()
    {
        _clicks++;
        clicksText.text = $"Clicks: {_clicks}";
    }

    public void FaceKeyDown()
    {
        
    }
}
