namespace JustLogic.Core
{
    /// <tocexclude />
    public enum YieldMode
    {
        None,
#if !JUSTLOGIC_FREE
        YieldForNextUpdate,
        YieldForNextFixedUpdate,
        BreakLoop,
        ContinueLoop,
        Return,
        ReturnScript
#endif

    }
}