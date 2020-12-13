//Temporary HDRP and Raytracing fixes

//VPP´s Smooth Follow, Orbit, Look at and Free Camera Controller is broken on HDRP
//After enable per Hotkey Main Camera´s FOV is set to 1e-05
//This script creates a Slider that allows you to manipulate the Camera's field of view and overwites Follow, Orbit, Look at and Free Camera Controller FOV

// Raytraced Shadows from Directional Light enabled is spawaning 'm_RendererData.m_LightProbeUsage != kLightProbeUsageOff' errors for all meshes. Switch off. Find out why?

using UnityEngine;

public class CameraFieldOfViewSlider : MonoBehaviour
{
    //This is the field of view that the Camera has
    float m_FieldOfView;

    void Awake()
    {
        //Start the Camera field of view at 60
        m_FieldOfView = 102f;

        // FIX 'm_RendererData.m_LightProbeUsage != kLightProbeUsageOff' errors for all meshes when raytraces shadows are enabled
        FixkLightProbeUsageOff();
    }

    void Update()
    {
        //Update the camera's field of view to be the variable returning from the Slider
        Camera.main.fieldOfView = m_FieldOfView;
    }

    void OnGUI()
    {
        //Set up the maximum and minimum values the Slider can return (you can change these)
        float max, min;
        max = 150.0f;
        min = 20.0f;
        //This Slider changes the field of view of the Camera between the minimum and maximum values
        m_FieldOfView = GUI.HorizontalSlider(new Rect(20, 20, 100, 40), m_FieldOfView, min, max);
    }

    public void FixkLightProbeUsageOff()
    {
        foreach (MeshRenderer go in Resources.FindObjectsOfTypeAll(typeof(MeshRenderer)) as MeshRenderer[])
        {
            if (go.lightProbeUsage == UnityEngine.Rendering.LightProbeUsage.Off) go.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.BlendProbes;
        }
    }


}