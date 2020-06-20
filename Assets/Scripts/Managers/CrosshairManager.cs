using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{
    [SerializeField]
    protected HorizontalLayoutGroup horizontalCrosshairs;
    [SerializeField]
    protected VerticalLayoutGroup verticalCrosshairs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ///Works for the Whole Screen.
       // horizontalCrosshairs.spacing = Screen.currentResolution.width - 40;
       // verticalCrosshairs.spacing = Screen.currentResolution.height - 40;
    }
}
