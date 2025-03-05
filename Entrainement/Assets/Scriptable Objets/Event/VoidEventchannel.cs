using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "VoidEventchannel", menuName = "Scriptable Objects/Event/VoidEventchannel")]
public class VoidEventchannel : ScriptableObject
{
    public UnityAction OnEventRaised;
    public void Raise(){
        if (OnEventRaised != null){
            OnEventRaised.Invoke();
        }
    }    
}
