using UnityEngine;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour
{
    public Text flashText;

    public Color red => Color.red;
    public Color white => Color.white;

    public void Update() {
        flashText.color = FlashEffect();
    }

    public Color FlashEffect(){
        return Color.Lerp(white, red, Mathf.Sin(Time.time *8));
    }

}
