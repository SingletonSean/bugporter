﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.Client.Features.ReportBug.API
{
    public class ReportBugResponse
    {
        public string Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
    }
}
