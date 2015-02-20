// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Security;
using Microsoft.AspNet.Routing;

namespace Microsoft.AspNet.Mvc
{
    public class CorsHttpRequest //: HttpRequest
    {
        //private readonly HttpRequest _httpRequest;

        //public CorsHttpRequest(HttpRequest httpRequest)
        //{
        //    _httpRequest = httpRequest;
        //}

        //public override Stream Body
        //{
        //    get
        //    {
        //        return _httpRequest.Body;
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override long? ContentLength
        //{
        //    get
        //    {
        //        return _httpRequest.
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override string ContentType
        //{
        //    get
        //    {
        //        return _httpRequest.
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override IReadableStringCollection Cookies
        //{
        //    get
        //    {
        //        return _httpRequest.
        //    }
        //}

        //public override IFormCollection Form
        //{
        //    get
        //    {
        //        return _httpRequest.
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override bool HasFormContentType
        //{
        //    get
        //    {
        //        return _httpRequest.
        //    }
        //}

        //public override IHeaderDictionary Headers
        //{
        //    get
        //    {
        //        return _httpRequest.
        //    }
        //}

        //public override HostString Host
        //{
        //    get
        //    {
        //        return _httpRequest.
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override HttpContext HttpContext
        //{
        //    get
        //    {
        //        return _httpRequest.
        //    }
        //}

        //public override bool IsHttps
        //{
        //    get
        //    {
        //        return _httpRequest.
        //    }
        //}

        //public override string Method
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override PathString Path
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override PathString PathBase
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override string Protocol
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override IReadableStringCollection Query
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override QueryString QueryString
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override string Scheme
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    throw new NotImplementedException();
        //}
    }
}
