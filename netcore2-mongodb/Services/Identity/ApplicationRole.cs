﻿using AspNetCore.Identity.Mongo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore2_mongodb.Services.Identity
{
    public class ApplicationRole : MongoRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string name) : base(name)
        {

        }
    }
}
