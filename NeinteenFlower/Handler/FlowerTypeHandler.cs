﻿using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class FlowerTypeHandler
    {
        public static MsFlowerType GetFlowerType(int id)
        {
            return FlowerTypeRepository.GetFlowerTypeByID(id);
        }
    }
}