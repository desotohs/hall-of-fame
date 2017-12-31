using System;
using Com.GitHub.ZachDeibert.GraphicsCore;

namespace Com.GitHub.DesotoHS.HallOfFame {
    [Application]
    public class Program : IApplication {
        public string Name => "DHS Hall of Fame";

        public ApplicationType Type => ApplicationType.OpenGL;

        public void Start(IRenderContext ctx) {
            Console.WriteLine("Hello, world!");
        }

        public void Stop() {
            Console.WriteLine("Goodbye, world!");
        }
    }
}
