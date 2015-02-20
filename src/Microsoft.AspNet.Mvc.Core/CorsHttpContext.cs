// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Security;
using Microsoft.AspNet.Routing;

namespace Microsoft.AspNet.Mvc
{
    public class CorsHttpContext
    {
        //private readonly HttpContext _httpContext;
        //private readonly HttpRequest _httpRequest;

        //public CorsHttpContext(HttpContext context)
        //{
        //    _httpContext = context;
        //    _httpRequest = GetCorsHttpRequest(context.Request);
        //}

        //private HttpRequest GetCorsHttpRequest(HttpRequest request)
        //{
           

        //}

        //public override IServiceProvider ApplicationServices
        //{
        //    get
        //    {
        //        return _httpContext.ApplicationServices;
        //    }

        //    set
        //    {
        //        _httpContext.ApplicationServices = value;
        //    }
        //}

        //public override bool IsWebSocketRequest
        //{
        //    get
        //    {
        //        return _httpContext.IsWebSocketRequest;
        //    }
        //}

        //public override IDictionary<object, object> Items
        //{
        //    get
        //    {
        //        return _httpContext.Items;
        //    }
        //}

        //public override HttpRequest Request
        //{
        //    get
        //    {
        //        return _httpRequest;
        //    }
        //}

        //public override CancellationToken RequestAborted
        //{
        //    get
        //    {
        //        return _httpContext.RequestAborted;
        //    }
        //}

        //public override IServiceProvider RequestServices
        //{
        //    get
        //    {
        //        return _httpContext.RequestServices;
        //    }

        //    set
        //    {
        //        _httpContext.RequestServices = value;
        //    }
        //}

        //public override HttpResponse Response
        //{
        //    get
        //    {
        //        return _httpContext.Response;
        //    }
        //}

        //public override ISessionCollection Session
        //{
        //    get
        //    {
        //        return _httpContext.Session;
        //    }
        //}

        //public override ClaimsPrincipal User
        //{
        //    get
        //    {
        //        return _httpContext.User;
        //    }

        //    set
        //    {
        //        _httpContext.User = value;
        //    }
        //}

        //public override IList<string> WebSocketRequestedProtocols
        //{
        //    get
        //    {
        //        return _httpContext.WebSocketRequestedProtocols;
        //    }
        //}

        //public override void Abort()
        //{
        //    _httpContext.Abort();
        //}

        //public override Task<WebSocket> AcceptWebSocketAsync(string subProtocol)
        //{
        //    return _httpContext.AcceptWebSocketAsync(subProtocol);
        //}

        //public override IEnumerable<AuthenticationResult> Authenticate(IEnumerable<string> authenticationTypes)
        //{
        //    return _httpContext.Authenticate(authenticationTypes);
        //}

        //public override Task<IEnumerable<AuthenticationResult>> AuthenticateAsync(IEnumerable<string> authenticationTypes)
        //{
        //    return _httpContext.AuthenticateAsync(authenticationTypes);
        //}

        //public override void Dispose()
        //{
        //    _httpContext.Dispose();
        //}

        //public override IEnumerable<AuthenticationDescription> GetAuthenticationTypes()
        //{
        //    return _httpContext.GetAuthenticationTypes();
        //}

        //public override object GetFeature(Type type)
        //{
        //    return _httpContext.GetFeature(type);
        //}

        //public override void SetFeature(Type type, object instance)
        //{
        //    _httpContext.SetFeature(type, instance);
        //}
    }
}
