using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectController : MonoBehaviour
{
    public int m_CharacterId; //ID of the current character
    public KinectWrapper.NuiSkeletonPositionIndex m_HandRight = KinectWrapper.NuiSkeletonPositionIndex.HandRight;
    public KinectWrapper.NuiSkeletonPositionIndex m_HandLeft = KinectWrapper.NuiSkeletonPositionIndex.HandLeft;

    private uint m_PlayerId; //ID of the current player
    private KinectManager m_Manager; //Instance of the KinectManager
    private Dictionary<KinectWrapper.NuiSkeletonPositionIndex, Vector3> m_Joints; //Dictionnary of tracked joints
    private float m_angleHands;

    // Start is called before the first frame update
    void Start()
    {
        this.InstantiateJoints();
        //TODO
        //Get the current character controller
    }

    private void InstantiateJoints()
    {
        Vector3 nullVector = new Vector3(0, 0, 0);
        this.m_Joints.Add(this.m_HandRight, nullVector);
        this.m_Joints.Add(this.m_HandLeft, nullVector);
    }

    // Update is called once per frame
    void Update()
    {
        this.m_Manager = KinectManager.Instance;
        if (this.m_Manager && this.m_Manager.IsInitialized())
        {
            if (this.m_Manager.IsUserDetected())
            {
                if (this.m_CharacterId == 1)
                {
                    this.m_PlayerId = this.m_Manager.GetPlayer1ID();
                }
                else
                {
                    this.m_PlayerId = this.m_Manager.GetPlayer2ID();
                }

                this.GetTrackedJoints();
                this.ComputePosition();
                this.SendInstructions();
            }
        }
    }

    private void GetTrackedJoints()
    {
        foreach (KinectWrapper.NuiSkeletonPositionIndex joint in this.m_Joints.Keys)
        {
            this.m_Joints.Add(joint, this.m_Manager.GetJointPosition(this.m_PlayerId, (int)joint));
        }
    }

    private void ComputePosition()
    {
        this.m_angleHands = this.ComputeAngle(this.m_HandLeft, this.m_HandRight);
    }

    private float ComputeAngle(KinectWrapper.NuiSkeletonPositionIndex jointLeft, KinectWrapper.NuiSkeletonPositionIndex jointRight)
    {
        Vector2 v_jointLeft = this.m_Joints[jointLeft];
        Vector2 v_jointRight = this.m_Joints[jointRight];
        Vector2 v_jointsLine = v_jointRight - v_jointLeft;
        Vector2 v_horizontalLine = new Vector2(v_jointsLine.x, 0);
        return Vector2.Angle(v_jointsLine, v_horizontalLine);
    }

    private void SendInstructions()
    {
        //TODO
    }
}
