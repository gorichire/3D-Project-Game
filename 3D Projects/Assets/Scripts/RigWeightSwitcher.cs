using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigWeightSwitcher : MonoBehaviour
{
    public MultiAimConstraint headConstraint;
    public TwoBoneIKConstraint rightHandConstraint;
    public TwoBoneIKConstraint leftHandConstraint;

    public MultiRotationConstraint rightHandRotationConstraint;
    public MultiRotationConstraint leftHandRotationConstraint;

    public float lerpDuration = 0.3f;

    Coroutine headCoroutine, rightHandCoroutine, leftHandCoroutine;
    Coroutine rightHandRotCoroutine, leftHandRotCoroutine;

    // �Ӹ� Aim
    public void SetHeadAimWeight(float targetWeight)
    {
        if (headCoroutine != null)
            StopCoroutine(headCoroutine);
        headCoroutine = StartCoroutine(LerpConstraintWeight(headConstraint, targetWeight));
    }

    // ������ IK
    public void SetRightHandWeight(float targetWeight)
    {
        if (rightHandCoroutine != null)
            StopCoroutine(rightHandCoroutine);
        rightHandCoroutine = StartCoroutine(LerpConstraintWeight(rightHandConstraint, targetWeight));
    }

    // �޼� IK
    public void SetLeftHandWeight(float targetWeight)
    {
        if (leftHandCoroutine != null)
            StopCoroutine(leftHandCoroutine);
        leftHandCoroutine = StartCoroutine(LerpConstraintWeight(leftHandConstraint, targetWeight));
    }

    // ������ ȸ�� MultiRotation
    public void SetRightHandRotationWeight(float targetWeight)
    {
        if (rightHandRotCoroutine != null)
            StopCoroutine(rightHandRotCoroutine);
        rightHandRotCoroutine = StartCoroutine(LerpConstraintWeight(rightHandRotationConstraint, targetWeight));
    }

    // �޼� ȸ�� MultiRotation
    public void SetLeftHandRotationWeight(float targetWeight)
    {
        if (leftHandRotCoroutine != null)
            StopCoroutine(leftHandRotCoroutine);
        leftHandRotCoroutine = StartCoroutine(LerpConstraintWeight(leftHandRotationConstraint, targetWeight));
    }

    IEnumerator LerpConstraintWeight(IRigConstraint constraint, float target)
    {
        if (constraint == null) yield break;

        float start = constraint.weight;
        float time = 0f;

        while (time < lerpDuration)
        {
            time += Time.deltaTime;
            constraint.weight = Mathf.Lerp(start, target, time / lerpDuration);
            yield return null;
        }
        constraint.weight = target;
    }
}