using System;
using UnityEngine;

namespace Raketa420
{
    public class ClientReaction : MonoBehaviour
    {
        public static event Action<int> OnPositiveReacted;
        public static event Action<int> OnNegativeReacted;

        public void ReactPositive(int pointsToIncrease)
        {
            OnPositiveReacted?.Invoke(pointsToIncrease);
        }

        public void ReactNegative(int pointsToDecrease)
        {
            OnNegativeReacted?.Invoke(pointsToDecrease);
        }
    }
}