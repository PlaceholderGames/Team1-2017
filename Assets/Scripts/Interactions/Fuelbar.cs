using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuelbar : MonoBehaviour {

    private ProbeObject probe;
    public Image CurrentProbeFuel;
    public Text FuelPercentage;

    private float StartFuel;
    private float MaxFuel;
    private float ratio;
    private float ZeroFuel = 0;

    private void Start()
    {
        probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>();
        StartFuel = probe.GetFuel();
        MaxFuel = StartFuel;
    }

    private void Update()
    {
        float pFuel = probe.GetFuel();
        if (pFuel < 0) pFuel = 0;
        ratio = pFuel / MaxFuel;
        CurrentProbeFuel.rectTransform.localScale = new Vector3(ratio, 1, 1);
        FuelPercentage.text = ((int)System.Math.Round((double)(ratio*100))).ToString() + '%';

        death();
    }

    private void death()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            ratio = ZeroFuel;
            FuelPercentage.text = ZeroFuel.ToString() + '%';
        }
    }

}
