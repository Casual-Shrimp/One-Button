using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    private float _mouseX;
    readonly float _lookspeed = 100f;
    public GameObject player;
    public GameObject lightBeam;
    public SpriteRenderer beam;
    public PolygonCollider2D beamCollision;
    public Light2D light;
    public float Battery = 100f;
    public int batteryCount;
    public  BatteryPercentage percentage;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        beam = lightBeam.GetComponent<SpriteRenderer>();
        beam.enabled = false;
        beamCollision = lightBeam.GetComponent<PolygonCollider2D>();
        beamCollision.enabled = false;
        light = light.GetComponent<Light2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        percentage.SetBattery(Battery);
        _mouseX = Input.GetAxis("Mouse X");
        Debug.Log(batteryCount);
        RechargeFlashlight();
        transform.RotateAround(player.transform.position, Vector3.back,_mouseX * _lookspeed * Time.deltaTime );
        if (Input.GetButton("Fire1") && Battery >= 0)
        {
            beam.enabled = true;
            beamCollision.enabled = true;
            light.intensity = 1.4f;
            light.pointLightInnerRadius = 5.15f;
            light.pointLightOuterRadius = 6.15f;
            Battery -= 0.05f;
            
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
            lightBeam.SetActive(false);
            
        }
    }

    private void RechargeFlashlight()
    {
        if (batteryCount > 0 && Input.GetKeyDown(KeyCode.F) && lightBeam)
        {
            Battery = 100f;
            batteryCount--;
        }
        /*
        Here will be put code to tell the Player to go find a recharge 
        station if the flashlight completly runs out of battery
         */
    }
}
