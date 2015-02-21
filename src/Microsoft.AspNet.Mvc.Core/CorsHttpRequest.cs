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
    public class CorsHttpRequest : HttpRequest
    {
        private readonly HttpRequest _httpRequest;
        private readonly string _method;

        public CorsHttpRequest(HttpRequest httpRequest, string corsMethod)
        {
            _httpRequest = httpRequest;
            _method = corsMethod;
        }

        public override Stream Body
        {
            get
            {
                return _httpRequest.Body;
            }

            set
            {
                _httpRequest.Body = value;
            }
        }

        public override long? ContentLength
        {
            get
            {
                return _httpRequest.ContentLength;
            }

            set
            {
                _httpRequest.ContentLength = value;
            }
        }

        public override string ContentType
        {
            get
            {
                return _httpRequest.ContentType;
            }

            set
            {
                _httpRequest.ContentType = value;
            }
        }

        public override IReadableStringCollection Cookies
        {
            get
            {
                return _httpRequest.Cookies;
            }
        }

        public override IFormCollection Form
        {
            get
            {
                return _httpRequest.Form;
            }

            set
            {
                _httpRequest.Form = value;
            }
        }

        public override bool HasFormContentType
        {
            get
            {
                return _httpRequest.HasFormContentType;
            }
        }

        public override IHeaderDictionary Headers
        {
            get
            {
                return _httpRequest.Headers;
            }
        }

        public override HostString Host
        {
            get
            {
                return _httpRequest.Host;
            }

            set
            {
                _httpRequest.Host = value;
            }
        }

        public override HttpContext HttpContext
        {
            get
            {
                return _httpRequest.HttpContext;
            }
        }

        public override bool IsHttps
        {
            get
            {
                return _httpRequest.IsHttps;
            }
        }

        public override string Method
        {
            get
            {
                return _method;
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        public override PathString Path
        {
            get
            {
                return _httpRequest.Path;
            }

            set
            {
                _httpRequest.Path = value;
            }
        }

        public override PathString PathBase
        {
            get
            {
                return _httpRequest.PathBase;
            }

            set
            {
                _httpRequest.PathBase = value;
            }
        }

        public override string Protocol
        {
            get
            {
                return _httpRequest.Protocol;
            }

            set
            {
                _httpRequest.Protocol = value;
            }
        }

        public override IReadableStringCollection Query
        {
            get
            {
                return _httpRequest.Query;
            }
        }

        public override QueryString QueryString
        {
            get
            {
                return _httpRequest.QueryString;
            }

            set
            {
                _httpRequest.QueryString = value;
            }
        }

        public override string Scheme
        {
            get
            {
                return _httpRequest.Scheme;
            }

            set
            {
                _httpRequest.Scheme = value;
            }
        }

        public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _httpRequest.ReadFormAsync(cancellationToken);
        }
    }
}
