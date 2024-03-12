using System;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleHandler : MonoBehaviour
{
    private PuzzleComponent[] puzzleComponents;
    private ValueTransmitter<int> puzzleValueTransmitter;

    [SerializeField] UnityEvent onPuzzleSolved;

    public void SolvePuzzle() { onPuzzleSolved.Invoke(); }

    private void Start()
    {
        puzzleComponents = GetComponentsInChildren<PuzzleComponent>();
        puzzleValueTransmitter = new ValueTransmitter<int>();

        foreach (var component in puzzleComponents)
        {
            component.Init(puzzleValueTransmitter);
        }
    }


}

public class ValueTransmitter<T>{
    private T _value;
    public T Value => _value;
    private Action _onValueChange;
    private Action _onValueClear;

    public ValueTransmitter(){
        _value = default;
    }

    public void SubscribeOnChange(Action action, bool consume = false){
        _onValueChange += action;

        if(consume)
            _onValueChange += () => _onValueChange -= action;
    }

    public void SubscribeOnClear(Action action, bool consume = false){
        _onValueClear += action;

        if(consume)
            _onValueClear += () => _onValueClear -= action;
    }

    public void UnsubscribeOnChange(Action action){
        _onValueChange -= action;
    }

    public void UnsubscribeOnClear(Action action){
        _onValueClear -= action;
    }

    public void SetValue(T value){
        _value = value;

        _onValueChange?.Invoke();
    }

    public void ClearValue(){
        _onValueClear?.Invoke();
        _value = default;
    }
}

public interface ITransmitterCompatible<T>{
    public void Init(ValueTransmitter<T> transmitter);
}
