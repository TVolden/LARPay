﻿using dk.lashout.LARPay.Accounting.Forms;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting
{
    public interface IStatement
    {
        IEnumerable<ITransaction> Statement(Guid account);
    }
}