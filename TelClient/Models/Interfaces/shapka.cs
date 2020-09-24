using System;
using System.Collections.Generic;
using System.Text;

namespace TelClient.Models.Interfaces
{
    internal class GenForm
    {
        public IList<shapka> ElementsShapka { get; set; } = new List<shapka>();

        public string Description { get; set; }
    }
    internal class shapka 
        {

            public string Label { get; set; }

            public string EditBox { get; set; }

            public string Flag { get; set; }

        }

    internal class GenFormButtons
    {
        public IList<ButtonsForm> ElementsShapka { get; set; } = new List<ButtonsForm>();

        public string Description { get; set; }
    }
    internal class ButtonsForm
    {

        public string Label { get; set; }

        public string type { get; set; }


    }
}

