using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
   private int _currentLevel = 0;

   public int CurrentLevel
   {
      get => _currentLevel;
      set => _currentLevel = value;
   }
}
