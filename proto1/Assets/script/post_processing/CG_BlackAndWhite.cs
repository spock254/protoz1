using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CG_BlackAndWhite : MonoBehaviour
{
    public PostProcessingProfile processingProfile;
    // Start is called before the first frame update
    void Start()
    {
        setBlackAndWhite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setBlackAndWhite()
    {

        ColorGradingModel.Settings colorGradingModel = processingProfile.colorGrading.settings;
        colorGradingModel.basic.saturation = 0;
        processingProfile.colorGrading.settings = colorGradingModel;
    }
}
