using System;
public interface EnvironmentModel
{
    CommandSubject Messages { get; }
    void OnEnter();
    void OnExit();
}
