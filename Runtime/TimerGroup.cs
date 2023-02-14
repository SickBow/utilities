using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sickbow.Utilities{
    public class TimerGroup<T>
    {
        
        Dictionary<T, float> _timers = new Dictionary<T, float>();
        List<T> _keysToModify;

        public TimerGroup( params T[] keys ){
            for (int i = 0; i < keys.Length; i++){
                _timers.Add(keys[i],0);        
            }
            _keysToModify = new List<T>();
        }
        
        public float GetTime( T key ) => _timers[key];
        
        public void ResetOtherTimers(T timerKey) {
            _keysToModify.Clear();
            foreach (KeyValuePair<T, float> kvp in _timers){
                if ( !kvp.Key.Equals(timerKey) )
                    _keysToModify.Add(kvp.Key);
            }
            foreach(T key in _keysToModify){
                _timers[key] = 0;
            }
        }
        
        public void Tick( T timerKey ){
            _timers[timerKey] += Time.deltaTime;
        }
            
    }
}
