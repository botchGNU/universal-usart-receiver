﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GUI_Meas_Demo.ViewModel
{
    internal interface IConfirmButtonViewModel
    {
        public bool IsConfirmButtonEnabled { get; set; }
        public bool IsConfirmButtonRequirementsMet { get; }
    }
}
