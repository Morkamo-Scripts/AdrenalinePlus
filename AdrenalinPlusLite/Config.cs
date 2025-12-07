using Exiled.API.Interfaces;

namespace AdrenalinPlusLite
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        
        public Handler Handler { get; set; } = new Handler();
    }
}