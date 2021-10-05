using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public RectTransform backButtonRect;
    public RectTransform nextButtonRect;

    public Button backButton;

    public Rect screen;
    public Rect safeArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rect screenRect = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
        screen = screenRect;
        safeArea = Screen.safeArea;

        // Adjusting screen layout based on orientation
        switch(Screen.orientation)
        {
            case ScreenOrientation.LandscapeLeft:
                // backButtonRect.anchoredPosition = new Vector2(safeArea.x, safeArea.y);
                // nextButtonRect.anchoredPosition = new Vector2(safeArea.width + safeArea.x, safeArea.y);
                break;
            case ScreenOrientation.LandscapeRight:
                break;
            case ScreenOrientation.Portrait:
                break;
            default:
                break;
        }
    }
}
