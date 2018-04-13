using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    private ProbeObject probe;
    public Image CurrentProbeHealth;
    public Text HealthPercentage;

    private float maxHitpoint = 100;

    private void Start()
    {
        probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>();
    }

    private void Update()
    {
        float pHealth = probe.Health;
        if (pHealth < 0) pHealth = 0;
        float ratio = pHealth / maxHitpoint;
        CurrentProbeHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
        HealthPercentage.text = (ratio*100).ToString() + '%';
    }
    
}
