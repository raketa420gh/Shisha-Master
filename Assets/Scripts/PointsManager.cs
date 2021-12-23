using System;
using UnityEngine;

namespace Raketa420
{
    public class PointsManager : MonoBehaviour
    {
        private int currentServicePoints;
        private int maxServicePoints;

        public static event Action<float> OnServicePointsChanged;

        public int CurrentServicePoints => currentServicePoints;
        public int MaxServicePoints => maxServicePoints;
        
        public void Initialize()
        {
        }

        public void IncreaseServicePoints(int amount)
        {
            if (amount > 0)
            {
                currentServicePoints += amount;

                if (currentServicePoints > maxServicePoints)
                {
                    currentServicePoints = maxServicePoints;
                }
                
                OnServicePointsChanged?.Invoke((float)currentServicePoints/maxServicePoints);
            }
            else
            {
                Debug.LogError("You can not set a negavite amount");
            }
        }

        public void DecreaseServicePoints(int amount)
        {
            if (amount > 0)
            {
                currentServicePoints -= amount;

                if (currentServicePoints < 0)
                {
                    currentServicePoints = 0;
                }
                
                OnServicePointsChanged?.Invoke((float)currentServicePoints/maxServicePoints);
            }
            else
            {
                Debug.LogError("You can not set a negavite amount");
            }
        }

        public void SetServicePointsValues(int current, int max)
        {
            currentServicePoints = current;
            maxServicePoints = max;
            
            OnServicePointsChanged?.Invoke((float)currentServicePoints/maxServicePoints);
        }
    }
}