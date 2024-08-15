using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    private float _mouseX;
    readonly float _lookspeed = 100f;
    public GameObject Player;
    public GameObject lightBeam;
    public SpriteRenderer beam;
    public PolygonCollider2D beamCollision;
    public Light2D light;
    public float Battery = 100f;
    
    public  BatteryPercentage percentage;
    
    // Start is called before the first frame update
    void Start()
    {
        beam = lightBeam.GetComponent<SpriteRenderer>();
        beam.enabled = false;
        beamCollision = lightBeam.GetComponent<PolygonCollider2D>();
        beamCollision.enabled = false;
        light = light.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        _mouseX = Input.GetAxis("Mouse X");
        
        transform.RotateAround(Player.transform.position, Vector3.back,_mouseX * _lookspeed * Time.deltaTime );
        if (Input.GetButton("Fire1") && Battery >= 0)
        {
            beam.enabled = true;
            beamCollision.enabled = true;
            light.intensity = 5f;
            light.pointLightInnerRadius = 5.15f;
            light.pointLightOuterRadius = 6.15f;
            Battery -= 0.05f;
            Debug.Log(Battery);

            percentage.SetBattery(Battery);
        }
        else
        {
            beam.enabled = false;
            beamCollision.enabled = false;
            light.intensity = 0.8f;
            light.pointLightInnerRadius = 3.3f;
            light.pointLightOuterRadius = 4.15f;
        }

        if (Battery <= 0)
        {
            light.enabled = false;
            
        }
        
        
    }
}
