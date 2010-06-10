
using System;
using IrrlichtNETCP;
using IrrlichtNETCP.Inheritable;

namespace IrrlichtNETCP.Extensions
{
    public class RotationAnimator : IAnimator
    {
        Vector3D m_rotationStart;
        Vector3D m_rotationEnd;
        uint m_startTime = 0;
        uint m_durationMs = 0;

        public RotationAnimator(Vector3D p_RotationStart, Vector3D p_rotationEnd, uint p_durationMs)
        {
            m_rotationStart = p_RotationStart;
            m_rotationEnd = p_rotationEnd;
            m_durationMs = p_durationMs;

        }

        public override void AnimateNode(SceneNode p_node, uint p_currentTimeMs)
        {
            if (m_startTime == 0)
            {
                m_startTime = p_currentTimeMs;
            }
            if (p_currentTimeMs - m_startTime <= m_durationMs)
            {
                Vector3D t_currRotation = p_node.Rotation;
                t_currRotation = m_rotationStart.GetInterpolated(m_rotationEnd, (p_currentTimeMs - m_startTime) / (float)m_durationMs);
                p_node.Rotation = (t_currRotation);
                //m_startTime = p_currentTimeMs;
            }
            else
            {
                p_node.Rotation = m_rotationEnd;
                this.Null();
            }
        }
    }
}
