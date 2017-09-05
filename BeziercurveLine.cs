using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeziercurveLine : MonoBehaviour {

    public void DrawLine(LineRenderer Line, Vector3 DrawStartPoint, Vector3 DrawInterPoint, Vector3 DrawEndPoint, int DrawNum = 100)
    {
        for(int i = 0; i < (DrawNum+1); i++)
        {
            float CalVal = (float)i / DrawNum;
            Vector3 TempBezierPoint = BezierPoint(CalVal, DrawStartPoint, DrawInterPoint, DrawEndPoint);
            Line.positionCount = DrawNum+1;
            Line.SetPosition(i,TempBezierPoint);
        }
    }

    public void DrawLine(LineRenderer Line, Vector3 DrawStartPoint, Vector3 DrawEndPoint)
    {
        Line.positionCount = 2;
        Line.SetPosition(0, DrawStartPoint);
        Line.SetPosition(1, DrawEndPoint);
    }

    public void DrawLine(LineRenderer Line, Vector3 DrawStartPoint, Vector3 Direction,float Distance)
    {
        Line.positionCount = 2;
        Line.SetPosition(0, DrawStartPoint);
        Line.SetPosition(1, DrawStartPoint + Direction * Distance);
    }

    private Vector3 BezierPoint(float CalVal,Vector3 StartPoint,Vector3 InterPoint,Vector3 EndPoint)
    {
        if (CalVal < 0 || CalVal > 1)
        {
            Debug.Log("The Value is beyond Calculate!!");
        }
        float P0 = Mathf.Pow(1-CalVal,2);
        float P1 = 2 * CalVal * (1 - CalVal);
        float P2 = Mathf.Pow(CalVal,2);
        return (P0 * StartPoint + P1 * InterPoint + P2 * EndPoint);
    }
	
}
