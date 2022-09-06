using Microsoft.JSInterop;

namespace Blanvas
{
    internal class BlanvasCore : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public BlanvasCore(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blanvas/blanvasJsInterop.js").AsTask());
        }

        public async ValueTask<string> Prompt(string message)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<string>("showPrompt", message);
        }
        public async ValueTask FillStyle(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("fillStyle", id);
        }
        public async ValueTask DrawRect(string id, int x, int y, int width, int height)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("drawRect", id, x, y, width, height);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}