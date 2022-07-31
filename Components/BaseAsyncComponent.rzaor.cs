namespace Pokedex.Components;

public abstract class BaseAsyncComponent<T>
    where T : class
{
    public abstract Func<Task<T>> LoadData();
}
