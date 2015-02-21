// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using MvcSample.Web.Models;

namespace MvcSample.Web
{
    public class CorsController : Controller
    {
        [EnableCors("*", "*", "*", null)]
        [HttpGet]
        public string GetString()
        {
            return "Success";
        }
    }
}