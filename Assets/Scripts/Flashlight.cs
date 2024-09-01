using System.Collections;
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
    private float Battery = 100f;
    public int batteryCount;
    public  BatteryPercentage percentage;
    private bool isFlickering = false;
    private float timeDelay;
    
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
        RechargeFlashlight();
        transform.RotateAround(player.transform.position, Vector3.back,_mouseX * _lookspeed * Time.deltaTime );
        BatteryStatus();
        

        if (Battery <= 0)
        {
            light.enabled = false;
            lightBeam.SetActive(false);
            
        }
    }
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Battery >= 0)
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
    }

    private void RechargeFlashlight()
    {
        if (batteryCount > 0 && Input.GetKeyDown(KeyCode.F) && Battery > 0)
        {
            Battery = 100f;
            batteryCount--;
        }
        /*
        Here will be put code to tell the Player to go find a recharge 
        station if the flashlight completely runs out of battery
         */
    }
    //Lets the player know that the flashlight is almost out of battery by starting to flicker
    private void BatteryStatus()
    {
        if (Battery <= 30)
        {
            if (isFlickering == false)
            {
                StartCoroutine(FlickeringLight());
            }
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        light.enabled = false;
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        light.enabled = true;
        timeDelay = Random.Range(0.01f, 0.8f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
