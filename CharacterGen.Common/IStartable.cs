using System.Collections;
using System.Collections.Generic;

namespace CharacterGen.Common
{
    public interface IStartable
    {
        ComponentStartResponse Start(RuntimeContext context);
    }

    public class ComponentStartResponse
    {
        public bool Success { get; set; }

        public IList<Information> Error { get; } = new List<Information>();
        public IList<Information> Warn { get; } = new List<Information>();
        public IList<Information> Info { get; } = new List<Information>();

        public string Message { get; set; }
    }

    public class ComponentStopResponse
    {
        public bool Success { get; set; }

        public IList<Information> Error { get; } = new List<Information>();
        public IList<Information> Warn { get; } = new List<Information>();
        public IList<Information> Info { get; } = new List<Information>();

        public string Message { get; set; }
    }

    public class ComponentConfigResponse
    {
        public bool Success { get; set; }

        public IList<Information> Error { get; } = new List<Information>();
        public IList<Information> Warn { get; } = new List<Information>();
        public IList<Information> Info { get; } = new List<Information>();

        public string Message { get; set; }
    }

    public class Information
    {
        public string Message { get; set; }
        public int Severity { get; set; }
        public bool Fatal { get; set; }
        public bool ClientVisible { get; set; }
    }
}