﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class User:BaseEntity
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public int amountTranslatedWords { get; set; }
    }
}
