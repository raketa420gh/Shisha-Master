using UnityEngine;
using System;

namespace Raketa420
{
   public class BarBank : MonoBehaviour
   {
      private int maxHapinnessPoints;
      private int currentHappinessPoints;

      public static event Action<float> OnHappinessPointsChanged;

      private void Start()
      {
         Initialize();
         ChangeHappinessPoints();
      }

      private void Initialize()
      {
         var gameSession = FindObjectOfType<GameSession>();

         maxHapinnessPoints = gameSession.Data.MaxHappinessPoints;
         currentHappinessPoints = 20;
      }

      public void IncreaseHappinnessPoints(int amount)
      {
         if (amount > 0)
         {
            currentHappinessPoints += amount;

            if (currentHappinessPoints > maxHapinnessPoints)
            {
               currentHappinessPoints = maxHapinnessPoints;
            }
         }
         else
         {
            Debug.LogError("Нельзя добавить отрицательное значение");
         }

         ChangeHappinessPoints();
      }

      public void DecreaseHappinnessPoints(int amount)
      {
         if (amount > 0)
         {
            currentHappinessPoints -= amount;

            if (currentHappinessPoints < 0)
            {
               currentHappinessPoints = 0;
            }
         }
         else
         {
            Debug.LogError("Нельзя вычесть отрицательное значение");
         }

         ChangeHappinessPoints();
      }

      private void ChangeHappinessPoints()
      {
         var normalized = (float)currentHappinessPoints / maxHapinnessPoints;
         OnHappinessPointsChanged?.Invoke(normalized);
      }
   }
}