using OnionArchOrnegi.Application.Interfaces;

namespace OnionArchOrnegi.WebAPI.Services
{
    public sealed class EnvironmentManager : IEnvironmentService
    {
        public string WebRootPath { get; }
        public EnvironmentManager(string webRootPath)
        {
            WebRootPath = webRootPath;
        }
    }
}
