using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;

public class AimStateManager : MonoBehaviour
{
    public Cinemachine.AxisState xAxis,yAxis;
    [SerializeField] Transform CamFollowPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);
    }

    private void LateUpdate()
    {
        CamFollowPos.localEulerAngles = new Vector3(yAxis.Value , CamFollowPos.localEulerAngles.y, CamFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value , transform.eulerAngles.z);    
    }
}
