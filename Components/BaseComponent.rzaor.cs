using Microsoft.AspNetCore.Components;

namespace Pokedex.Components;

public abstract partial class BaseComponent<T>
{
    public T Data { get; protected set; }

    [Parameter]
    [EditorRequired]
    public RenderFragment ChildContent { get; set; }

    public abstract Func<T> LoadData();
}
