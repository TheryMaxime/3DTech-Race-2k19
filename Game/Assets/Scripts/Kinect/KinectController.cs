using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectController : MonoBehaviour
{
    public int m_CharacterId; //ID of the current character
    public KinectWrapper.NuiSkeletonPositionIndex m_HandRight = KinectWrapper.NuiSkeletonPositionIndex.HandRight;
    public KinectWrapper.NuiSkeletonPositionIndex m_HandLeft = KinectWrapper.NuiSkeletonPositionIndex.HandLeft;
    public KinectWrapper.NuiSkeletonPositionIndex m_Head = KinectWrapper.NuiSkeletonPositionIndex.Head;

    private uint m_PlayerId; //ID of the current player
    private KinectManager m_Manager; //Instance of the KinectManager
    private Dictionary<KinectWrapper.NuiSkeletonPositionIndex, Vector3> m_Joints; //Dictionnary of tracked joints
    private float m_angleHands;
    private float m_handsZ;
    private CharacterMovement characterMovement;

    // Start is called before the first frame update
    void Start()
    {
        this.m_Joints = new Dictionary<KinectWrapper.NuiSkeletonPositionIndex, Vector3>();
        this.InstantiateJoints();
        this.characterMovement = gameObject.GetComponent<CharacterMovement>();
    }

    private void InstantiateJoints()
    {
        //On rempli au préalable le dictionnary de 'joint' pour pouvoir loop dessus plus tard
        Vector3 nullVector = new Vector3(0, 0, 0);
        this.m_Joints.Add(this.m_HandRight, nullVector);
        this.m_Joints.Add(this.m_HandLeft, nullVector);
        this.m_Joints.Add(this.m_Head, nullVector);
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
                /*
                //En cas d'implémentation d'un mode deux joueurs
                else
                {
                    this.m_PlayerId = this.m_Manager.GetPlayer2ID();
                }
                */

                //Récupère les positions des 'joints' à cibler
                this.GetTrackedJoints();
                //Effectue les calculs nécéssaire au mouvement du personnage
                this.ComputePosition();
                //Envoie les instructions de déplacement au character
                this.SendInstructions();
            }
        }
    }

    private void GetTrackedJoints()
    {
        Dictionary < KinectWrapper.NuiSkeletonPositionIndex, Vector3 > _copy = new Dictionary<KinectWrapper.NuiSkeletonPositionIndex, Vector3>();
        foreach (KinectWrapper.NuiSkeletonPositionIndex joint in this.m_Joints.Keys)
        {
            _copy.Add(joint, this.m_Manager.GetJointPosition(this.m_PlayerId, (int)joint));
        }
        this.m_Joints = _copy;
    }

    private void ComputePosition()
    {
        //On cherche à avoir un angle entre la ligne des mains et une ligne horizontal
        this.m_angleHands = this.ComputeAngle(this.m_HandLeft, this.m_HandRight);
        //On cherche la distance 'Z' entre la main droite et la tête du joueur
        this.m_handsZ = this.ComputeZPosition(this.m_Head, this.m_HandRight);
    }

    private float ComputeAngle(KinectWrapper.NuiSkeletonPositionIndex jointLeft, KinectWrapper.NuiSkeletonPositionIndex jointRight)
    {
        Vector2 v_jointLeft = this.m_Joints[jointLeft];
        Vector2 v_jointRight = this.m_Joints[jointRight];
        Vector2 v_jointsLine = v_jointRight - v_jointLeft;
        Vector2 v_horizontalLine = new Vector2(v_jointsLine.x, 0);
        //Attention Angle() retourne toujours une valeur positive
        if (this.m_Joints[jointLeft].y < this.m_Joints[jointRight].y)
            return -Vector2.Angle(v_jointsLine, v_horizontalLine);
        else
            return Vector2.Angle(v_jointsLine, v_horizontalLine);
    }

    private float ComputeZPosition(KinectWrapper.NuiSkeletonPositionIndex avgPosition, KinectWrapper.NuiSkeletonPositionIndex position)
    {
        float avgPositionZ = this.m_Joints[avgPosition].z;
        float positionZ = this.m_Joints[position].z;
        return avgPositionZ - positionZ;
    }

    private void SendInstructions()
    {
        this.characterMovement.Move(this.m_angleHands);
        this.characterMovement.ControlSpeed(this.m_handsZ);
    }
}
