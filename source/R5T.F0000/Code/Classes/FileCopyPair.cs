﻿using System;

using R5T.T0142;


namespace R5T.F0000
{
    [DataTypeMarker]
    public class FileCopyPair
    {
        public string SourceFilePath { get; set; }
        public string DestinationFilePath { get; set; }
    }
}
