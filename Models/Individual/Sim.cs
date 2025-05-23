﻿using GTRC_Basics.Models.Common;

namespace GTRC_Basics.Models
{
    public class Sim : IBaseModel
    {
        public static readonly string DefaultName = nameof(Sim) + " #1";

        public override string ToString() { return Name; }

        public int Id { get; set; }
        public string Name { get; set; } = DefaultName;
        public string ShortName { get; set; } = DefaultName;
    }
}
