using System.Collections.Generic;

namespace Language
{
    class Keyword
    {

        public Dictionary<string, Keyword> keys = new Dictionary<string, Keyword>();
        public Dictionary<string, string[]> funcs = new Dictionary<string, string[]>();
        public Dictionary<string, string> strings = new Dictionary<string, string>();
        public Dictionary<string, float> floats = new Dictionary<string, float>();

    }
}
