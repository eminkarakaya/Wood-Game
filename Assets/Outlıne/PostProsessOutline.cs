using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering.PostProcessing;

    [Serializable]
    [PostProcess(typeof(PostProcessOutlineRenderer),PostProcessEvent.AfterStack,"Outline")]
public sealed class PostProsessOutline : PostProcessEffectSettings
{
    public FloatParameter thickness = new FloatParameter { value = 1 };
    public FloatParameter depthMin = new FloatParameter { value = 0 };
    public FloatParameter depthMax = new FloatParameter { value = 1 };
}
