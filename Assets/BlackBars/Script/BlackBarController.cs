using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBarController : MonoBehaviour {

    public RectTransform TopBar;
    public RectTransform BottomBar;
    public Text IntroText;

    public float MovementSpeed = 40.0f;

    private Vector3 TopStartPosition;
    private Vector3 BottomStartPosition;

    private Vector3 TopTargetPosition;
    private Vector3 BottomTargetPosition;

    private float TopBarHeight=0;
    private float BottomBarHeight=0;

    private Color BarColor;

    private bool FadeOut;

    private bool BarsOut;

    void Start() {
        
        TopStartPosition = TopBar.localPosition;
        BottomStartPosition = BottomBar.localPosition;

        //Get bars height
        TopBarHeight = TopBar.sizeDelta.y;
        BottomBarHeight = BottomBar.sizeDelta.y;

        TopTargetPosition = new Vector3(TopStartPosition.x, TopStartPosition.y - TopBarHeight, TopStartPosition.z);
        BottomTargetPosition = new Vector3(BottomStartPosition.x, BottomStartPosition.y + BottomBarHeight, BottomStartPosition.z);

        BarColor = TopBar.GetComponent<Image>().color;

        FadeOut = false;
        BarsOut = false;

    }


    IEnumerator WaitFadeOut(float seconds) {

        yield return new WaitForSeconds(seconds);
        IntroText.CrossFadeAlpha(0.0f, 0.5f, true);

        yield return new WaitForSeconds(seconds);
        BarsOut = true;

    }


    void Update() {

        if (!FadeOut) {
 
            TopBar.localPosition = Vector3.MoveTowards(TopBar.localPosition, TopTargetPosition, Time.deltaTime*MovementSpeed );
            BottomBar.localPosition = Vector3.MoveTowards(BottomBar.localPosition, BottomTargetPosition, Time.deltaTime * MovementSpeed);

            if (BottomBar.localPosition.y == BottomTargetPosition.y && TopBar.localPosition.y == TopTargetPosition.y) {

                IntroText.CrossFadeAlpha(255.0f, 0.5f, true);

            }

            if (IntroText.canvasRenderer.GetAlpha() >= 250.0f) {

                FadeOut = true;

                StartCoroutine(WaitFadeOut(1f));

            }

        }

        if (BarsOut) {
            TopBar.localPosition = Vector3.MoveTowards(TopBar.localPosition, TopStartPosition, Time.deltaTime * MovementSpeed);
            BottomBar.localPosition = Vector3.MoveTowards(BottomBar.localPosition, BottomStartPosition, Time.deltaTime * MovementSpeed);
        }

    }
}
